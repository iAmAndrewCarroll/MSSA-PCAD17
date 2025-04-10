using System;
using System.Text; // for stringbuilder

namespace Assignment1_4
{
    public class LeetPalindrome
    {
        // Core logic to check if a string is a palindrome after cleaning
        public static bool IsPalindrome(string s)
        {
            // early return: if the input is null or empty (whitespace), treat it as a valid palindrome
            if (string.IsNullOrWhiteSpace(s)) return true; // empty or all spaces = valid palindrome

            // Step 1: Normalize the input
            // Convert to lowercase
            // remove non-alphanumerics (ignores punctuation & spaces)
            var cleanedChars = new StringBuilder();

            foreach (char c in s.ToLower())
            {
                // IsLetterOrDigit filters out spaces, commas, symbols, etc.
                if (char.IsLetterOrDigit(c))
                {
                    // build the cleaned string
                    cleanedChars.Append(c);
                }
            }

            // Step 2: Check if cleaned string reads the same forward and backward
            string cleaned = cleanedChars.ToString(); // finalize the cleaned string
            int left = 0, right = cleaned.Length - 1; // -1 because array 0

            while (left < right)
            {
                // Compare characters from each end
                if (cleaned[left] != cleaned[right])
                    return false; // mismatch - not a palindrome

                left++; // counting UP the 'normal' array
                right--; // counting down the 'reversed' array
            }

            return true; // all checks passed/ it's a palindrome
        }

        // Console interface: asks user for input, shows result
        public static void Run() // called by Program.cs
        {
            while (true) // keep running until user chooses to quit
            {
                Console.Write("Enter a phrase to check: ");
                string input = Console.ReadLine(); // user enters phrase
                bool result = IsPalindrome(input); // run logic

                // Display the result based on the boolean outcome
                Console.WriteLine(result 
                    ? "Yes, it's a palindrome." 
                    : "Nope, not a palindrome.");

                // follow-up menu
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1 - Try another");
                Console.WriteLine("2 - Return to Main Menu");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();  // clear spacing
                        continue; // rerun loop
                    case "2":
                        return; // exit back to main menu
                    default:
                        Console.WriteLine("Invalid option. Returning to main menu.");
                        return;
                }
            }
        }
    }
}