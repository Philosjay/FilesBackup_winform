using System.IO;

namespace FilesBackup_winform.Backupable
{
    public class FileBackupable : BackupableOnDisk
    {

        /**
         * 根据文件的路径生成文件描述信息，存到成员变量info中
         * 
         **/
        public FileBackupable(string path) : base(new FileInfo(path))
        {

        }

        /**
        * 将原文件备份到目标目录，文件名保留原名
        * 
        * destDirPath 目标目录
        * 
        */
        public override void MakeBackup(string destDirPath)
        {
            File.Copy(info.FullName, destDirPath + "\\" + info.Name);
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
            File.Copy(info.FullName, destDirPath);
        }
    }
}
