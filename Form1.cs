using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Consid.ProjectDeployTool
{
    public partial class MainForm : Form
    {
        private static List<FileInfo> fileList = new List<FileInfo>();
        private static DirectoryInfo sourceFolder;
        private static DirectoryInfo targetFolder;
        private static DirectoryInfo rollbackFolder;
        private FileDeployCollection data = new FileDeployCollection();

        public MainForm()
        {
            InitializeComponent();
            lstLogView.Items.Clear();
        }

        #region MainForm events

        private void btnSourceFolder_Click(object sender, EventArgs e)
        {
            // pre-select folder in dialog
            folderBrowserDialog1.SelectedPath = txtSourceFolder.Text;

            // get user result
            DialogResult result = folderBrowserDialog1.ShowDialog();

            // if user clicked ok, set new source folder
            if (result == DialogResult.OK)
            {
                txtSourceFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnTargetFolder_Click(object sender, EventArgs e)
        {
            // pre-select folder in dialog
            folderBrowserDialog1.SelectedPath = txtTargetFolder.Text;

            // get user result
            DialogResult result = folderBrowserDialog1.ShowDialog();

            // if user clicked ok, set new source folder
            if (result == DialogResult.OK)
            {
                txtTargetFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnDryRun_Click(object sender, EventArgs e)
        {
            Deploy(true);
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            Deploy(false);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        #endregion

        #region MainForm private methods

        private void ParseSourceFolder()
        {
            // clear previous file list
            fileList.Clear();

            // open folder
            try
            {
                sourceFolder = new DirectoryInfo(txtSourceFolder.Text);
            }
            catch (Exception e)
            {
                HandleError(e, "Invalid source folder");
                return;
            }

            ParseFolder(sourceFolder.FullName);

            StatusLabel.Text = "Done.";
        }

        private string GetRollbackFolder(bool DryRun)
        {
            int counter = 1;
            string rollbackFolderPath = sourceFolder.Parent.FullName + "\\rollback";

            // determine rollback folder
            while (Directory.Exists(rollbackFolderPath))
            {
                rollbackFolder = new DirectoryInfo(rollbackFolderPath);
                if (rollbackFolder.GetDirectories().Length == 0 && rollbackFolder.GetFiles().Length == 0)
                    break;
                rollbackFolderPath = string.Format(@"{0}\{1}_{2}", sourceFolder.Parent.FullName, "\\rollback", counter++);
            }

            // create rollback folder if doesn't exists
            if (!Directory.Exists(rollbackFolderPath))
            {
                if (!DryRun) Directory.CreateDirectory(rollbackFolderPath);
            }

            rollbackFolder = new DirectoryInfo(rollbackFolderPath);

            return rollbackFolderPath;
        }

        private void ParseFolder(string Path)
        {
            DirectoryInfo folder = new DirectoryInfo(Path);

            // update status label
            StatusLabel.Text = String.Format("Parsing folder {0}...", folder.FullName.Substring(sourceFolder.FullName.Length));
            this.Refresh();

            // enumerate through files
            foreach (FileInfo file in folder.GetFiles())
                fileList.Add(file);

            // enumerate through subfolders
            foreach (DirectoryInfo subfolder in folder.GetDirectories())
                ParseFolder(subfolder.FullName);            
        }

        private void Deploy(bool DryRun)
        {
            // read all files in source folder tree into fileList
            ParseSourceFolder();

            // clear log view
            lstLogView.Items.Clear();

            // clear data collection
            data.Clear();

            // save source folder
            data.SourceFolder = sourceFolder.FullName;

            // deploy
            string rollbackFolderPath = GetRollbackFolder(DryRun);

            // save rollback folder
            data.RollbackFolder = rollbackFolderPath;

            try
            {
                targetFolder = new DirectoryInfo(txtTargetFolder.Text);
            }
            catch (Exception e)
            {
                HandleError(e, "Invalid target folder");
                return;
            }

            // save target folder
            data.TargetFolder = targetFolder.FullName;

            foreach (FileInfo file in fileList)
            {

                string targetFolderPath = String.Format(
                    "{0}{1}", targetFolder.FullName, file.Directory.FullName.Substring(sourceFolder.FullName.Length));

                if (System.IO.File.Exists(Path.Combine(targetFolderPath, file.Name)))
                {
                    string backupFolderPath = String.Format(
                        "{0}{1}", rollbackFolder.FullName, file.Directory.FullName.Substring(sourceFolder.FullName.Length));

                    AddToLogView("replace", targetFolderPath.Substring(targetFolder.Parent.FullName.Length), file.Name, file.Directory.FullName.Substring(sourceFolder.Parent.FullName.Length), backupFolderPath.Substring(rollbackFolder.Parent.FullName.Length));

                    if (!DryRun)
                    {
                        BackupFile(file);
                        DeployFile(file);
                    }
                }
                else
                {
                    AddToLogView("new", targetFolderPath.Substring(targetFolder.Parent.FullName.Length), file.Name, file.Directory.FullName.Substring(sourceFolder.Parent.FullName.Length));

                    if (!DryRun)
                        DeployFile(file);
                }
            }


            if (!DryRun)
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());

                // Create an XmlTextWriter using a FileStream.
                Stream fs = new FileStream(Path.Combine(rollbackFolder.FullName, "rollbackLog.xml"), FileMode.Create);
                serializer.Serialize(fs, data);
                fs.Close();
            }
        }

        private void BackupFile(FileInfo file)
        {
            string backupPath = String.Format(
                "{0}{1}", rollbackFolder.FullName, file.Directory.FullName.Substring(sourceFolder.FullName.Length));

            string targetFilePath = String.Format(
                "{0}{1}", targetFolder.FullName, file.FullName.Substring(sourceFolder.FullName.Length));

            FileInfo targetFile = new FileInfo(targetFilePath);

            DirectoryInfo di = new DirectoryInfo(backupPath);

            if (!di.Exists)
                Directory.CreateDirectory(di.FullName);

            targetFile.CopyTo(Path.Combine(backupPath, targetFile.Name));
        }

        private void DeployFile(FileInfo file)
        {
            string targetFilePath = String.Format(
                "{0}{1}", targetFolder.FullName, file.FullName.Substring(sourceFolder.FullName.Length));

            FileInfo fi = new FileInfo(targetFilePath);

            if (!fi.Directory.Exists)
                Directory.CreateDirectory(fi.Directory.FullName);

            file.CopyTo(targetFilePath, true);
        }

        private void AddToLogView(string Action, string Target)
        {
            lstLogView.Items.Add(
                new ListViewItem(new string[] { Action, null, Target }));

            data.Add(new FileDeploy(Action, Target));

        }

        private void AddToLogView(string Action, string Target, string FileName)
        {
            lstLogView.Items.Add(
                new ListViewItem(new string[] { Action, null, Target, null, FileName }));

            this.data.Add(new FileDeploy(Action, Target, FileName));
        }

        private void AddToLogView(string Action, string Target, string FileName, string Source)
        {
            lstLogView.Items.Add(
                new ListViewItem(new string[] { Action, Source, Target, null, FileName }));

            this.data.Add(new FileDeploy(Action, Target, FileName, Source));
        }

        private void AddToLogView(string Action, string Target, string FileName, string Source, string Backup)
        {
            if (Path.GetExtension(FileName) == ".dll")
            {
                string newVersion = FileVersionInfo.GetVersionInfo(Path.Combine(Path.Combine(sourceFolder.FullName, @"..\" + Source), FileName)).FileVersion;
                string oldVersion = FileVersionInfo.GetVersionInfo(Path.Combine(Path.Combine(targetFolder.FullName, @"..\" + Target), FileName)).FileVersion;
                lstLogView.Items.Add(
                    new ListViewItem(new string[] { Action, Source, Target, Backup, FileName, oldVersion, newVersion }));
                this.data.Add(
                    new FileDeploy()
                    {
                        Action = Action,
                        Source = Source,
                        Target = Target,
                        Backup = Backup,
                        FileName = FileName,
                        OldVersion = oldVersion,
                        NewVersion = newVersion
                    });
            }
            else
            {
                lstLogView.Items.Add(
                    new ListViewItem(new string[] { Action, Source, Target, Backup, FileName }));

                this.data.Add(new FileDeploy(Action, Target, FileName, Source, Backup));
            }

        }

        private void HandleError(Exception e, string Caption)
        {
            MessageBox.Show(this, e.Message, Caption);
        }

        private void HandleError(Exception e)
        {
            MessageBox.Show(this, e.Message, "An error occured...");            
        }

        #endregion

    }
}