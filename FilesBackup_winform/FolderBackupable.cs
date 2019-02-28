using System;
using System.IO;

namespace FilesBackup_winform.Backupable
{
    public class FolderBackupable : BackupableOnDisk
    {
        public FolderBackupable(string path) : base(path)
        {
        }

        /**
* 将原目录备份到目标目录，目录名保留原名
* 
* destDirPath 目标目录
* 
*/
        public override void MakeBackup(string destDirPath)
        {
            Directory.CreateDirectory(destDirPath + "\\" + name);
        }

        public override void MakeBackup(string destDirPath, string backupName)
        {
            throw new NotImplementedException();
        }
    }
}
