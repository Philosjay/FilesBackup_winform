using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FilesBackup_winform.Backupable;
using System.IO;
using System.Collections.Generic;

namespace UnitTestProject
{

    [TestClass]
    public class TestDirectoryTrie
    {
        [TestMethod]
        public void TestNode()
        {
            // setup
            String rootDir = ".\\root";
            String folder1 = rootDir + "\\" + "folder1";
            String file0 = rootDir + "\\" + "file0.txt";

            DirectoryTrieBackupable.TrieNode rootNode = new DirectoryTrieBackupable.TrieNode(new FolderBackupable(rootDir));
            rootNode.AddChild(new DirectoryTrieBackupable.TrieNode(new FolderBackupable(folder1)));
            rootNode.AddChild(new DirectoryTrieBackupable.TrieNode(new FileBackupable(file0)));


            // run test
            Assert.AreEqual(rootNode.GetChildren().Count, 2);
            Assert.AreEqual(rootNode.GetChildren()[0].GetKey(), "folder1");
            Assert.AreEqual(rootNode.GetChildren()[1].GetKey(), "file0.txt");
            Assert.AreEqual(rootNode.GetChildren()[0].GetChildren().Count, 0);
            Assert.AreEqual(rootNode.GetChildren()[1].GetChildren().Count, 0);



        }

        /**
         * 把指定的目录作为根目录，生成测试用的目录
         * 
         * 测试目录如下：
         * .\\rootDir
         * .\\rootDir\\folder1
         * .\\rootDir\\folder2
         * .\\rootDir\\folder2\\file2.txt
         * .\\rootDir\\file0.txt
         *
         * 
         **/
        private void CreateTestDirectory(string rootDir)
        {
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

        /**
         * 
         * 测试能否以指定目录作为根目录，生成该目录的Trie
         * 
         * 
         **/
        [TestMethod]
        public void TestInitTrie()
        {
            // setup

            String rootDir = "root";
            CreateTestDirectory(rootDir);




            // run test
            /**
             * 将MockTrieInit 替换为DirectoryTrieBackupable 即可进行真实测试
             * 
             **/
            DirectoryTrieBackupable trie = new MockTrieInit(rootDir);
            DirectoryTrieBackupable.TrieNode root = trie.GetRoot();
            BackupableOnDisk rootContent = root.GetValue();

            Assert.AreEqual(rootContent.GetName(), rootDir);
            Assert.IsTrue(rootContent.IsExist());
            List<DirectoryTrieBackupable.TrieNode> rootChildren = root.GetChildren();
            Assert.AreEqual(rootChildren.Count, 3);

            List<String> rootChildKey = new List<string>();
            DirectoryTrieBackupable.TrieNode folder1Node = null;
            DirectoryTrieBackupable.TrieNode folder2Node = null;
            DirectoryTrieBackupable.TrieNode file0Node = null;
            for (int i = 0; i < 3; i++)
            {
                rootChildKey.Add(rootChildren[i].GetKey());
                switch (rootChildren[i].GetKey())
                {
                    case "folder1":
                        folder1Node = rootChildren[i];
                        break;
                    case "folder2":
                        folder2Node = rootChildren[i];
                        break;
                    case "file0.txt":
                        file0Node = rootChildren[i];
                        break;
                }
            }
            Assert.IsNotNull(folder1Node);
            Assert.IsNotNull(folder2Node);
            Assert.IsNotNull(file0Node);

            Assert.IsTrue(folder1Node.GetValue().IsExist());
            Assert.IsTrue(folder2Node.GetValue().IsExist());
            Assert.IsTrue(file0Node.GetValue().IsExist());

            Assert.AreEqual(folder1Node.GetChildren().Count, 0);
            Assert.AreEqual(folder2Node.GetChildren().Count, 1);
            Assert.AreEqual(file0Node.GetChildren().Count, 0);

            Assert.AreEqual(folder2Node.GetChildren()[0].GetKey(), "file2.txt");


            if (Directory.Exists(rootDir))
            {
                Directory.Delete(rootDir, true);
            }

        }


        [TestMethod]
        public void TestBackupTrie()
        {
            // setup
            String rootDir = "root";
            String backupDir = "backup";
            CreateTestDirectory(rootDir);

            // clean
            if (Directory.Exists(backupDir))
            {
                Directory.Delete(backupDir, true);
                Directory.CreateDirectory(backupDir);
            }



            // run test
            /**
             * MockTrieMakeBackupTo 替换为DirectoryTrieBackupable 即可进行真实测试
             * 
             **/
            DirectoryTrieBackupable trie = new MockTrieMakeBackupTo(rootDir);
            trie.MakeBackupTo(backupDir);



            Assert.IsTrue(new DirectoryInfo(backupDir + "\\root").Exists);
            Assert.IsTrue(new DirectoryInfo(backupDir + "\\root\\folder1").Exists);
            Assert.IsTrue(new DirectoryInfo(backupDir + "\\root\\folder2").Exists);
            Assert.IsTrue(new FileInfo(backupDir + "\\root\\file0.txt").Exists);
            Assert.IsTrue(new FileInfo(backupDir + "\\root\\folder2\\file2.txt").Exists);

            // clean
            if (Directory.Exists(rootDir))
            {
                Directory.Delete(rootDir, true);
            }
            if (Directory.Exists(backupDir))
            {
                Directory.Delete(backupDir, true);
            }

        }
    }
}
