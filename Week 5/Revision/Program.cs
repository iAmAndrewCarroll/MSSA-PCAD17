using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Revision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            object o;
            o = x; // value type to ref type conversion : boxing
            int y = (int)o; // ref type to value conversion : unboxing

            // older collections class
            //Stack stack1 = new Stack();
            //stack1.Push(23);
            //stack1.Push("abc");

            // using System.Collections.Generics
            // Did not see example

            CustomList<int> ints = new CustomList<int>(20);
            
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            stack.Pop();

            Queue<Customer> customers = new Queue<Customer>();
            customers.Enqueue(new Customer() { PhoneNumber = 8675309, FirstName = "Tom" });
            customers.Dequeue();

            List<string> customernames = new List<string>();
            customernames.Add("Rob");
            SwapData<int> swapint = new SwapData<int>();

            //LinkedList<>

            int[] nums = new int[5];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            // 2D Array
            int[,] temps = new int[3, 3]; // number of rows, columns
            
            // temps.GetLength(1)
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    
                }
            }
            Console.WriteLine(nums);
        }

        static void Swap(ref int n1, ref int n2)
        {

        }

        static void Swap(ref float n1, ref float n2)
        {

        }
    }
}