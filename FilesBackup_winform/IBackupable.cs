using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesBackup_winform.Backupable
{
    interface IBackupable
    {
        void MakeBackup(String destDirPath);

        void MakeBackup(String destDirPath, String backupName);
    }
}
