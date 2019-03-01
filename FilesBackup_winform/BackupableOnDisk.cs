using System;
using System.IO;

namespace FilesBackup_winform.Backupable
{
    abstract public class BackupableOnDisk : IBackupable 
    {
        protected FileSystemInfo info = null;


        public BackupableOnDisk(FileSystemInfo info)
        {
            this.info = info;
        }


        public String GetName()
        {
            return info.Name;
        }

        public DateTime GetLastWriteTime()
        {
            return info.LastWriteTime;
        }

        public bool IsExist()
        {
            return info.Exists;
        }

        abstract public void MakeBackup(string destDirPath);


        abstract public void MakeBackup(string destDirPath, string backupName);

    }
}
