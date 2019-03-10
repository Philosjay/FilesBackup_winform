using FilesBackup_winform.Backupable;


namespace UnitTestProject
{
    class MockTrieInit : DirectoryTreeBackupable
    {
        public MockTrieInit(string dirPath) : base(dirPath)
        {

            root = new Node(new FolderBackupable("root"));

            FolderBackupable folder1 = new FolderBackupable("root\\folder1");
            FolderBackupable folder2 = new FolderBackupable("root\\folder2");
            FileBackupable file0 = new FileBackupable("root\\file0.txt");
            FileBackupable file2 = new FileBackupable("root\\folder2\\file2.txt");

            Node folder2Node = new Node(folder2);
            folder2Node.AddChild(new Node(file2));

            root.AddChild(new Node(folder1));
            root.AddChild(folder2Node);
            root.AddChild(new Node(file0));

        }
    }
}
