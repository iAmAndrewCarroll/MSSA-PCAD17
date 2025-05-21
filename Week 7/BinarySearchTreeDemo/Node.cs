using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeDemo
{
    class Node
    {
        public int data; // value in the node
        public Node right; // pointer --> right child
        public Node left; // pointer --> left child

        // this is the creation of a node : when it is created it doesn't yet have connection to any other nodes
        public Node(int data, Node right, Node left)
        {
            this.data = data;
            this.right = right;
            this.left = left;
        }

        public class BST
        {
            public Node root; // starting point
            public BST() // constructor
            {
                root = null;
            }
            // we will insert a new node with val 30
            public void InsertNode(Node temproot, int val) // int 'val' is the node value we are inserting
            {
                Node newNode = new Node(val, null, null); // every node starts as a leaf
                Node temp = null; // does the traversal ; preserves root reference
                if (root != null) // 30 was previously added --> now we add new node with val 20
                {
                    while (temproot != null)
                    {
                        temp = temproot;
                        if (temproot.data == val) // cannot add duplicates so return back
                            return;
                        else if (val < temproot.data)
                        {
                            temproot = temproot.left;
                        }
                        else if (val > temproot.data)
                        {
                            temproot = temproot.right;
                        }
                    }
                    // you have reached the leaf node, temp points to the leaf node
                    if (val < temp.data)
                    {
                        temp.left = newNode;
                    }
                    else if (val > temp.data)
                    {
                        temp.right = newNode;
                    }
                }
                else
                {
                    root = newNode; // tree was empty
                }
            }

            public bool Search(int n)
            {
                Node temp = root;

                while (temp != null)
                {
                    if (temp.data == n)
                    {
                        return true;
                    }
                    else if (n < temp.data)
                    {
                        temp = temp.left;
                    }
                    else if (n > temp.data)
                    {
                        temp = temp.right;
                    }
                }
                return false;
            }

            public void Inorder(Node temproot)
            {
                if (temproot != null)
                {
                    Inorder(temproot.left);
                    Console.Write(temproot.data + " ");
                    Inorder(temproot.right);

                }
            }
            public void PreOrder(Node temproot)
            {
                if (temproot != null)
                {
                    Console.Write(temproot.data + " ");
                    PreOrder(temproot.left);
                    PreOrder(temproot.right);
                }
            }
            public void PostOrder(Node temproot)
            {
                if (temproot != null)
                {
                    PostOrder(temproot.left);
                    PostOrder(temproot.right);
                    Console.Write(temproot.data + " ");
                }
            }
            public void PrintDetailedTable()
            {
                Console.WriteLine("Node   | Left   | Right  | Parent | Type");
                Console.WriteLine("--------------------------------------------");
                PrintDetailedRows(root, null);
            }

            private void PrintDetailedRows(Node? node, Node? parent)
            {
                if (node == null) return;

                string nodeVal = $"[{node.data}]";
                string leftVal = node.left != null ? $"[{node.left.data}]" : "null";
                string rightVal = node.right != null ? $"[{node.right.data}]" : "null";
                string parentVal = parent != null ? $"[{parent.data}]" : "null";

                string type;
                if (parent == null)
                    type = "Root";
                else if (node.left == null && node.right == null)
                    type = "Leaf";
                else
                    type = "Internal";

                Console.WriteLine($"{nodeVal.PadRight(7)}| {leftVal.PadRight(7)}| {rightVal.PadRight(7)}| {parentVal.PadRight(7)}| {type}");

                PrintDetailedRows(node.left, node);
                PrintDetailedRows(node.right, node);
            }
        }
    }
}
