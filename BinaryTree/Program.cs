using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            var bst = new Bst<int>();

            var random = new Random();
            for (var i = 0; i < 10; i++)
            {
                var num = random.Next(maxValue:100, minValue:1);
                bst.Push(num);
            }

            bst.Traverse();

            bst.Reverse();


            var bstString = new Bst<string>();
            bstString.Push("Liz");
            bstString.Push("Cisco");
            bstString.Push("Mike");
            bstString.Push("Trevor");
            bstString.Push("Gwen");
            bstString.Push("Tyler");
            bstString.Push("Mia");
            bstString.Push("Dana");
            bstString.Push("Jeff");
            bstString.Push("Marisol");

            bstString.Traverse();

        }
    }

    class Node<T> where T : IComparable
    {
        public T Data { get; set; } 
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public Node()
        {
            Left = null;
            Right = null;
        }
    }


    class Bst<T> where T : IComparable
    {
        private Node<T> _root = null;

        public Bst()
        {
            _root = new Node<T>();
            _root.Right = null;
            _root.Left = null;
        }

        public void Push(T data)
        {
            _root = Push(_root, data);
        }

        public Node<T> Push(Node<T> node, T data)
        {
            if (node == null)
            {
                node = new Node<T>(data);    
            }

            if (data.CompareTo(node.Data) > 0)
            {
                node.Right = Push(node.Right, data);
            }
            else if (data.CompareTo(node.Data) < 0)
            {
                node.Left = Push(node.Left,data);
            }

            return node;
        }

        public void Traverse()
        {
            Traverse(_root);
        }

        private void Traverse(Node<T> node)
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

        private void Reverse(Node<T> node)
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
