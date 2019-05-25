namespace KeePassQuery
{
	partial class SettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.optShowPasswords = new System.Windows.Forms.CheckBox();
			this.optKPRPCPlugin = new System.Windows.Forms.CheckBox();
			this.optOnlyQueryActiveDatabase = new System.Windows.Forms.CheckBox();
			this.optEntryTemplatesPlugin = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(208, 225);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(127, 225);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// optShowPasswords
			// 
			this.optShowPasswords.AutoSize = true;
			this.optShowPasswords.Location = new System.Drawing.Point(12, 12);
			this.optShowPasswords.Name = "optShowPasswords";
			this.optShowPasswords.Size = new System.Drawing.Size(147, 17);
			this.optShowPasswords.TabIndex = 2;
			this.optShowPasswords.Text = "Allow querying passwords";
			this.optShowPasswords.UseVisualStyleBackColor = true;
			// 
			// optKPRPCPlugin
			// 
			this.optKPRPCPlugin.AutoSize = true;
			this.optKPRPCPlugin.Location = new System.Drawing.Point(12, 35);
			this.optKPRPCPlugin.Name = "optKPRPCPlugin";
			this.optKPRPCPlugin.Size = new System.Drawing.Size(209, 17);
			this.optKPRPCPlugin.TabIndex = 3;
			this.optKPRPCPlugin.Text = "Enable support for KeepassRPC plugin";
			this.optKPRPCPlugin.UseVisualStyleBackColor = true;
			// 
			// optOnlyQueryActiveDatabase
			// 
			this.optOnlyQueryActiveDatabase.AutoSize = true;
			this.optOnlyQueryActiveDatabase.Location = new System.Drawing.Point(12, 81);
			this.optOnlyQueryActiveDatabase.Name = "optOnlyQueryActiveDatabase";
			this.optOnlyQueryActiveDatabase.Size = new System.Drawing.Size(219, 17);
			this.optOnlyQueryActiveDatabase.TabIndex = 4;
			this.optOnlyQueryActiveDatabase.Text = "Only use active database as data source";
			this.optOnlyQueryActiveDatabase.UseVisualStyleBackColor = true;
			// 
			// optEntryTemplatesPlugin
			// 
			this.optEntryTemplatesPlugin.AutoSize = true;
			this.optEntryTemplatesPlugin.Location = new System.Drawing.Point(12, 58);
			this.optEntryTemplatesPlugin.Name = "optEntryTemplatesPlugin";
			this.optEntryTemplatesPlugin.Size = new System.Drawing.Size(219, 17);
			this.optEntryTemplatesPlugin.TabIndex = 5;
			this.optEntryTemplatesPlugin.Text = "Enable support for EntryTemplates plugin";
			this.optEntryTemplatesPlugin.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(295, 260);
			this.Controls.Add(this.optEntryTemplatesPlugin);
			this.Controls.Add(this.optOnlyQueryActiveDatabase);
			this.Controls.Add(this.optKPRPCPlugin);
			this.Controls.Add(this.optShowPasswords);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "KeePassQuery settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox optShowPasswords;
		private System.Windows.Forms.CheckBox optKPRPCPlugin;
		private System.Windows.Forms.CheckBox optOnlyQueryActiveDatabase;
		private System.Windows.Forms.CheckBox optEntryTemplatesPlugin;
	}
}