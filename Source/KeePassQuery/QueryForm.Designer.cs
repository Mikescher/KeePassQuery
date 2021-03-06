﻿namespace KeePassQuery
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.edSQL = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.resultView = new System.Windows.Forms.DataGridView();
			this.edError = new System.Windows.Forms.TextBox();
			this.btnInfo = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.btnConfig = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.resultView)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.tableLayoutPanel1.Controls.Add(this.btnRun, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnConfig, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnInfo, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.edSQL);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panel1.Size = new System.Drawing.Size(650, 26);
			this.panel1.TabIndex = 4;
			// 
			// edSQL
			// 
			this.edSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edSQL.Location = new System.Drawing.Point(0, 3);
			this.edSQL.Name = "edSQL";
			this.edSQL.Size = new System.Drawing.Size(650, 20);
			this.edSQL.TabIndex = 0;
			this.edSQL.Text = "SELECT * FROM Entries";
			this.edSQL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
			// 
			// panel2
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
			this.panel2.Controls.Add(this.resultView);
			this.panel2.Controls.Add(this.edError);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 35);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(794, 412);
			this.panel2.TabIndex = 5;
			// 
			// resultView
			// 
			this.resultView.AllowUserToAddRows = false;
			this.resultView.AllowUserToDeleteRows = false;
			this.resultView.AllowUserToOrderColumns = true;
			this.resultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.resultView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultView.Location = new System.Drawing.Point(0, 0);
			this.resultView.Name = "resultView";
			this.resultView.ReadOnly = true;
			this.resultView.Size = new System.Drawing.Size(794, 412);
			this.resultView.TabIndex = 1;
			// 
			// edError
			// 
			this.edError.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edError.ForeColor = System.Drawing.Color.Red;
			this.edError.Location = new System.Drawing.Point(0, 0);
			this.edError.Multiline = true;
			this.edError.Name = "edError";
			this.edError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.edError.Size = new System.Drawing.Size(794, 412);
			this.edError.TabIndex = 6;
			// 
			// btnInfo
			// 
			this.btnInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnInfo.Image = global::KeePassQuery.Properties.Resources.info;
			this.btnInfo.Location = new System.Drawing.Point(755, 3);
			this.btnInfo.Name = "btnInfo";
			this.btnInfo.Size = new System.Drawing.Size(42, 26);
			this.btnInfo.TabIndex = 6;
			this.btnInfo.UseVisualStyleBackColor = true;
			this.btnInfo.Click += new System.EventHandler(this.OnClickInfo);
			// 
			// btnRun
			// 
			this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRun.Image = global::KeePassQuery.Properties.Resources.run;
			this.btnRun.Location = new System.Drawing.Point(659, 3);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(42, 26);
			this.btnRun.TabIndex = 2;
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.OnClickRun);
			// 
			// btnConfig
			// 
			this.btnConfig.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnConfig.Image = global::KeePassQuery.Properties.Resources.cog;
			this.btnConfig.Location = new System.Drawing.Point(707, 3);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(42, 26);
			this.btnConfig.TabIndex = 3;
			this.btnConfig.UseVisualStyleBackColor = true;
			this.btnConfig.Click += new System.EventHandler(this.OnClickSettings);
			// 
			// QueryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "QueryForm";
			this.Text = "KeePassQuery";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.resultView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox edSQL;
		private System.Windows.Forms.DataGridView resultView;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnConfig;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox edError;
		private System.Windows.Forms.Button btnInfo;
	}
}