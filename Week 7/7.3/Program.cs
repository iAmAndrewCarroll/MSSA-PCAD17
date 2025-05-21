using System;
using System.ComponentModel.Design;

namespace _7._3
{
    internal class Program
    {
        /*
         * 7.3.1 -  Binary Search Tree (BST) & int val
         * 
         * restate the problem :
         * 
         * given binary search tree (BST) root & int val
         * 
         * find BST node val == int val
         * 
         * return subtree rooted with that node
         * 
         * if BST node val != int val
         *      return null;
         *      
         * verbal logic step through :
         * 
         * New class Node : public int data: Node right; Node left;
         * 
         * Node() : int data, Node right, Node left) : this data, right, left
         * 
         * class BST : public Node root; public BST() constructor sets root = null
         * public instert node : Node temproot, int val of node to be inserted
         * Nodew newNode set to new Node : vall, null, null (starts as a leaf)
         * Node temp set to null;
         *
         * if root is not null --> 
         *  while temproot != null
         *     temp set to temproot;
         *     if temproot.data == val --> return b/c duplicate value
         *     else if val < temproot.data --> temproot set to .left
         *     else if val > temproot.data --> temproot set to .right
         *     
         *     when you reach the leaft temp will point at the leaft
         *     if val < temp.data --> set newNode to temp.left
         *     else if val > temp.data --> set newNode to temp.right
         *  else root = newNode and the tree was empty
         * 
         * boolean Search : int n
         *  Node temp set to root;
         *  while temp != null
         *      if temp.data == n : 
         *          return subtree rooted in n;
         *          
         *      else if n < temp.data : set temp = temp.left;
         *      else if n > temp.data : set temp = temp.right;
         *  return false;
         *  
         *  if Search == true : construct new In Order BST subtree of nodes rooted in n
         * 
         */

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

                public Node Find(int val)
                {
                    Node temp = root;

                    while (temp != null)
                    {
                        if (temp.data == val)
                        {
                            return temp;
                        }
                        else if (val < temp.data)
                        {
                            temp = temp.left;
                        }
                        else if (val > temp.data)
                        {
                            temp = temp.right;
                        }
                    }
                    return null;
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

                public void PrintDetailedTable()
                {
                    Console.WriteLine("Node   | Left   | Right  | Parent | Type");
                    Console.WriteLine("--------------------------------------------");
                    PrintDetailedRows(root, null);
                }

                public void PrintDetailedTable(Node subtreeRoot)
                {
                    Console.WriteLine("Node   | Left   | Right  | Parent | Type");
                    Console.WriteLine("--------------------------------------------");
                    PrintDetailedRows(subtreeRoot, null);
                }

                public void PrintDetailedTableInOrder(Node subtreeRoot)
                {
                    Console.WriteLine("Node   | Left   | Right  | Parent | Type");
                    Console.WriteLine("--------------------------------------------");
                    PrintDetailedRowsInOrder(subtreeRoot, null);
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

                private void PrintDetailedRowsInOrder(Node? node, Node? parent)
                {
                    if (node == null) return;

                    // Visit left first
                    PrintDetailedRowsInOrder(node.left, node);

                    // Then this node
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

                    // Then right
                    PrintDetailedRowsInOrder(node.right, node);
                }


                static void Main(string[] args)
                {
                    Console.WriteLine("-- 7.3.1 - Binary Search Tree, Search, Print found node as root with subtree. --");
                    Console.WriteLine();

                    BST tree = new BST();
                    tree.InsertNode(tree.root, 30);

                    tree.InsertNode(tree.root, 20);
                    tree.InsertNode(tree.root, 50);
                    tree.InsertNode(tree.root, 45);
                    tree.InsertNode(tree.root, 67);
                    tree.InsertNode(tree.root, 9);
                    //tree.Inorder(tree.root);

                    Console.WriteLine("Full Binary Search Tree:\n");
                    tree.PrintDetailedTable();
                    Console.WriteLine();

                    Console.WriteLine("Full Binary Search Tree In-Order:\n");
                    tree.PrintDetailedTableInOrder(tree.root);
                    Console.WriteLine();

                    int val1 = 50;
                    Node found1 = tree.Find(val1);
                    if (found1 != null)
                    {
                        Console.WriteLine($"Find [{val1}] as Root with Subtree:\n");
                        tree.PrintDetailedTable(found1);
                    }
                    else
                    {
                        Console.WriteLine($"Value [{val1}] not found in the tree.");
                    }

                    int val = 45;
                    Node found = tree.Find(val);
                    if (found != null)
                    {
                        Console.WriteLine($"Find [{val}] as Root with Subtree:\n");
                        tree.PrintDetailedTable(found);
                    }
                    else
                    {
                        Console.WriteLine($"Value [{val}] not found in the tree.");
                    }

                    Console.ReadKey();


                    //Console.WriteLine("\nInorder Traversal:");
                    //tree.Inorder(tree.root);
                    //Console.WriteLine();

                    //Console.WriteLine("\nPreOrder:");
                    //tree.PreOrder(tree.root);
                    //Console.WriteLine();

                    //Console.WriteLine("\nPostOrder:");
                    //tree.PostOrder(tree.root);
                    //Console.WriteLine();

                    //Console.ReadKey();
                }
            }
        }
    }
}