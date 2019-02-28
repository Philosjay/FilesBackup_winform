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

        [TestMethod]
        public void TestInitTrie()
        {
            // setup
            String rootDir = "root";
            String folder1 = rootDir + "\\" + "folder1";
            String folder2 = rootDir + "\\" + "folder2";
            String file0 = rootDir+ "\\" + "file0.txt";
            String file2 = folder2 + "\\" + "file2.txt";

            if (Directory.Exists(rootDir))
            {
                Directory.Delete(rootDir, true);
            }

            Directory.CreateDirectory(folder1);
            Directory.CreateDirectory(folder2);
            File.Create(file0);
            File.Create(file2);


            DirectoryTrieBackupable trie = new DirectoryTrieBackupable(rootDir);

            // run test
            DirectoryTrieBackupable.TrieNode root = trie.GetRoot();
            BackupableOnDisk rootContent = root.GetContent();

            Assert.Equals(rootContent.GetName(), rootDir);
            List<DirectoryTrieBackupable.TrieNode> rootChildren = root.GetChildren();
            Assert.Equals(rootChildren.Count, 3);

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
                        folder1Node = rootChildren[i];
                        break;
                    case "file0.txt":
                        folder1Node = rootChildren[i];
                        break;
                }
            }
            Assert.IsNotNull(folder1Node);
            Assert.IsNotNull(folder2Node);
            Assert.IsNotNull(file0Node);

            Assert.AreEqual(folder1Node.GetChildren().Count, 0);
            Assert.AreEqual(folder2Node.GetChildren().Count, 1);
            Assert.AreEqual(file0Node.GetChildren().Count, 0);

            Assert.AreEqual(folder2Node.GetChildren()[0].GetKey(), "file2.txt");




        }
    }
}
