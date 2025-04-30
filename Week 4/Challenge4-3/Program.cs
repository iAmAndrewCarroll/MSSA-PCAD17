/* 
 * Problem Set:
 * reverse a char[] in place, meaning:
 * - don't return a new array
 * - dont use .Reverse() or .ToArray() or anything from LINQ
 * 
 * Core Practice Concepts
 * - set a pointer at the start (left)
 * - set a pointer at the end (right)
 * - while left < right
 *  - swap s[left] and s[right]
 *  - move left++, right--
 *  
 *  Pseudocode
 *  left = 0
 *  right = s.Length - 1
 *  
 *  while left < right:
 *      swap s[left] with s[right]
 *      left++
 *      right--
 *      
 */

class Program
{
    static void Main(string[] args)
    {
        char[] s = { 'h', 'e', 'l', 'l', 'o' };
        char[] hannah = { 'H', 'a', 'n', 'n', 'a', 'h' };

        Console.WriteLine("Original:");
        Console.WriteLine(new string(s));
        Console.WriteLine(new string(hannah));

        ReverseString(s); // modified in place
        ReverseString(hannah); // modified in place

        Console.WriteLine("Reversed:");
        Console.WriteLine(string.Join("", s)); // Output: olleh
        Console.WriteLine(string.Join("", hannah));
    }
    public static void ReverseString(char[] s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            // Swap characters
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;

            left++;
            right--;
        }
    }
}