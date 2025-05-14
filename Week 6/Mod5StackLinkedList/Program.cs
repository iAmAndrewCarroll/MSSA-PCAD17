

namespace Mod5StackLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackLL mystack = new StackLL();
            mystack.Push(23);
            mystack.Push(34);
            mystack.Display();
            mystack.Pop();
            Console.WriteLine("after pop");
            mystack.Display();
            Console.ReadKey();
        }
    }
}
