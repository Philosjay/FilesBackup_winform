using System;

namespace FilesBackup_winform.Backupable
{
    abstract public class BackupableOnDisk : IBackupable 
    {
        protected String path = "";
        protected String name = "";

        public BackupableOnDisk(String path)
        {
            this.path= path;
            name = path.Substring(path.LastIndexOf("\\")+1);
        }


        public void SetPath(String path)
        {
            this.path = path;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public String GetName()
        {
            return name;
        }

        abstract public void MakeBackup(string destDirPath);


        abstract public void MakeBackup(string destDirPath, string backupName);

    }
}
