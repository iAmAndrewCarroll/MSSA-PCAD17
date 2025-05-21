using BinarySearchTreeDemo;
using static BinarySearchTreeDemo.Node;

namespace BinarySearchTreeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();
            tree.InsertNode(tree.root, 30);

            tree.InsertNode(tree.root, 20);
            tree.InsertNode(tree.root, 50);
            tree.InsertNode(tree.root, 45);
            tree.InsertNode(tree.root, 67);
            tree.InsertNode(tree.root, 9);
            tree.Inorder(tree.root);

            Console.WriteLine("Binary Search Tree (rotated 90 degrees):\n");
            tree.PrintDetailedTable();
            Console.WriteLine();

            Console.WriteLine("\nInorder Traversal:");
            tree.Inorder(tree.root);
            Console.WriteLine();

            Console.WriteLine("\nPreOrder:");
            tree.PreOrder(tree.root);
            Console.WriteLine();

            Console.WriteLine("\nPostOrder:");
            tree.PostOrder(tree.root);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}