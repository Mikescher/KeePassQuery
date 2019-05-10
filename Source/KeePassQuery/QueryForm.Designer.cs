namespace KeePassQuery
{
	partial class QueryForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.edSQL = new System.Windows.Forms.TextBox();
			this.resultView = new System.Windows.Forms.DataGridView();
			this.btnRun = new System.Windows.Forms.Button();
			this.btnConfig = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.resultView)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.edSQL, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.resultView, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnRun, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnConfig, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// edSQL
			// 
			this.edSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edSQL.Location = new System.Drawing.Point(3, 3);
			this.edSQL.Name = "edSQL";
			this.edSQL.Size = new System.Drawing.Size(632, 20);
			this.edSQL.TabIndex = 0;
			this.edSQL.Text = "SELECT * FROM Entries";
			// 
			// resultView
			// 
			this.resultView.AllowUserToAddRows = false;
			this.resultView.AllowUserToDeleteRows = false;
			this.resultView.AllowUserToOrderColumns = true;
			this.resultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableLayoutPanel1.SetColumnSpan(this.resultView, 3);
			this.resultView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultView.Location = new System.Drawing.Point(3, 32);
			this.resultView.Name = "resultView";
			this.resultView.ReadOnly = true;
			this.resultView.Size = new System.Drawing.Size(794, 415);
			this.resultView.TabIndex = 1;
			// 
			// btnRun
			// 
			this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRun.Location = new System.Drawing.Point(641, 3);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(75, 23);
			this.btnRun.TabIndex = 2;
			this.btnRun.Text = "R";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// btnConfig
			// 
			this.btnConfig.Location = new System.Drawing.Point(722, 3);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(75, 23);
			this.btnConfig.TabIndex = 3;
			this.btnConfig.Text = "S";
			this.btnConfig.UseVisualStyleBackColor = true;
			// 
			// QueryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "QueryForm";
			this.Text = "QueryForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.resultView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox edSQL;
		private System.Windows.Forms.DataGridView resultView;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnConfig;
	}
}