using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StackArrayDemo
{
    class StackArray
    {
        private int[] data;
        private int top;
        public StackArray(int size)
        {
            this.data = new int[size]; // user sets array size
            this.top = -1;

        }

        public bool IsEmpty()
        {
            return this.top == -1;
        }
        public bool isFull()
        {
            return this.top == data.Length - 1; // compare to the linked list that does not have a fixed length
        }

        public void Push(int val)
        {
            if (isFull())
            {
                Console.WriteLine("The stack is full. Cannot PUSH!!");
                return;
            }
            else
            {
                top++;  // increment top
                data[top] = val; // add the value
            }
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The stack is empty. Cannot POP!!");
                return -1; // could also return null
            }
            int val = data[top];
            top--;
            return val;
        }

        public void Display()
        {
            if (!IsEmpty())
            {
                for (int i = top; i >= 0; i--)  // start from top to 0 to make it work like a stack
                {
                    Console.WriteLine(data[i]);
                }
            }
            else
            {
                Console.WriteLine("Stack is empty!!");
            }
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is Empty!!");
                return -1;
            }
            else
            {
                return data[top];
            }
        }
    }
}
