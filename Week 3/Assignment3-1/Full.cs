using System;
using System.Text; // for StringBuilder
using Assignment_Tools; // Utilities.cs

namespace Assignment3_1 // Week 3 namespace
{
    public class Full
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                string choice = Utilities.DisplayMenu("Week 3 - Part 1", new[]
                {
                    "Return Even Numbers (1-99)",
                    "Check for Leap Year",
                    "Count Spaces in a String",
                    "Zero Consecutive 1s",
                    "Return to Main Menu"
                });

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(ReturnEvenNumbers());
                        Utilities.Pause();
                        break;
                    case "2":
                        int year = Utilities.ReadInt("Enter a year: ");
                        Console.WriteLine($"{year} is leap year: {IfYearIsLeap(year)}");
                        Utilities.Pause();
                        break;
                    case "3":
                        string input = Utilities.ReadNonEmptyString("Enter a sentence: ");
                        Console.WriteLine($"\"{input}\" contains {CountSpaces(input)} spaces.");
                        Utilities.Pause();
                        break;
                    case "4":
                        int[] testArray = { 0, 2, 1, 1, 9, 1, 1 };
                        Console.WriteLine("Original Array:");
                        Utilities.PrintArray(testArray);

                        int[] updated = ZeroOutFirst11Pair(testArray);
                        Console.WriteLine("Modified Array:");
                        Utilities.PrintArray(updated);

                        Utilities.Pause();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Utilities.Pause();
                        break;
                }
            }
        }

        // Returns a string of even numbers greater than 0 and less than 100 using StringBuilder class
        private static string ReturnEvenNumbers()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 2; i < 100; i += 2)
            {
                builder.Append(i).Append(" ");
            }

            return builder.ToString().TrimEnd(); // remove final space
        }

        // Checks if a year is a leap year (div by 4, not 100 unless also 400)
        private static bool IfYearIsLeap(int year)  // Boolean method
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);  // evaluate a logical expression and returns the result
            // && = Logical AND - True if both sides are true
            // ! = Logical NOT - Reverses a true/false value
        }

        // Counts the number of spaces in a given string
        private static int CountSpaces(string input)
        {
            int count = 0;

            foreach (char c in input)
            {
                if (c == ' ') count++;
            }

            return count;
        }

        // Modifies the first occurence of two consecutive 1s and replaces them with 0s
        private static int[] ZeroOutFirst11Pair(int[] array)
        {
            int[] clone = (int[])array.Clone(); // copy of original array

            for (int i = 0; i < clone.Length - 1; i++0) // loop safely up to second-last element
            {
                if (clone[i] == 1 && clone[i + 1] == 1) // checking for consecutive 1s via logical expression
                {
                    clone[i] = 0;  // replace first 1
                    clone[i + 1] = 0;  // replace second 1
                    break; // stop after first match
                }
            }

            return clone;  // return the modified copy
        }
    }
}