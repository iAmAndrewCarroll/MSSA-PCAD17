using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinkedList
{
    // SINGLE LINKED LIST
    // Can be made into HouseNode for Assignment 6.1
    class Node // 2 parts : data , next (ref to next node)
    {
        // Make these into a house class
        // public int HouseNumber { get; set }
        // public string Address { get; set }
        // public string Type { get; set }

        public int data;
        public Node next;
        // Node newnode = new Node(30, null)

        // Constructor
        public Node(int val, Node next)
        {
            this.data = val;
            this.next = next;
        }
    }

    class customList  // customized linked list we are creating
    {
        // never give access to head / tail to client code
        // they could then be modified and access to list is gone
        private Node head;
        private Node tail;
        private int size;

        public int Size // read only variable for client code
        {
            get { return size; }
        }

        // initial list Constructor
        public customList()
        {
            this.head = null;  // head is a ref
            this.tail = null;  // tail is a ref
            this.size = 0;
        }

        // check if list is empty : true false
        public bool IsEmpty()
        {
            return this.size == 0;
        }

        // add first node to empty list
        // O(1) 
        public void AddFirst(int val) // add to front : method signature
        {
            Node newNode = new Node(val, null); // new node creation
            if (IsEmpty())  // if list is empty, new node is the only one in list
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = this.head;  // point next link of newNode to existing head
                this.head = newNode; // update head
            }
            size++;
        }

        // Time Complexity : O(n)
        public void Display()
        {
            Node temp = head;
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
            }
            else
            {
                while (temp != null)
                {
                    if (temp.next != null)
                    {
                        Console.Write(temp.data + "--->");
                    }
                    else
                    {
                        Console.WriteLine(temp.data); // last node, does not print arrow
                    }
                    temp = temp.next;
                }
            }
        }

        // O(1) : no loops
        public void AddLast(int val)
        {
            Node newNode = new Node(val, null);
            if (IsEmpty())
            {
                this.head = newNode;
                //this.tail = newNode;
            }
            else
            {
                this.tail.next = newNode;
                //this.tail = newNode;
            }
            this.tail = newNode;  // updating tail more 'cleanly'
            this.size++;  // because we are adding a node
        }

        // 12 23 45 --> 23 45
        // Time Complexity : O(1)
        public int RemoveFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty! Cannot remove.");
                return -1;
            }
            else
            {
                int val = head.data; // hold the value before we return : 12
                head = head.next;
                this.size--;
                if (IsEmpty()) // there was only 1 node which was removed
                {
                    tail = null;
                }
                return val;  // return : 12
            }
        }

        // Time Complexity : O(n)
        public int RemoveLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty! Cannot remove.");
                return -1;
            }
            Node temp = head;
            int i = 1;

            while (i < size - 1) // to to second to last node
            {
                temp = temp.next;
                i++;
            }
            tail = temp; // tail is now the second to last node
            // next 2 steps : return data from removed last node
            temp = temp.next;
            int val = temp.data;
            tail.next = null;
            return val;
        }

        // Time Complexity : O(n)
        public bool Search(int val, out int index)
        {
            Node temp = head;
            int i = 1;
            while (temp != null)
            {
                if (temp.data == val)
                {
                    index = i;
                    return true;
                }
                temp = temp.next;
                i++;
            }
            index = -1;
            return false;
        }
        // Time Complexity : O(n)
        // -1, 0 are both invalid positions
        // 10 elements in link list
        // could add an 11th element because position > size + 1
        // cannot skip 11 to add to a 12th element
        public void AddAnywhere(int data, int position)
        {
            if (position <= 0 || position > size + 1)
            {
                Console.WriteLine("Invalid position");
                return;
            }
            if (position == 1)
            {
                AddFirst(data);
                return;
            }
            if (position == size + 1)
            {
                AddLast(data);
                return;
            }
            Node newNode = new Node(data, null);
            Node temp = head;
            int i = 1;
            while(i < position - 1)
            {
                temp = temp.next;
                i++;
            }
            newNode.next = temp.next;
            temp.next = newNode;
            size++;
        }

        public int RemoveAnywhere(int position)
        {
            if (position <= 0 || position > this.size)
            {
                Console.WriteLine("Invalid position");
                return -1;
            }
            if (position == 1)
            {
                return RemoveFirst();
            }
            if (position == this.size)
            {
                return RemoveLast();
            }

            Node temp = head;
            int i = 1;
            while (i < position - 1)
            {
                temp = temp.next;
                i++;
            }
            int data = temp.next.data; // the value to be returned / removed

            temp.next = temp.next.next;  // skips the node in between
            size--;
            return data;
        }
    }
}
