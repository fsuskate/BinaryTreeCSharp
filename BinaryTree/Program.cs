using System;

namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            var bst = new Bst();

            var random = new Random();
            for (var i = 0; i < 10; i++)
            {
                var num = random.Next(maxValue:100, minValue:1);
                bst.Push(num);
            }

            bst.Traverse();

            bst.Reverse();
        }
    }

    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }


    class Bst
    {
        private Node _root = null;

        public Bst()
        {
            _root = new Node(-1);
            _root.Right = null;
            _root.Left = null;
        }

        public void Push(int data)
        {
            _root = Push(_root, data);
        }

        public Node Push(Node node, int data)
        {
            if (node == null)
            {
                node = new Node(data);    
            }

            if (data > node.Data)
            {
                node.Right = Push(node.Right, data);
            }
            else if (data < node.Data)
            {
                node.Left = Push(node.Left,data);
            }

            return node;
        }

        public void Traverse()
        {
            Traverse(_root);
        }

        private void Traverse(Node node)
        {
            if (node == null)
            {
                return;
            }

            Traverse(node.Left);

            Console.WriteLine(node.Data);

            Traverse(node.Right);
        }

        public void Reverse()
        {
            Reverse(_root);
        }

        private void Reverse(Node node)
        {
            if (node == null)
            {
                return;
            }

            Traverse(node.Right);

            Console.WriteLine(node.Data);

            Traverse(node.Left);
        }
    }
}
