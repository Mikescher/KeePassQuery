using System;
using System.Windows.Forms;
using KeePass.Plugins;

namespace KeePassQuery
{
	public partial class SettingsForm : Form
	{
		private readonly IPluginHost _host;

		private readonly KPQOptions _config;

		public SettingsForm(IPluginHost host)
		{
			InitializeComponent();

			_host = host;
			_config = KPQOptions.Load(_host.Database);

			optEntryTemplatesPlugin.Checked    = _config.SupportPluginEntryTemplates;
			optKPRPCPlugin.Checked             = _config.SupportPluginKeePassRPC;
			optOnlyQueryActiveDatabase.Checked = _config.OnlyUseActiveDatabase;
			optShowPasswords.Checked           = _config.AllowQueryPasswords;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			_config.SupportPluginEntryTemplates = optEntryTemplatesPlugin.Checked;
			_config.SupportPluginKeePassRPC     = optKPRPCPlugin.Checked;
			_config.OnlyUseActiveDatabase       = optOnlyQueryActiveDatabase.Checked;
			_config.AllowQueryPasswords         = optShowPasswords.Checked;

			_config.Save(_host.Database);
			
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
