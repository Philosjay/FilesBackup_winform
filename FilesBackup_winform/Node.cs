using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesBackup_winform.Tree
{
    public class Node<T>
    {

        private List<Node<T>> children = new List<Node<T>>();
        private T content;

        public  Node(T content){
            this.content = content;
        }

        public void SetContent(T content)
        {
            this.content = content;
        }

        public T GetContent()
        {
            return content;
        }

        public List<Node<T>> GetChildren()
        {
            return children;
        }

        public void AddChild(Node<T> newChild)
        {
            children.Add(newChild);
        }

    }
}
