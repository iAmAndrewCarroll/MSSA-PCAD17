using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    class Queue
    {
        private int[] data;  // declare array : no mem allocation until constructor
        private int front, rear, size;  // field of the Queue class : target with a this.size

        // constructor : mem is allocated
        public Queue(int size) // local size parameter
        {
            this.data = new int[size];  // max elements in array : size of array
            this.front = -1;
            this.rear = -1;
            this.size = 0; // how many elements are in the queue
        }

        public bool IsEmpty()
        {
            //Console.WriteLine("Queue is Empty");
            return this.size == 0;
        }

        public bool IsFull()
        {
            //Console.WriteLine("Queue is Full!  Cannot Add!");
            return this.rear == this.data.Length - 1;
        }

        public void Enqueue(int val)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full! Cannot add");
            }
            else
            {
                if (this.rear < this.data.Length - 1)
                    rear++;
                data[rear] = val;
                size++;
                Console.WriteLine($"Item {val} has been added to queue.  \nRear : {rear}  \nSize : {size}");
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Q is empty!");
                return -1;
            }
            else
            {
                front++;
                size--;
                int temp = data[front];
                if (IsEmpty())
                {
                    this.front = -1;
                    this.rear = -1;
                }
                Console.WriteLine($"Item {temp} removed from queue. \nFront: {front} \nRear: {rear}  \nSize: {size}");
                return temp;
            }
        }

        public void Display()
        {
            if (!IsEmpty())
            {
                for (int i = front + 1; i <= rear; i++)
                {
                    Console.Write(data[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("Queue is empty.");
                Console.WriteLine();
            }
        }
    }
}
