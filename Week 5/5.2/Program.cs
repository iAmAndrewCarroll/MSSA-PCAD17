internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the last word and how long is it?");
        Console.WriteLine(" fly me to the moon ");
        PrintLastWord(" fly me to the moon ");
        Console.WriteLine("\n");
        Console.WriteLine("5.2.2 - Natural Numbers");
        PrintNaturalNumbers(10);
        Console.WriteLine("\n");
        Console.WriteLine("5.2.3 - Print Numbers 1 through n");
        PrintNumbers(10);
        Console.WriteLine("\n");

        Console.WriteLine("5.2.4 - Palindrome Recursion");
        //string input = "RADAR";
        //int start = 0;
        //int end = input.Length - 1;
        //Console.WriteLine($"Input string: {input}");
        //PalindromeRecursion(input, start, end);
        string input = "HELLO";
        int start = 0;
        int end = input.Length - 1;
        Console.WriteLine($"Input string: {input}");
        PalindromeRecursion(input, start, end);
        Console.WriteLine();
        string input1 = "LEVEL";
        int start1 = 0;
        int end1 = input.Length - 1;
        Console.WriteLine($"Input string: {input1}");
        PalindromeRecursion(input1, start1, end1);

        Console.ReadKey();
    }
/*
 *  5.2.1
 *  
 *  Clarify the Problem:
 *  1. Given a string s consisting of words and spaces, return the length of 
 *  the last word in the string. A word is a maximal substring consisting of 
 *  non-space characters only.
 *  Example 1:
 *  Input: s = "Hello World"
 *  Output: 5
 *  Explanation: The last word is "World" with length 5.
 *  
 *  Example 2:
 *  Input: s = " fly me to the moon "
 *  Output: 4
 *  Explanation: The last word is "moon" with length 4.
 *  
 *  Step Through
 *  - Begin traversing from the end
 *  - If it begins with a space continue until it hits a character
 *  - Begin adding characters and incrementing the count
 *  - Stop when hit the next space or end
 *  
 *  Pseudo Code
 *  func getLastWord(s, index, counter, word):
 *      if index < 0: return reverse(word), counter
 *      
 *      currentChar = s[index]
 *      
 *      if currentChar == ' ' and counter == 0:
 *          // Trailing space, haven't started a word
 *          return getLastWord(s, index - 1, counter, word)
 *          
 *      else if currentChar != ' ':
     *      // build the word
     *      append currentChar to word
     *      increment counter
     *      return getLastWord(s, index - 1, counter, word)
 *      
 *      else if currentChar == ' ' and counter > 0:
 *          // finished the word
 *          return reverse(word), counter
 *          
 * func PrintLastWord(s):
 *      word, length = getLastWord(s, s.length - 1, 0, empty string)
 *      print "The last word is", word, "with length", length
 *      
 */
    static (string, int) getLastWord(string s, int index, int counter, string word)
    {
        if (index < 0)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            return (new string(chars), counter);
        }

        char currentChar = s[index];

        if (currentChar == ' ' && counter == 0)
        {
            return getLastWord(s, index - 1, counter, word);
        }
        else if (currentChar != ' ')
        {
            word += currentChar;
            counter++;
            return getLastWord(s, index - 1, counter, word);
        }
        else
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            return (new string(chars), counter);
        }
    }
    static string PrintLastWord(string s)
    {
        var result = getLastWord(s, s.Length - 1, 0, "");
        Console.WriteLine($"The last word is {result.Item1} and it is {result.Item2} letters long.");
        return s;
        //Console.WriteLine();
    }

/*
 * 5.2.2 Whiteboard
 * Restate the problem:
 * I need to write a C# program that prints the first n natural numbers using recursion.
 * - why recursion? Because this problem can be broken down into smaller versions of itself.
 * Natural numbers begin at 1
 * 
 * Step Through
 * - I want to print numbers starting from 1 up to n
 * - Recursion works by calling a function repeatedly until a base case is hit
 * - Call the function with n : continue calling with n - 1, n - 2, etc until 1
 * - Recursion stops at base case n == 1
 * - Recursive call unwinds print each number
 * - numbers print in ascending order
 * - single function that : calls itself with n - 1
 * - prints n after the recursive call finishes
 * - no need to return anything : function prints each number at the right time
 * 
 * Pseudo Code
 * function PrintNaturalNumbers(n):
 *  if n == 0:
 *      return // base case : do nothing for <= 0
 *      
 *  call PrintNaturalNumbers(n - 1)  // recursion to print earlier numbers
 *  print n                          // prints current number after recursion
 * 
 */

    static void PrintNaturalNumbers(int n)
    {
        if (n == 0)
        {
            return;
        }

        PrintNaturalNumbers(n - 1);
        Console.Write(n + " ");
    }

/*
* 5.2.3 Whiteboard
* Restate the problem:
* I need to write a C# program that prints numbers from n to 1 using recursion.
* - why recursion? This can print before adding to stack
* Begin with n count down to 1
* 
* Step Through
* - Start with n : print all numbers down to 1
* - Recursive function that takes n as a parameter
* - check if n < 1 : True ? stop recursion --> BASE CASE
* - check n >= 1 : True ? print n now -->
* - call the function again using n - 1
* - this prints n, n - 1, n - 2, ... down to 1
* - Recursion stops
* - Console.Write(n + " ") to print on same line with spaces
* 
* Pseudo Code
* function PrintNumbers(n):
*  if n < 1:
*      return // base case : stop when we go past 1
*  
*  print n               // print current number before recursion
*  call PrintNumbers(n - 1)  // recursion to stack next number
* 
*/
    static void PrintNumbers(int n)
    {
        if (n < 1)
        {
            return;
        }
        Console.Write(n + " ");
        PrintNumbers(n - 1);
    }

/*
* 5.2.4 Whiteboard
* Restate the problem:
* I need to write a C# program to check if a string is a Palindrome or not using recursion.
* - why recursion? We can check it on both ends of the stack
* Input a string: RADAR
* Expected Output : This string is a Palindrome.
* 
* Step Through
* - input a string
* - Palindrome : RADAR, LEVEL
* - Recursion to check first & last characters of string
* - first =/= last ? not a palindrome : stop
* - first == last ? recusively check substring AFTER removing first & last
* - repeat
* - BASE CASE : if start >= end --> return true : covers both even and odd-length strings
* - Recursion : if s[start] == s[end] --> chack s[start + 1] to s[end - 1]
* - helper function : two indices 'start' & 'end' of the substring being compared
* - IF inward recursion --> outer characters match --> string is palindrom
* 
* Pseudo Code
* function IsPalindrome(string s, int start, int end)
*   if start >= end: // BASE CASE : first =/= last character
*       return true
*   if s[start] != s[end]:
*       return false
*   return IsPalindrome(s, start + 1, end - 1)
* 
*/

    static void PalindromeRecursion(string s, int start, int end)
    {
        if (start >= end)
        {
            Console.WriteLine("Palindrome.");
            return;
        }
        if (s[start] != s[end])
        {
            Console.WriteLine("Not a Palindrome.");
            return;
        }

        PalindromeRecursion(s, start + 1, end - 1);
    }
}