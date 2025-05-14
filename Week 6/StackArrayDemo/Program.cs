using System.Collections.Generic;


namespace StackArrayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(34);
            stack.Push(12);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            stack.Pop();
            Console.WriteLine("After pop:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine($"after peek: {stack.Peek()}");
            Console.WriteLine();

            Console.WriteLine("Push, Pop, Peek Operations Demo:");
            StackArray mystack = new StackArray(10);
            mystack.Push(1);
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(4);
            mystack.Display();
            Console.WriteLine();

            
            Console.WriteLine($"Peek: " + mystack.Peek());
            Console.WriteLine();

            mystack.Pop();
            Console.WriteLine("After Pop:");
            mystack.Display();
            Console.WriteLine();

            Console.WriteLine("Keep Poppin' :");
            mystack.Pop();
            Console.WriteLine();
            Console.WriteLine("After Pop:");
            mystack.Display();
            Console.WriteLine();

            mystack.Pop();
            Console.WriteLine("After Pop:");
            mystack.Display();
            Console.WriteLine();

            mystack.Pop();
            Console.WriteLine("After Pop:");
            mystack.Display();
            Console.WriteLine();

            Console.WriteLine("Push 300:");
            mystack.Push(300);
            Console.WriteLine("My Stack after Push:");
            mystack.Display();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}