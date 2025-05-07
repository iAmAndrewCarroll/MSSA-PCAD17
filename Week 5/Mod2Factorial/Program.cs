namespace Mod2Factorial
{
    internal class Program
    {
        // 4! = 4*3*2*1 == 4*3
        // n! = (n-1)! * n
        static long Factorial_Iteration(int n)
        {
            long fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        static long Factorial(int n)
        {
            if (n == 1) return 1;
            return Factorial(n - 1) * n;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Factorial Iteration");
            Console.WriteLine(Factorial_Iteration(4));
            Console.WriteLine();
            Console.WriteLine("Factorial Recursion");
            Console.WriteLine(Factorial(4));
            Console.ReadKey();
        }
    }
}