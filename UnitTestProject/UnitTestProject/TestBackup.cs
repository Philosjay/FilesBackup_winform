using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FilesBackup_winform.Backupable;
using System.IO;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TestBackup
    {

        /**
         *  测试将原文件备份到指定目录，文件名保留原文件名
         *
         **/
        [TestMethod]
        public void TestBackupFile()
        {
            String originFilePath = ".\\a.txt";
            String originFileName = "a.txt";
            String backupDir = ".\\backup";


            // setup
            if (!File.Exists(originFilePath))   // 创建测试文件
            {
                FileStream origin = File.Create(originFilePath);
                origin.Close();
            }
            if (Directory.Exists(backupDir))     // 删除已有备份
            {
                Directory.Delete(backupDir, true);
            }
            Directory.CreateDirectory(backupDir);    // 创建备份文件夹


            // run test
            FileBackupable filebBkup = new FileBackupable(originFilePath);

            filebBkup.MakeBackup(backupDir);

            Assert.IsTrue(File.Exists(backupDir + "\\" + originFileName));

            // clean
            if (File.Exists(originFilePath))   // 删除测试文件
            {
                File.Delete(originFilePath);
            }
            if (Directory.Exists(backupDir))     // 删除已有备份
            {
                Directory.Delete(backupDir, true);
            }

        }


        [TestMethod]
        public void TestBackupFolder()
        {
            String originDirectoryName = ".\\a";
            String destDirectoryName = ".\\backup";

            // setup
            if (!Directory.Exists(originDirectoryName))   // 创建测试目录
            {
                Directory.CreateDirectory(originDirectoryName);
            }
            if (Directory.Exists(destDirectoryName))   // 删除已有的备份目录
            {
                Directory.Delete(destDirectoryName,true);
            }

            DirectoryInfo info = new DirectoryInfo("./a");
            DirectoryInfo[] info2 = info.GetDirectories();

            FolderBackupable dirBkup = new FolderBackupable(originDirectoryName);
            dirBkup.MakeBackup(destDirectoryName);

            Assert.IsTrue(Directory.Exists(destDirectoryName + "\\" + originDirectoryName));

            // clean
            if (Directory.Exists(originDirectoryName))   // 删除测试目录
            {
                Directory.Delete(originDirectoryName);
            }
            if (Directory.Exists(destDirectoryName))   // 删除已有的备份目录
            {
                Directory.Delete(destDirectoryName,true);
            }

        }
    }
}
