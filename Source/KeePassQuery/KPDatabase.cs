using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KeePass.Plugins;
using KeePass.UI;
using KeePassLib;
using KeePassLib.Serialization;

namespace KeePassQuery
{
	public class KPDatabase : IDisposable
	{
		private static readonly string[] NATIVE_STRING_KEYS  = { "UUID", "Title", "URL", "Username", "Password", "Notes" };
		private static readonly string[] IGNORED_STRING_KEYS_SUFFIX  = { "_etm_template_", "_etm_options_", "_etm_position_", "_etm_title_", "_etm_type_", "veracrypt." };

		private readonly SQLiteConnection _conn;
		private readonly IPluginHost _host;

		public KPDatabase(IPluginHost h)
		{
			_conn = new SQLiteConnection("Data Source=:memory:");
			_conn.Open();
			_host = h;
		}

		public void Dispose()
		{
			if (_conn != null) _conn.Close();
		}

		public void InitData()
		{
			var dm = _host.MainWindow.DocumentManager;

			var opt = new KPQOptions();//TODO;

			InitData("Entries", new[]{"UUID"}, ListAllEntries(dm, opt, false).Select(e => GetFields(dm, e.Item1, e.Item2, opt)));

			InitData("History", new[]{"UUID", "Timestamp_UTC"}, ListAllEntries(dm, opt, true).Select(e => GetFields(dm, e.Item1, e.Item2, opt)));

			InitData("Groups", new[]{"UUID"}, ListAllGroups(dm, opt).Select(e => GetFields(dm, e.Item1, e.Item2, opt)));

			InitData("Databases", new[]{"ID"}, ListAllDatabases(dm, opt).Select(e => GetFields(dm, e, opt)));
		}

		private void InitData(string tablename, string[] pkey, IEnumerable<Dictionary<string, string>> entries)
		{
			var data = entries.ToList();

			var columns = data.SelectMany(d => d.Keys).Distinct().ToList();

			var tabcreate = "CREATE TABLE ["+tablename+"] ("+string.Join(", ", columns.Select(c => "["+c+"] TEXT"))+", PRIMARY KEY("+string.Join(", ", pkey.Select(k => "["+k+"]"))+"))";
			Execute(tabcreate);
			
			var tabinsert = "INSERT INTO ["+tablename+"] ("+string.Join(", ", columns.Select(c => "["+c+"]"))+") VALUES ("+string.Join(", ", columns.Select((p,i)=>":"+i))+")";

			var tract = _conn.BeginTransaction();
			foreach (var dat in data) Execute(tabinsert, GetFieldData(dat, columns) );
			tract.Commit();
		}

		private string[] GetFieldData(IReadOnlyDictionary<string, string> dat, IEnumerable<string> columns)
		{
			return columns.Select(c => dat.ContainsKey(c) ? dat[c] : null).ToArray();
		}

		private void Execute(string sql)
		{
			//File.AppendAllText(@"F:\log.txt", "\n" + sql + "\n");
			using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
			{
				cmd.ExecuteNonQuery();
			}
		}

		private void Execute(string sql, params string[] p)
		{
			//File.AppendAllText(@"F:\log.txt", "\n" + sql + "\n{\n"+string.Join("\n", p.Select(pp => "    " + "[\""+pp+"\"]"))+"\n}\n");
			using (var cmd = new SQLiteCommand(sql, _conn))
			{
				for (var i = 0; i < p.Length; i++) cmd.Parameters.Add(i.ToString(), DbType.String).Value = p[i];
				cmd.ExecuteNonQuery();
			}
		}
		
		private IEnumerable<Tuple<PwDatabase, PwEntry>> ListAllEntries(DocumentManagerEx mng, KPQOptions opt, bool history)
		{
			if (opt.OnlyUseActiveDatabase)
			{
				return ListAllEntries(mng.ActiveDatabase.RootGroup, opt, history)
						.Select(p=>Tuple.Create(mng.ActiveDatabase, p));
			}
			else
			{
				return mng.Documents
						.Select(p => p.Database)
						.SelectMany(d => ListAllEntries(d.RootGroup, opt, history).Select(p=>Tuple.Create(d, p)));

			}
		}

		private IEnumerable<PwEntry> ListAllEntries(PwGroup group, KPQOptions opt, bool history)
		{
			foreach (var entry in group.Entries)
			{
				yield return entry;
				if (history) foreach (var old in entry.History) yield return old;
			}

			foreach (var g in group.GetGroups(false)) foreach (var entry in ListAllEntries(g, opt, history)) yield return entry;
		}
		
		private IEnumerable<Tuple<PwDatabase, PwGroup>> ListAllGroups(DocumentManagerEx mng, KPQOptions opt)
		{
			if (opt.OnlyUseActiveDatabase)
			{
				return ListAllGroups(mng.ActiveDatabase.RootGroup, opt)
					.Select(p=>Tuple.Create(mng.ActiveDatabase, p));
			}
			else
			{
				return mng.Documents
					.Select(p => p.Database)
					.SelectMany(d => ListAllGroups(d.RootGroup, opt).Select(p=>Tuple.Create(d, p)));

			}
		}
		
		private IEnumerable<PwGroup> ListAllGroups(PwGroup group, KPQOptions opt)
		{
			yield return group;
			foreach (var g in group.GetGroups(false)) foreach (var entry in ListAllGroups(g, opt)) yield return entry;
		}
		
		private IEnumerable<Tuple<IOConnectionInfo, PwDatabase>> ListAllDatabases(DocumentManagerEx mng, KPQOptions opt)
		{
			return mng.Documents.Select(p => Tuple.Create(p.LockedIoc, p.Database));
		}

		public DataTable Query(string sql)
		{
			using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					var result = new DataTable();
					for (int i = 0; i < reader.FieldCount; i++) result.Columns.Add(new DataColumn(reader.GetName(i)));

					while (reader.Read())
					{
						var row = result.NewRow();
						for (int i = 0; i < reader.FieldCount; i++)
						{
							row[i] = reader.GetFieldValue<object>(i);
						}
						result.Rows.Add(row);
					}
					return result;
				}
			}
		}
		
		private Dictionary<string, string> GetFields(DocumentManagerEx mng, PwDatabase db, PwEntry e, KPQOptions opt)
		{
			var result = new Dictionary<string, string>();

			result["UUID"]             = e.Uuid.ToHexString();
			result["Timestamp_UTC"]    = e.LastModificationTime.ToUniversalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["Title"]            = e.Strings.ReadSafe("Title");
			result["URL"]              = e.Strings.ReadSafe("URL");
			result["Username"]         = e.Strings.ReadSafe("UserName");
			result["Password"]         = opt.AllowQueryPasswords ? e.Strings.ReadSafe("Password") : "***";
			result["Notes"]            = e.Strings.ReadSafe("Notes");

			result["BackgroundColor"]  = ColorToString(e.BackgroundColor);
			result["ForegroundColor"]  = ColorToString(e.ForegroundColor);
			result["Binaries_Count"]   = e.Binaries.UCount.ToString();
			result["Binaries"]         = string.Join("; ", e.Binaries.Select(p => p.Key));
			result["Icon_ID"]          = e.CustomIconUuid == null ? ((int)e.IconId).ToString() : e.CustomIconUuid.ToHexString();
			result["Icon_IsCustom"]    = e.CustomIconUuid != null ? "true" : "false";
			
			result["Parent_Name"]      = e.ParentGroup.Name;
			result["Parent_UUID"]      = e.ParentGroup.Uuid.ToHexString();
			result["Path_Names"]       = GetPath(e, p => p.Name, "/");
			result["Path_UUIDs"]       = GetPath(e, p => p.Uuid.ToHexString(), "/");

			result["Database_Name"]    = db.Name;
			result["Database_ID"]      = GetIndex(mng, db).ToString();
			
			result["Timestamp_Local"]  = e.LastModificationTime.ToLocalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["Timestamp_Unix"]   = GetUnixTimestamp(e.LastModificationTime).ToString();
			result["Creation_UTC"]     = e.LastModificationTime.ToUniversalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["Creation_Local"]   = e.CreationTime.ToLocalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["Creation_Unix"]    = GetUnixTimestamp(e.CreationTime).ToString();
			result["LastAccess_UTC"]   = e.LastAccessTime.ToUniversalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["LastAccess_Local"] = e.LastAccessTime.ToLocalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["LastAccess_Unix"]  = GetUnixTimestamp(e.LastAccessTime).ToString();

			foreach (var str in e.Strings)
			{
				if (NATIVE_STRING_KEYS.Contains(str.Key)) continue;
				if (IGNORED_STRING_KEYS_SUFFIX.Any(sfx => str.Key.StartsWith(sfx))) continue;

				result["Field_" + CleanStringForColumnKey(str.Key)] = str.Value.ReadString();
			}

			if (opt.SupportPluginEntryTemplates)
			{
				//TODO
			}

			if (opt.SupportPluginKeePassRPC)
			{
				//TODO
			}

			return result;
		}
		
		private Dictionary<string, string> GetFields(DocumentManagerEx mng, PwDatabase db, PwGroup e, KPQOptions opt)
		{
			var result = new Dictionary<string, string>();

			result["UUID"]            = e.Uuid.ToHexString();
			result["Name"]            = e.Name;
			
			result["Icon_ID"]         = e.CustomIconUuid == null ? ((int)e.IconId).ToString() : e.CustomIconUuid.ToHexString();
			result["Icon_IsCustom"]   = e.CustomIconUuid != null ? "true" : "false";

			result["Notes"]           = e.Notes;
			result["Entry_Count"]     = e.Entries.Count().ToString();
			result["Depth"]           = GetDepth(e).ToString();

			result["Database_Name"]   = db.Name;
			result["Database_ID"]     = GetIndex(mng, db).ToString();
			
			result["Timestamp_UTC"]   = e.LastModificationTime.ToUniversalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["Timestamp_Local"]  = e.LastModificationTime.ToLocalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["Timestamp_Unix"]   = GetUnixTimestamp(e.LastModificationTime).ToString();
			result["Creation_UTC"]     = e.LastModificationTime.ToUniversalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["Creation_Local"]   = e.CreationTime.ToLocalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["Creation_Unix"]    = GetUnixTimestamp(e.CreationTime).ToString();
			result["LastAccess_UTC"]   = e.LastAccessTime.ToUniversalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["LastAccess_Local"] = e.LastAccessTime.ToLocalTime().ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
			result["LastAccess_Unix"]  = GetUnixTimestamp(e.LastAccessTime).ToString();

			return result;
		}

		private Dictionary<string, string> GetFields(DocumentManagerEx mng, Tuple<IOConnectionInfo, PwDatabase> e, KPQOptions opt)
		{
			var result = new Dictionary<string, string>();

			result["ID"]                   = GetIndex(mng, e.Item2).ToString();

			result["Name"]                 = e.Item2.Name;
			result["Description"]          = e.Item2.Description;
			result["Color"]                = ColorToString(e.Item2.Color);
			result["RootGroup_Name"]       = e.Item2.RootGroup.Name;
			result["RootGroup_UUID"]       = e.Item2.RootGroup.Uuid.ToHexString();
			result["Compression"]          = e.Item2.Compression.ToString();
			result["EntryTemplatesGroup"]  = e.Item2.EntryTemplatesGroup != null ? e.Item2.EntryTemplatesGroup.ToHexString() : null;

			result["Path"]                 = e.Item1.Path;

			return result;
		}

		private long GetUnixTimestamp(DateTime t)
		{
			return (int)(t.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		}

		private int GetIndex(DocumentManagerEx mng, PwDatabase db)
		{
			for (int i = 0; i < mng.Documents.Count; i++)
			{
				if (mng.Documents[i].Database == db) return (i+1);
			}
			return -1;
		}

		private int GetDepth(PwGroup g)
		{
			int d = 0;
			while (g.ParentGroup != null) { d++; g = g.ParentGroup; }
			return d;
		}

		private string GetPath(PwEntry e, Func<PwGroup, string> sel, string delim)
		{
			var glist = new List<PwGroup>();

			var g = e.ParentGroup;
			glist.Add(g);
			for (;;)
			{
				g = g.ParentGroup;
				if (g == null) break;
				glist.Add(g);
			}

			return string.Join(delim, glist.Select(sel));
		}

		private string CleanStringForColumnKey(string key)
		{
			key = key.Replace("[", "");
			key = key.Replace("]", "");
			return key;
		}

		private string ColorToString(Color c)
		{
			return "#" +
				Convert.ToString(c.R, 16).ToUpper().PadLeft(2, '0') + 
				Convert.ToString(c.G, 16).ToUpper().PadLeft(2, '0') + 
				Convert.ToString(c.B, 16).ToUpper().PadLeft(2, '0');
		}
	}
}
