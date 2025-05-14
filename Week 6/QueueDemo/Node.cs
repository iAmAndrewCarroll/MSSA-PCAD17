using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
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
        Node front; // head
        Node rear; // tail
        int size; // how many elements present in the queue

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public void Enqueue(int val) // addLast O(1)
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
            Console.WriteLine($"Item {val} has been Enqueued (Added) to Linked List Queue.  \nSize: {size}  \nFront: {front} \nRear: {this.rear}");
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
            Console.WriteLine($"Item {val} has been Dequeued (removed) from Linked List Queue.  \nSize: {this.size}  \nFront: {this.front} \nRear: {this.rear}");
            return val;
        }

        public void Display()
        {
            Node temp = front;
            if (!IsEmpty())
            {
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Queue is empty.");
            }
        }
    }
}
