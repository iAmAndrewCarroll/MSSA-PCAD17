using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2
{
/*
 * Assignment 6.2.1
 * 
 * restate the problem:
 * implement a stack : using array
 * Push & Pop operations
 * 
 * Step Through:
 * is stack empty?
 * set top = -1
 * Push new element in case of empty stack : add value ; top++
 * element 0 has been created
 * Push second element : add value ; top++
 * Display stack
 * Pop top
 * Pop top
 * Display = IsEmpty
 * 
 * pseudo code:
 * class Node : top = -1, size
 * newNode
 * class stackLL : 
 * IsEmpty
 * Push : set val ; update top
 * Pop : update top ; size - 1
 * Display
 * 
 * 
 * 
 * 
 */

    class StackArrayNode
    {
        public int data;
        public StackArrayNode next;
        public StackArrayNode(int val, StackArrayNode next)
        {
            this.data = val;
            this.next = next;
        }
    }

    class StackArray
    {
        StackArrayNode top;
        int size;
        public StackArray()
        {
            this.top = null;
            this.size = 0;
        }

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        // same as AddFirst : O(1)
        public void Push(int val)
        {
            StackArrayNode newNode = new StackArrayNode(val, null);
            if (IsEmpty())
            {
                this.top = newNode;
            }
            else
            {
                newNode.next = this.top;
                this.top = newNode;
            }
            size++;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return -1;
            }
            int val = top.data;
            top = top.next;
            size--;
            return val;
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return;
            }
            StackArrayNode temp = top;
            while (temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
        }
    }
}
