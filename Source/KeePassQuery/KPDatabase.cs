using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using KeePass.Plugins;
using KeePassLib;

namespace KeePassQuery
{
	public class KPDatabase : IDisposable
	{
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
			Execute(@"CREATE TABLE 'Entries' ('UUID' TEXT, 'Title' TEXT, 'URL' TEXT, 'Username' TEXT, 'Password' TEXT, 'Notes' TEXT)");

			foreach (var entry in ListAllEntries(_host.Database.RootGroup))
			{
				Execute(
					@"INSERT INTO Entries (UUID, Title, URL, Username, Password, Notes) VALUES (:0, :1, :2, :3, :4, :5)",
					entry.Uuid.ToHexString(),
					entry.Strings.ReadSafe("Title"),
					entry.Strings.ReadSafe("URL"),
					entry.Strings.ReadSafe("Username"),
					entry.Strings.ReadSafe("Password"),
					entry.Strings.ReadSafe("Notes"));
			}
		}

		private void Execute(string sql)
		{
			using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
			{
				cmd.ExecuteNonQuery();
			}
		}

		private void Execute(string sql, params string[] p)
		{
			using (var cmd = new SQLiteCommand(sql, _conn))
			{
				for (var i = 0; i < p.Length; i++) cmd.Parameters.Add(i.ToString(), DbType.String).Value = p[i];
				cmd.ExecuteNonQuery();
			}
		}

		private IEnumerable<PwEntry> ListAllEntries(PwGroup group)
		{
			foreach (var entry in group.Entries) yield return entry;

			foreach (var g in group.GetGroups(false)) foreach (var entry in ListAllEntries(g)) yield return entry;
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
	}
}
