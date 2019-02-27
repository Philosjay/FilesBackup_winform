using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FilesBackup_winform.Tree;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TestTree
    {
        [TestMethod]
        public void TestConstructTree()
        {
            Node<Int32> root = new Node<Int32>(0);

            root.AddChild(new Node<Int32>(1));
            root.AddChild(new Node<Int32>(2));

            Node<Int32> tmp = new Node<Int32>(3);
            tmp.AddChild(new Node<Int32>(4));
            tmp.AddChild(new Node<Int32>(5));

            root.AddChild(tmp);




            Assert.AreEqual(0, root.GetContent());
            Assert.AreEqual(3, root.GetChildren().Count());


            int[] contents = { 1, 2, 3 };
            List<int> childrenContent = new List<int>(contents);
            Node<Int32> child3 = null;
            foreach (Node<Int32> child in root.GetChildren()) { 

                Assert.IsTrue(childrenContent.Contains(child.GetContent()));

                if (child.GetContent() == 3)
                    child3 = child;
            }

            Assert.AreEqual(3, child3.GetContent());
            Assert.AreEqual(2, child3.GetChildren().Count());

            int[] contents2 = { 4,5 };
            List<int> childrenContent2 = new List<int>(contents2);
            foreach (Node<Int32> child in child3.GetChildren())
            {

                Assert.IsTrue(childrenContent2.Contains(child.GetContent()));
            }

        }
    }
}
