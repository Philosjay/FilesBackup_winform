

using System;
using System.IO;

namespace UnitTestProject
{
    class MockTrieMakeBackupTo : MockTrieInit
    {
        public MockTrieMakeBackupTo(string dirPath) : base(dirPath)
        {
        }

        public override void MakeBackupTo(string destDir)
        {
            String rootDir = destDir + "\\root";
            String folder1 = rootDir + "\\" + "folder1";
            String folder2 = rootDir + "\\" + "folder2";
            String file0 = rootDir + "\\" + "file0.txt";
            String file2 = folder2 + "\\" + "file2.txt";

            if (Directory.Exists(rootDir))
            {
                Directory.Delete(rootDir, true);
            }

            Directory.CreateDirectory(folder1);
            Directory.CreateDirectory(folder2);
            FileStream fileStream0 = File.Create(file0);
            FileStream fileStream2 = File.Create(file2);
            fileStream0.Close();
            fileStream2.Close();
        }
    }
}
