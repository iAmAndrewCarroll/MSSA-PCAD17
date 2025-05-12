using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
    /*
     * Restate the problem:
     * Implement singly linked list nodes : houses
     * data : house number, brief address, type (ranch, colonial, town)
     * each node linked to next
     * give user house number search
     * display results
     * 
     * Step Through
     * create an empty single linked list Houses
     * create a house class : int HouseNumber, string Address, string Type
     * implement AddFirst/Last/Anywhere, RemoveFirst/Last/Anywhere, Search
     * Display Results
     * prompt user for search
     * return results
     * 
     * psuedo code
     * class HouseNode : public House data, House Node next
     * - public HouseNode Constructor : House house, HouseNode next
     * - this.data = house : this.next = next
     * 
     * class House
     * - public int HouseNumber : string Address : string Type { get; set }
     * - public House(int number, string address, string type)
     * - override strint ToString : {HouseNumber}, {Address}, {Type}
     * 
     * Modified all code from in class demo to fit assignment 6.1
     * 
     *
     * 
     */
    class HouseNode // 2 parts : data , next (ref to next node)
    {

        public House data;
        public HouseNode next;
        // Node newnode = new Node(30, null)

        // Constructor
        public HouseNode(House house, HouseNode next)
        {
            this.data = house;
            this.next = next;
        }
    }

    class House
    {
        public int HouseNumber {  get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public House(int number, string address, string type)
        {
            HouseNumber = number;
            Address = address;
            Type = type;
        }

        public override string ToString()
        {
            return $"House #{HouseNumber}, {Address}, Type: {Type}";
        }
    }

    class customList  // customized linked list we are creating
    {
        // never give access to head / tail to client code
        // they could then be modified and access to list is gone
        private HouseNode head;
        private HouseNode tail;
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
        public void AddFirst(House house) // add to front : method signature
        {
            HouseNode newNode = new HouseNode(house, null); // new node creation
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
            HouseNode temp = head;
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
                        Console.WriteLine(temp.data + "--->");
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
        public void AddLast(House house)
        {
            HouseNode newNode = new HouseNode(house, null);
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
        public House RemoveFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty! Cannot remove.");
                return null;
            }
            else
            {
                House removed = head.data; // hold the value before we return : 12
                head = head.next;
                this.size--;

                if (IsEmpty()) // there was only 1 node which was removed
                {
                    tail = null;
                }
                return removed;  // return : 12
            }
        }

        // Time Complexity : O(n)
        public House RemoveLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty! Cannot remove.");
                return null;
            }

            if (head == tail) // only one node
            {
                House removed = head.data;
                head = null;
                tail = null;
                size--;
                return removed;
            }

            HouseNode temp = head;
            while (temp.next != tail)
            {
                temp = temp.next;
            }

            House removedhouse = tail.data;
            tail = temp;
            tail.next = null;
            return removedhouse;
        }

        // Time Complexity : O(n)
        public bool Search(int houseNumber, out int index)
        {
            HouseNode temp = head;
            int i = 1;
            while (temp != null)
            {
                if (temp.data.HouseNumber == houseNumber)
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
        public void AddAnywhere(House house, int position)
        {
            if (position <= 0 || position > size + 1)
            {
                Console.WriteLine("Invalid position");
                return;
            }
            if (position == 1)
            {
                AddFirst(house);
                return;
            }
            if (position == size + 1)
            {
                AddLast(house);
                return;
            }
            HouseNode newNode = new HouseNode(house, null);
            HouseNode temp = head;
            int i = 1;

            while (i < position - 1)
            {
                temp = temp.next;
                i++;
            }

            newNode.next = temp.next;
            temp.next = newNode;
            size++;
        }

        public House RemoveAnywhere(int position)
        {
            if (position <= 0 || position > this.size)
            {
                Console.WriteLine("Invalid position");
                return null;
            }
            if (position == 1)
            {
                return RemoveFirst();
            }
            if (position == this.size)
            {
                return RemoveLast();
            }

            HouseNode temp = head;
            int i = 1;
            while (i < position - 1)
            {
                temp = temp.next;
                i++;
            }
            House removedHouse = temp.next.data; // the value to be returned / removed
            Console.WriteLine($"Removed: {removedHouse}");

            temp.next = temp.next.next;  // skips the node in between
            size--;
            return removedHouse;
        }
    }
}
