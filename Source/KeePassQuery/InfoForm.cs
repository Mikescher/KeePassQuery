using System;
using System.Windows.Forms;

namespace KeePassQuery
{
	public partial class InfoForm : Form
	{
		public InfoForm()
		{
			InitializeComponent();

			lblVersion.Text = KeePassQueryExt.VERSION.ToString();
		}

		private void label8_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.mikescher.com");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//TODO
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
