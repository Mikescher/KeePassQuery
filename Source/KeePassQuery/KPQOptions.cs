using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeePassQuery
{
	class KPQOptions
	{
		public bool AllowQueryPasswords = false;
		public bool SupportPluginKeePassRPC = true;
		public bool SupportPluginEntryTemplates = true;
		public bool OnlyUseActiveDatabase = true;
	}
}
