using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LinkedListNode
{
    public int data;
    public LinkedListNode next;
    public LinkedListNode(int val, LinkedListNode next)
    {
        this.data = val;
        this.next = next;
    }
}
class StackLL
{
    LinkedListNode top;
    int size;
    public StackLL()
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
        LinkedListNode newNode = new LinkedListNode(val, null);
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

    // removeFirst
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

    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty!");
            return -1;
        }
        return top.data;
    }

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty!");
            return;
        }
        LinkedListNode temp = top;
        while (temp != null)
        {
            Console.WriteLine(temp.data);
            temp = temp.next;
        }
    }
}

