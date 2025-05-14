using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3
{
    /*
     * Assignment 6.3 
     * 
     * restate the problem : 
     * Manage a call queue of customers using the Queue in C#. 
     * Creates a queue of callers
     * Demonstrates the functionality of :
     * - enqueueing elements into the queue  
     * - iterating over the elements 
     * - Dequeuing elements
     * 
     * Use linked lists :
     * - created with an internal class Node 
     * 
     * step through :
     * Linked List : create an internal Node class 
     * declare public variables by data type and name
     * assign relationship between data : next to int val, Node next
     * public override ToString() : return data
     * 
     * create Queue : Q
     * Queue has now a Node class that can be assigned front : rear values
     * create a size variable for elements in the queue
     * check if IsEmpty() : size is 0
     * 
     * create an Enqueue integer val : check if IsEmpty ? true : front becomes newNode 
     * : else the queue is not empty and rear.next = newNode
     * in either case rear becomes newNode
     * size increments : size++;
     * 
     * Here we could put a success message : 
     * Customer {val} has been Enqueued (Added) to Linked List Queue.  
     * \nSize: {size}  
     * \nFront: {front} 
     * \nRear: {this.rear}"
     * 
     * create a nullable Dequeue() method : int? Dequeue()
     * if IsEmpty ? true : Queue is empty : return null;
     * declare an integer value = front data;
     * assign front = front.next;
     * decrement size : size--;
     * Now check again if IsEmpty after decrementing size ? true : rear becomes null;
     * IsEmpty ? false : Item {val} has been Enqueued (Added) to Linked List Queue.  
     * \nSize: {size}  \nFront: {front} \nRear: {this.rear}"
     * 
     * create a Display() to write the data to console via main
     * need to create a value placeholder for front : Node temp = front;
     * check if !IsEmpty() : while temp != null : print temp.data + " "; : temp becomes temp.next
     * if the Queue was empty, print "Queue is empty."
     * 
     * Call it all in Main(string[] args)
     * Queue<string> customers = new Queue<string>();
     * 
     * pseudo code :
     * class Node
     * - public int data: public Node next;
     * - public Node(int val, Node next){this data = val; this next = next;}
     * override string ToString(){return data.ToString();}
     * 
     * class Q
     * Declare : Node front; Node rear; int size;
     * 
     * bool IsEmpty(){return this size == 0;}
     * 
     * Enqueue(int val){Node newNode = new Node(val, null); if Empty ? true : front = newNode; else{rear.next = newNode;}
     * - rear becomes newNode; size++; success message
     * 
     * int? Dequeue(){if IsEmpty ? true : print Queue is empty; return null;}
     * assign int val = front data; front = front next; size--; 
     * check again if IsEmpty ? true : {rear = null;}
     * Now print a success message
     * return val;
     * 
     * Display() 
     * declare Node temp = front;
     * if !IsEmpty ? while true (temp != null){write temp data + " "; temp = temp.next; Spacing here
     * else{Write "Queue is empty.");
     * 
     * 
     * 
     */

    internal class Node
    {
        public int data;
        public Node next;
        public Node(int val, Node next)
        {
            this.data = val;
            this.next = next;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
    class Q
    {
        Node front;
        Node rear;
        int size;

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public void Enqueue(int val)
        {
            Node newNode = new Node(val, null);
            if (IsEmpty())
            {
                front = newNode;
            }
            else
            {
                rear.next = newNode;
            }
            rear = newNode;
            size++;
            Console.WriteLine($"\nCustomer {val} has been Enqueued (Added) to Linked List Queue.  " +
                $"\nSize: {size}  \nFront: {front} \nRear: {this.rear}");
        }

        public int? Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!");
                return null;
            }

            int val = front.data;
            front = front.next;
            size--;

            if (IsEmpty())
            {
                rear = null;
            }
            Console.WriteLine($"\nItem {val} has been Dequeued (removed) from Linked List Queue.  " +
                $"\nSize: {this.size}  " +
                $"\nFront: {this.front} " +
                $"\nRear: {this.rear}");
            return val;
        }

        public void Display()
        {
            Node temp = front;
            if (!IsEmpty())
            {
                while (temp != null)
                {
                    Console.WriteLine(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Queue is empty.");
            }
        }

        public string GetFront()
        {
            return front != null ? front.ToString() : "null";
        }

        public string GetRear()
        {
            return rear != null ? rear.ToString() : "null";
        }
    }
}
