using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Consid.ProjectDeployTool
{
    public enum ActionEnum { Replace, New }

    [XmlType(TypeName="filelist")]
    public class FileDeployCollection : List<FileDeploy>
    {
        private string _sourceFolder;
        private string _targetFolder;
        private string _rollbackFolder;

        public FileDeployCollection() { }

        public FileDeployCollection(string SourceFolder, string TargetFolder, string RollbackFolder)
        {
            this.SourceFolder = SourceFolder;
            this.TargetFolder = TargetFolder;
            this.RollbackFolder = RollbackFolder;
        }

        [XmlElement(ElementName="source")]
        public string SourceFolder
        {
            get { return _sourceFolder; }
            set { _sourceFolder = value; }
        }

        [XmlElement(ElementName="target")]
        public string TargetFolder
        {
            get { return _targetFolder; }
            set { _targetFolder = value; }
        }

        [XmlElement(ElementName="rollback")]
        public string RollbackFolder
        {
            get { return _rollbackFolder; }
            set { _rollbackFolder = value; }
        }
    }

    [XmlType(TypeName="file")]
    public class FileDeploy
    {
        string _action;
        string _source;
        string _target;
        string _backup;
        string _fileName;
        string _oldVersion;
        string _newVersion;

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }
        public string Backup
        {
            get { return _backup; }
            set { _backup = value; }
        }
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string OldVersion
        {
            get { return _oldVersion; }
            set { _oldVersion = value; }
        }

        public string NewVersion
        {
            get { return _newVersion; }
            set { _newVersion = value; }
        }



        public FileDeploy(string Action, string Target)
        {
            this.Action = Action;
            this.Target = Target;
        }

        public FileDeploy()
        {

        }

        public FileDeploy(string Action, string Target, string FileName)
        {
            this.Action = Action;
            this.Target = Target;
            this.FileName = FileName;
        }

        public FileDeploy(string Action, string Target, string FileName, string Source)
        {
            this.Action = Action;
            this.Target = Target;
            this.FileName = FileName;
            this.Source = Source;
        }

        public FileDeploy(string Action, string Target, string FileName, string Source, string Backup)
        {
            this.Action = Action;
            this.Target = Target;
            this.FileName = FileName;
            this.Source = Source;
            this.Backup = Backup;
        }
    }
}
