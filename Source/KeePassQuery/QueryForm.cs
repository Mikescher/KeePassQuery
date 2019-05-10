using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeePassQuery
{
	public partial class QueryForm : Form
	{
		private readonly KPDatabase _db;

		public QueryForm(KPDatabase db)
		{
			InitializeComponent();
			typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, resultView, new object[] { true });

			_db = db;
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			try
			{
				var sql = edSQL.Text;

				var data = _db.Query(sql);

				resultView.DataSource = data;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
		}
	}
}
