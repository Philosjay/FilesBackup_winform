using FilesBackup_winform.Backupable;


namespace UnitTestProject
{
    class MockTrieInit : DirectoryTrieBackupable
    {
        public MockTrieInit(string dirPath) : base(dirPath)
        {

            root = new TrieNode(new FolderBackupable("root"));

            FolderBackupable folder1 = new FolderBackupable("root\\folder1");
            FolderBackupable folder2 = new FolderBackupable("root\\folder2");
            FileBackupable file0 = new FileBackupable("root\\file0.txt");
            FileBackupable file2 = new FileBackupable("root\\folder2\\file2.txt");

            TrieNode folder2Node = new TrieNode(folder2);
            folder2Node.AddChild(new TrieNode(file2));

            root.AddChild(new TrieNode(folder1));
            root.AddChild(folder2Node);
            root.AddChild(new TrieNode(file0));

        }
    }
}
