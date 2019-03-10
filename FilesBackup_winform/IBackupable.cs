using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesBackup_winform.Backupable
{
    interface IBackupable
    {
        /**
         * 在指定目录备份，保留原名
         * 
         **/
        void MakeBackup(String destDirPath);

        /**
         * 在指定目录备份，用新的名字替换原名
         * 
         **/
        void MakeBackup(String destDirPath, String backupName);
    }
}
