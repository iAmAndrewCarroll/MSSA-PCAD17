namespace Mod2Recursion1
{
    internal class Program
    {
        // n=5
        // 25 16 9 4 1
        // given a number, print the square of that number reducing to 1

        static void PrintSquares_Iteration(int n)
        {
            while (n > 0)
            {
                Console.WriteLine(n * n);
                n--;
            }
        }

        static void Square_HeadRecursion(int n)
        {
            if (n > 0)
            {
                Square_HeadRecursion(n - 1);
                Console.WriteLine(n * n);
            }
        }

        static void Square_TailRecursion(int n)
        {
            if (n > 0)
            {
                Console.WriteLine(n * n);
                Square_TailRecursion(n - 1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Print squares by Iteration");
            PrintSquares_Iteration(4);
            Console.WriteLine("Print squares by tail recursion");
            Square_TailRecursion(4);
            Console.WriteLine("Print squares by head recursion");
            Square_HeadRecursion(4);
            Console.ReadKey();
        }
    }
}