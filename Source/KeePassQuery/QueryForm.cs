using System;
using System.Data.SQLite;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using KeePass.Plugins;

namespace KeePassQuery
{
	public partial class QueryForm : Form
	{
		private readonly IPluginHost _host;
		private readonly KPDatabase _db;

		public QueryForm(KPDatabase db, IPluginHost host)
		{
			InitializeComponent();
			_db = db;
			_host = host;
			
			typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, resultView, new object[] { true });
			edError.ReadOnly = true;
			edError.BackColor = SystemColors.Window;
			resultView.Visible = true;
			edError.Visible = false;
		}

		private void OnClickRun(object sender, EventArgs e)
		{
			RunQuery();
		}

		private void OnClickSettings(object sender, EventArgs e)
		{
			new SettingsForm(_host).ShowDialog(this);
		}

		private void OnClickInfo(object sender, EventArgs e)
		{
			new InfoForm().ShowDialog(this);
		}

		private void OnKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				e.Handled = true;
				RunQuery();
			}
		}

		private void RunQuery()
		{
			try
			{
				//TODO check if db changed - and re-init

				var sql = edSQL.Text;

				var data = _db.Query(sql);

				resultView.DataSource = data;
				resultView.Visible = true;
				edError.Visible = false;
			}
			catch (SQLiteException ex)
			{
				edError.Text = ex.Message;
				resultView.Visible = false;
				edError.Visible = true;
			}
			catch (Exception ex)
			{
				edError.Text = ex.Message;
				resultView.Visible = false;
				edError.Visible = true;
			}
		}
	}
}
