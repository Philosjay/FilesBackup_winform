using System;
using System.Collections.Generic;

namespace FilesBackup_winform.Backupable
{

    public class DirectoryTreeBackupable
    {
        public class Node
        {
            private List<Node> children = new List<Node>();
            private BackupableOnDisk value = null;

            public Node(BackupableOnDisk content)
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

            public List<Node> GetChildren()
            {
                return children;
            }

            public void AddChild(Node newChild)
            {
                children.Add(newChild);
            }
        }

        protected Node root = null;

        /**
         * 根据指定目录作为根目录，生成一棵Trie
         * 
         * dirPath 指定根目录路径
         */
        public DirectoryTreeBackupable(String dirPath)
        {

        }


        /**
         * 
         * 根据指定目录作为目标目录，采用完全备份方式备份该Trie
         * 
         * destDir 目标目录路径
         * 
         **/
        virtual public void MakeFullBackup(String destDir)
        {

        }

        /**
         * 
         * 根据指定目录作为目标目录，采用增量备份方式备份该Trie
         * 
         * destDir      目标目录路径
         * lastRecord   上次备份的情况
         * 
         **/
        virtual public void MakeIncrementalBackup(String destDir, DirectoryTreeBackupable lastRecord)
        {

        }

        public Node GetRoot()
        {
            return root;
        }
    }
}
