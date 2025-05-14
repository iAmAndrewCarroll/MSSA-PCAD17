namespace _6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 6.2.1 - Implement Stack Using Array With Push Pop Operations");
            StackArray mystack = new StackArray();
            mystack.Push(12);
            mystack.Push(43);
            mystack.Push(27);
            Console.WriteLine("Push Operation : 12, 43, 27");
            mystack.Display();
            Console.WriteLine();
            Console.WriteLine("Commence Pop Operation");
            mystack.Pop();
            mystack.Pop();
            Console.WriteLine("Two Pops Performed");
            mystack.Display();
            Console.WriteLine();
            Console.WriteLine("Third Pop Performed");
            mystack.Pop();
            mystack.Display();

            Console.WriteLine();

            Console.WriteLine("Assignment 6.2.2 - Product Before / After Me in an Array nums[]");
            int[] input = new int[] { -1, 1, 0, -3, 3 };
            int[] result = ArrayNums.ExceptSelf(input);

            Console.WriteLine();

            int[] input1 = new int[] { 1, 2, 3, 4, };
            int[] result1 = ArrayNums.ExceptSelf(input1);


            Console.ReadKey();
        }
    }
}