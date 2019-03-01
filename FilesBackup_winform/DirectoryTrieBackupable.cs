using System;
using System.Collections.Generic;

namespace FilesBackup_winform.Backupable
{

    public class DirectoryTrieBackupable
    {
        public class TrieNode
        {
            private List<TrieNode> children = new List<TrieNode>();
            private BackupableOnDisk value = null;

            public TrieNode(BackupableOnDisk content)
            {
                this.value = content;
            }

            public string GetKey()
            {
                return value.GetName();
            }

            public BackupableOnDisk GetValue()
            {
                return value;
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

        protected TrieNode root = null;

        /**
         * 根据指定目录作为根目录，生成一棵Trie
         * 
         * dirPath 指定根目录路径
         */
        public DirectoryTrieBackupable(String dirPath)
        {

        }


        /**
         * 
         * 根据指定目录作为目标目录，备份该Trie
         * 
         * destDir 目标目录路径
         * 
         **/
        virtual public void MakeBackupTo(String destDir)
        {

        }

        public TrieNode GetRoot()
        {
            return root;
        }
    }
}
