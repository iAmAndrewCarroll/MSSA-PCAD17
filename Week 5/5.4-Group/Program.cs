using System.Diagnostics.CodeAnalysis;

internal class Program
{
    static int BuyChocolates(int[] prices, int money)
    {
        Array.Sort(prices);
        int cheap1 = prices[0];
        int cheap2 = prices[1];
        int sum = cheap1 + cheap2;
        
        if (sum <= money)
        {
            return money - sum;
        }
        else
        {
            return money;
        }
    }

    static string RemoveTrailingZeros(string s)
    {
        while (s.Length > 0 && s[s.Length - 1] == '0')
        {
            s = s.Substring(0, s.Length - 1);
        }

        return s;
    }
    static void Main()
    {
        Console.WriteLine("Group 5.4 Money & Zeros");
        Console.WriteLine("\n");
        Console.WriteLine("Money & Chocolate");
        int[] prices = { 1, 2, 2, 4 };

        int money;

        while (true)
        {
            Console.WriteLine("Enter your budget: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out money) && money > 0)
            {
                Console.WriteLine($"Money: {money}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        
        int result = BuyChocolates(prices, money);
        if (result == money)
        {
            Console.WriteLine($"No chocolates purchased.  Money : {money} ");
        }
        else
        {
            Console.WriteLine($"Two chocolates purchased. Change : {result}");
        }

        Console.WriteLine("\n");
        Console.WriteLine("Remove Trailing Zeros");

        string s;

        while (true)
        {
            Console.WriteLine("Enter your string: ");
            s = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine($"Original string: {s}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input. Please enter a valid string.");
            }

        }
            
        string output = RemoveTrailingZeros(s);
        if (output == s)
        {
            Console.WriteLine($"Original string had no trailing zeros: {s}");
        }
        if (output != s)
        {
            Console.WriteLine($"Trailing Zeros removed: {output}");
        }
            
        Console.ReadKey();
    }
}
