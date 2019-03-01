using System;
using System.IO;

namespace FilesBackup_winform.Backupable
{
    public class FolderBackupable : BackupableOnDisk
    {
        /**
         * 根据目录的路径生成目录描述信息，存到成员变量info中
         * 
         **/
        public FolderBackupable(string path) : base(new DirectoryInfo(path))
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
            Directory.CreateDirectory(destDirPath + "\\" + info.Name);
        }

        /**
         * 将原文件备份到目标目录，文件名用指定文件名
         * 
         * destDirPath     目标目录
         * backupName   新的文件名
         * 
         */
        public override void MakeBackup(string destDirPath, string backupName)
        {
            Directory.CreateDirectory(destDirPath + "\\" + backupName);
        }
    }
}
