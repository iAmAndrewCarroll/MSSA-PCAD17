using System.Diagnostics.CodeAnalysis;

namespace Mod1MethodDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            // the below 'input' code is similar to a while loop
            input:  // this is simply a label and is not meant for large code bases.  
            // if TryParse is NOT TRUE return to input; user entered bad input
            Console.WriteLine("enter value for num1:");
            bool flag = int.TryParse(Console.ReadLine(), out num1);
            if (!flag)
            {
                goto input;
            }

            Console.WriteLine("Enter value for num2:");
            bool flag1 = int.TryParse(Console.ReadLine(), out num2);
            Swap(ref num1, ref num2);
            Console.WriteLine($"num1: {num1} , num2: {num2}");
            Console.ReadKey();
            int[] nums = new int[5] { 1, 2, 3, 4, 5 };  // arrays are already reference types
            ChangeValues(nums); // passing the data by address / reference
            foreach (int num in nums)
            {
                Console.WriteLine(num);
            }
            int sum, product;
            Results(out sum, out product, num1, num2, 40, 80);
            Console.WriteLine($"Sum: {sum}  Product: {product}");
            CalculateTax(state: "NY", contributions: 0, dependents: 1, filingType: 'M', baseSalary: 9802);
            CalculateTax(4448, "NC");
            Console.ReadKey();

            for (int j = 0; j < 5; j++)
            {
                if (j == 4)
                {
                    continue;
                }
                Console.WriteLine(j);
            }
        }

        static void Swap(ref int num1, ref int num2)  // calling them as static because called from Main
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        static void CalculateTax(double baseSalary, string state, double contributions=0, int dependents=0, char filingType)
        {

        }

        static void Results(out int sum, out int product, params int[] nums)
        {
            product = 1;
            sum = 0;
            foreach (int num in nums)
            {
                product *= num;
                sum += num;
            }
        }

        //static void Test(ref Book b)
        //{

        //}

        static void ChangeValues(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = 1;
            }
        }
    }
}