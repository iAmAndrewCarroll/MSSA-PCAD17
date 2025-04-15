using System;                                // provides access to core tools like Console and string methods
using System.Text;                           // gives us access to StringBuilder for efficient string manipulation

namespace Assignment1_4                      // groups this code as part of Assignment 1.4
{
    public class LeetPalindrome
    {
        // ===================================================
        // Determines whether a string is a valid palindrome
        // Ignores punctuation, spaces, and is case-insensitive
        // ===================================================
        public static bool IsPalindrome(string s)
        {
            // return true immediately if string is null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(s)) return true;       // empty or space-only input counts as valid palindrome

            // normalize input: lowercase + strip non-alphanumeric chars
            var cleanedChars = new StringBuilder();              // efficient way to build the cleaned version of the string

            foreach (char c in s.ToLower())                      // loop through each character in lowercase version of string
            {
                if (char.IsLetterOrDigit(c))                    // keep only letters and numbers (ignore punctuation and symbols)
                {
                    cleanedChars.Append(c);                     // add cleaned char to StringBuilder
                }
            }

            string cleaned = cleanedChars.ToString();            // convert cleaned StringBuilder to a regular string
            int left = 0, right = cleaned.Length - 1;            // use two pointers: start and end of the string

            while (left < right)                                 // loop until the pointers meet or cross
            {
                if (cleaned[left] != cleaned[right])             // if mismatch found, it's not a palindrome
                    return false;

                left++;                                          // move left pointer toward center
                right--;                                         // move right pointer toward center
            }

            return true;                                         // all characters matched — valid palindrome
        }

        // ===================================================
        // Console UI: asks for input, shows result, repeats
        // Called from Program.cs and runs its own loop
        // ===================================================
        public static void Run()
        {
            while (true)                                         // infinite loop until user chooses to exit
            {
                Console.Write("Enter a phrase to check: ");     // prompt user for input
                string input = Console.ReadLine();              // read user input
                bool result = IsPalindrome(input);              // run palindrome logic and store result

                Console.WriteLine(result                         // show message based on true/false result
                    ? "Yes, it's a palindrome."
                    : "Nope, not a palindrome.");

                // follow-up menu to repeat or exit
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1 - Try another");
                Console.WriteLine("2 - Return to Main Menu");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();              // read follow-up choice

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();                    // add spacing
                        continue;                               // rerun loop
                    case "2":
                        return;                                 // exit to main menu
                    default:
                        Console.WriteLine("Invalid option. Returning to main menu.");
                        return;
                }
            }
        }
    }
}
