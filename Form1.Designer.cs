namespace Consid.ProjectDeployTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSourceFolder = new System.Windows.Forms.Button();
            this.lblSourceFolder = new System.Windows.Forms.Label();
            this.lblTargetFolder = new System.Windows.Forms.Label();
            this.btnTargetFolder = new System.Windows.Forms.Button();
            this.btnDryRun = new System.Windows.Forms.Button();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstLogView = new System.Windows.Forms.ListView();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Target = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Backup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OldVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSourceFolder
            // 
            this.btnSourceFolder.Location = new System.Drawing.Point(436, 25);
            this.btnSourceFolder.Name = "btnSourceFolder";
            this.btnSourceFolder.Size = new System.Drawing.Size(24, 20);
            this.btnSourceFolder.TabIndex = 0;
            this.btnSourceFolder.Text = "...";
            this.btnSourceFolder.UseVisualStyleBackColor = true;
            this.btnSourceFolder.Click += new System.EventHandler(this.btnSourceFolder_Click);
            // 
            // lblSourceFolder
            // 
            this.lblSourceFolder.AutoSize = true;
            this.lblSourceFolder.Location = new System.Drawing.Point(12, 9);
            this.lblSourceFolder.Name = "lblSourceFolder";
            this.lblSourceFolder.Size = new System.Drawing.Size(73, 13);
            this.lblSourceFolder.TabIndex = 2;
            this.lblSourceFolder.Text = "Source folder:";
            // 
            // lblTargetFolder
            // 
            this.lblTargetFolder.AutoSize = true;
            this.lblTargetFolder.Location = new System.Drawing.Point(12, 48);
            this.lblTargetFolder.Name = "lblTargetFolder";
            this.lblTargetFolder.Size = new System.Drawing.Size(70, 13);
            this.lblTargetFolder.TabIndex = 5;
            this.lblTargetFolder.Text = "Target folder:";
            // 
            // btnTargetFolder
            // 
            this.btnTargetFolder.Location = new System.Drawing.Point(436, 64);
            this.btnTargetFolder.Name = "btnTargetFolder";
            this.btnTargetFolder.Size = new System.Drawing.Size(24, 20);
            this.btnTargetFolder.TabIndex = 3;
            this.btnTargetFolder.Text = "...";
            this.btnTargetFolder.UseVisualStyleBackColor = true;
            this.btnTargetFolder.Click += new System.EventHandler(this.btnTargetFolder_Click);
            // 
            // btnDryRun
            // 
            this.btnDryRun.Location = new System.Drawing.Point(10, 90);
            this.btnDryRun.Name = "btnDryRun";
            this.btnDryRun.Size = new System.Drawing.Size(75, 23);
            this.btnDryRun.TabIndex = 7;
            this.btnDryRun.Text = "&Dry run";
            this.btnDryRun.UseVisualStyleBackColor = true;
            this.btnDryRun.Click += new System.EventHandler(this.btnDryRun_Click);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 450);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(964, 22);
            this.StatusStrip1.TabIndex = 8;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // lstLogView
            // 
            this.lstLogView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Action,
            this.Source,
            this.Target,
            this.Backup,
            this.File,
            this.OldVersion,
            this.NewVersion});
            this.lstLogView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstLogView.GridLines = true;
            this.lstLogView.Location = new System.Drawing.Point(0, 128);
            this.lstLogView.Name = "lstLogView";
            this.lstLogView.Size = new System.Drawing.Size(964, 322);
            this.lstLogView.TabIndex = 9;
            this.lstLogView.UseCompatibleStateImageBehavior = false;
            this.lstLogView.View = System.Windows.Forms.View.Details;
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(91, 90);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(75, 23);
            this.btnDeploy.TabIndex = 10;
            this.btnDeploy.Text = "Deplo&y";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Location = new System.Drawing.Point(172, 90);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(75, 23);
            this.btnRollback.TabIndex = 11;
            this.btnRollback.Text = "&Rollback";
            this.btnRollback.UseVisualStyleBackColor = true;
            // 
            // Action
            // 
            this.Action.Text = "Action";
            this.Action.Width = global::Consid.ProjectDeployTool.Properties.Settings.Default.ActionColumnWidth;
            // 
            // Source
            // 
            this.Source.Text = "Source";
            this.Source.Width = global::Consid.ProjectDeployTool.Properties.Settings.Default.SourceColumnWidth;
            // 
            // Target
            // 
            this.Target.Text = "Target";
            this.Target.Width = global::Consid.ProjectDeployTool.Properties.Settings.Default.TargetColumnWidth;
            // 
            // Backup
            // 
            this.Backup.Text = "Backup";
            this.Backup.Width = global::Consid.ProjectDeployTool.Properties.Settings.Default.BackupColumnWidth;
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = global::Consid.ProjectDeployTool.Properties.Settings.Default.FileColumnWidth;
            // 
            // OldVersion
            // 
            this.OldVersion.Text = "Old version";
            this.OldVersion.Width = global::Consid.ProjectDeployTool.Properties.Settings.Default.OldVersionColumnWidth;
            // 
            // NewVersion
            // 
            this.NewVersion.Text = "New version";
            this.NewVersion.Width = global::Consid.ProjectDeployTool.Properties.Settings.Default.NewVersionColumnWidth;
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Consid.ProjectDeployTool.Properties.Settings.Default, "TargetFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTargetFolder.Location = new System.Drawing.Point(12, 64);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(418, 20);
            this.txtTargetFolder.TabIndex = 4;
            this.txtTargetFolder.Text = global::Consid.ProjectDeployTool.Properties.Settings.Default.TargetFolder;
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Consid.ProjectDeployTool.Properties.Settings.Default, "SourceFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourceFolder.Location = new System.Drawing.Point(12, 25);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(418, 20);
            this.txtSourceFolder.TabIndex = 1;
            this.txtSourceFolder.Text = global::Consid.ProjectDeployTool.Properties.Settings.Default.SourceFolder;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 472);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.lstLogView);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.btnDryRun);
            this.Controls.Add(this.lblTargetFolder);
            this.Controls.Add(this.txtTargetFolder);
            this.Controls.Add(this.btnTargetFolder);
            this.Controls.Add(this.lblSourceFolder);
            this.Controls.Add(this.txtSourceFolder);
            this.Controls.Add(this.btnSourceFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Consid Deploy Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSourceFolder;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label lblSourceFolder;
        private System.Windows.Forms.Label lblTargetFolder;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Button btnTargetFolder;
        private System.Windows.Forms.Button btnDryRun;
        private System.Windows.Forms.StatusStrip StatusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ListView lstLogView;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader Source;
        public System.Windows.Forms.ColumnHeader Target;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.ColumnHeader Backup;
        private System.Windows.Forms.ColumnHeader OldVersion;
        private System.Windows.Forms.ColumnHeader NewVersion;
    }
}

