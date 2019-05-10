using System;
using System.Windows.Forms;

using KeePass.Plugins;

namespace KeePassQuery
{
	public class KeePassQueryExt : Plugin
	{
		//public override Image SmallIcon { get { return Properties.Resources.icon; } }

		//public override string UpdateUrl { get { return "https://github.com/....../keepass.version"; } }

		private IPluginHost _pluginHost;

		public override bool Initialize(IPluginHost host)
		{
			if (host == null) return false;
			_pluginHost = host;

			return true;
		}
		
		public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
		{
			if(t != PluginMenuType.Main) return null;

			ToolStripMenuItem tsmi = new ToolStripMenuItem();
			tsmi.Text = "KeePassQuery";
			tsmi.Click += this.OnOptionsClicked;
			return tsmi;
		}

		private void OnOptionsClicked(object sender, EventArgs e)
		{
			var db = new KPDatabase(_pluginHost);
			db.InitData();

			QueryForm qf = new QueryForm(db);
			qf.Show();
		}

		public override void Terminate()
		{
			base.Terminate();
		}
	}
}
