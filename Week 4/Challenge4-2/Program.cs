/* 
 * Method:
 * - receive two integers: a & b
 * - if both are divisible by 2 OR 3, return a * b
 * - otherwise return a + b
 * 
 * Check Divisibility
 * - a or b % 2 == 0; divisible by 2
 * - a or b % 3 == 0; divisible by 3
 * - example: (a % 2 == 0 || a % 3 == 0) AND (b % 2 == 0 || b % 3 == 0)
 * 
 * Pseudocode
 * If (a is divisible by 2 OR 3) AND (b is divisible by 2 OR 3)
 *  return a * b
 * Else
 *  return a + b
 *  
 */

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Divisible2Or3(15, 30)); // (both div by 3)
        Console.WriteLine(Divisible2Or3(2, 90)); // (div by 2 & 3)
        Console.WriteLine(Divisible2Or3(7, 12)); // (only b div by 3)
    }
    public static int Divisible2Or3(int a, int b)
    {
        //if ((a % 2 == 0 || a % 3 == 0) && (b % 2 == 0 || b % 3 == 0))
        //{
        //    return a * b;
        //}
        //else
        //{
        //    return a + b;
        //}

        // ternary expression
        return ((a % 2 == 0 || a % 3 == 0) && (b % 2 == 0 || b % 3 == 0))
            ? a * b
            : a + b;
    }
}

/* ternary expressions
 * return condition ? a * b : a + b;
 */