using System;
using System.Collections.Generic;
using FilesBackup_winform.Tree;

namespace FilesBackup_winform.Backupable
{

    public class DirectoryTrieBackupable
    {
        public class TrieNode
        {
            private List<TrieNode> children = new List<TrieNode>();
            private BackupableOnDisk content = null;

            public TrieNode(BackupableOnDisk content)
            {
                this.content = content;
            }

            public String GetKey()
            {
                return content.GetName();
            }

            public BackupableOnDisk GetContent()
            {
                return content;
            }

            public List<TrieNode> GetChildren()
            {
                return children;
            }

            public void AddChild(TrieNode newChild)
            {
                children.Add(newChild);
            }
        }

        TrieNode root = null;

        /**
         * 根据指定目录作为根目录，生成一棵Trie
         * 
         * dirPath 指定
         */
        public DirectoryTrieBackupable(String dirPath)
        {

        }

        public TrieNode GetRoot()
        {
            return root;
        }
    }
}
