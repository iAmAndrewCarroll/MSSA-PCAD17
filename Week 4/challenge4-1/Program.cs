/* 
 * Rules:
 * Input: int num (positive integer)
 * Cannot convert to string
 * Cannot use .Contains(), .StartsWith(), or other built in functions
 * 
 * Want to isolate and compare each digit from right to left
 * - % 10 gives you the last digit
 * - / 10 removes the last digit
 * 
 * While i > 0
 * - obtain last digit via % 10
 * - digit == 3 return 'true' (bool check)
 * - else remove using / 10
 * - if the loop finishes -> return false (does not contain 3)
 * 
 * Pseudocode:
 * While number > 0:
 *  i = number % 10
 *  If i == 3:
 *      return true
 *  number = number / 10
 * Return false
 * 
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        int[] testNumbers = { 8675309, 867509, 302, 12456 };

        foreach (int i in testNumbers)
        {
            bool contains3 = Contains3(i);
            if (contains3)
            {
                Console.WriteLine($"Yes, {i} contains 3.");  // found a 3
            }
            else
            {
                Console.WriteLine($"No, {i} does not contain 3.");       // no digit was 3
            }
        }
    }
    public static bool Contains3(int num)
    {
        while (num > 0)
        {
            int i = num % 10; // last digit
            if (i == 3)
                return true; 

            num = num / 10;  // remove last digit
        }

        return false; 
    }
}


