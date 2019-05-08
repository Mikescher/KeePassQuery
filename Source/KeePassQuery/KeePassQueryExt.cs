using System;
using System.Windows.Forms;

using KeePass.Forms;
using KeePass.Plugins;
using KeePass.Resources;
using KeePass.UI;

using KeePassLib;
using KeePassLib.Security;
using KeePassLib.Utility;

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
			// Provide a menu item for the main location(s)
			if(t == PluginMenuType.Main)
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem();
				tsmi.Text = "Abcd Options";
				tsmi.Click += this.OnOptionsClicked;
				return tsmi;
			}

			return null; // No menu items in other locations
		}

		private void OnOptionsClicked(object sender, EventArgs e)
		{
			// Called when the menu item is clicked
		}

		public override void Terminate()
		{
			base.Terminate();
		}
	}
}
