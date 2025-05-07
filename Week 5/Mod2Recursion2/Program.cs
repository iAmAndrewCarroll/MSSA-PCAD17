namespace Mod2Recusion2
{
    internal class Program
    {
        // 8
        // 1 thru 8
        // n=5 : 1 + 2 + 3 + 4 + 5 == sum(4)+5
        // n=6 : 1 + 2 + 3 + 4 + 5 + 6 == sum(5) + 6
        // sum(n) = sum(n-1) + n
        // n=1 : sum

        static int Sum_Recursion(int n)
        {
            if (n == 0) return 0; 
            if (n == 1) return 1;
            return Sum_Recursion(n - 1) + n;

        }
        static int SumIteration(int n)
        {
            int sum = 0;
            int i = 1;
            while (i <= n)
            {
                sum = sum + 1;
                i++;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Sum Recursion");
            Console.WriteLine(Sum_Recursion(5));
        }
    }
}