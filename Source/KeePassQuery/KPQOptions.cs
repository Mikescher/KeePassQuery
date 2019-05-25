using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeePassLib;

namespace KeePassQuery
{
	public class KPQOptions
	{
		private const string DATA_KEY = "com.mikescher.KeePassQuery.config";

		public bool AllowQueryPasswords = false;
		public bool SupportPluginKeePassRPC = true;
		public bool SupportPluginEntryTemplates = true;
		public bool OnlyUseActiveDatabase = true;

		private KPQOptions() { }

		public static KPQOptions Load(PwDatabase db)
		{
			var kpq = new KPQOptions();

			var data = db.CustomData.Exists(DATA_KEY) ? db.CustomData.Get(DATA_KEY) : string.Empty;

			foreach (var line in data.Split('\n'))
			{
				if (string.IsNullOrWhiteSpace(line)) continue;

				var split = line.Split(new []{" ::= "}, StringSplitOptions.None);
				if (split.Length != 2) continue;

				var key = split[0];
				var val = split[1];

				switch (key)
				{
					case "AllowQueryPasswords":         kpq.AllowQueryPasswords         = (val == "1"); break;
					case "SupportPluginKeePassRPC":     kpq.SupportPluginKeePassRPC     = (val == "1"); break;
					case "SupportPluginEntryTemplates": kpq.SupportPluginEntryTemplates = (val == "1"); break;
					case "OnlyUseActiveDatabase":       kpq.OnlyUseActiveDatabase       = (val == "1"); break;
					default: break;
				}
			}

			return kpq;
		}

		public void Save(PwDatabase db)
		{
			var builder = new StringBuilder();

			builder.Append("AllowQueryPasswords").Append(" ::= ").Append(AllowQueryPasswords?1:0).Append('\n');
			builder.Append("SupportPluginKeePassRPC").Append(" ::= ").Append(SupportPluginKeePassRPC?1:0).Append('\n');
			builder.Append("SupportPluginEntryTemplates").Append(" ::= ").Append(SupportPluginEntryTemplates?1:0).Append('\n');
			builder.Append("OnlyUseActiveDatabase").Append(" ::= ").Append(OnlyUseActiveDatabase?1:0).Append('\n');

			db.CustomData.Set(DATA_KEY, builder.ToString());
		}
	}
}
