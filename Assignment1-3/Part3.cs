using System; // access to everything under the hood (Console, Array, etc)

namespace Assignment1_3 // groups this file with the defined project
{
    public class Part3 // this class contains all logic for reading and reversing arrays
    {
        public static void Run() // main method for Part3; called from Program.cs based on user selection
        {
            while (true) // keeps this module running until user exits
            {
                Console.Write("\nEnter the number of elements  to store in the array: ");
                bool sizeValid = int.TryParse(Console.ReadLine(), out int size);
                // TryParse checking for valid input and converting to int

                if (!sizeValid || size <= 0) // input must be a positive whole number
                {
                    Console.WriteLine("Bad input. Positive whole numbers please");
                    continue; // restart loop if input is invalid
                }

                int[] values = new int[size]; // delcare arry with user-defined size

                for (int i = 0; i < size; i++) // loop to collect each individual number
                {
                    Console.Write($"Element - {i}: ");
                    bool elementValid = int.TryParse(Console.ReadLine(), out int element);

                    if (!elementValid) // handle invalid entries (letters, symbols, etc.)
                    {
                        Console.WriteLine("Bad Input! Whole numbers only.");
                        i--; // re-prompt for the same index
                        continue;
                    }

                    values[i] = element; // store the valid number into the array
                }

                // Display original array in input order
                Console.WriteLine("\nThe values stored in the array are:");
                PrintArray(values);  // helper method loops and prints array

                Console.WriteLine(); // spacing

                // Display same values in reverse order
                Console.WriteLine("The values stored in the array in reverse are:");
                PrintArrayReversed(values); // helper method to reverse and print array

                // Offer user next-step choices
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1 - Run Again");
                Console.WriteLine("2 - Return to Main Menu");
                Console.Write("Choice: ");

                string choice = Console.ReadLine(); // capture user decision

                // respond to user's follow-up input
                switch (choice)
                {
                    case "1":
                        Console.WriteLine(); // re-run from top of loop
                        continue;
                    case "2": 
                        Console.WriteLine(); // exit to main menu
                        return;
                    default:
                        Console.WriteLine("Bad input! Returning to Main Menu."); // catch invalid options
                        return;
                }
            }
        }

        // Method to print values of the array in order they were entered
        private static void PrintArray(int[] array)
        {
            foreach (int num in array) // foreach loop goes through each item
            {
                Console.Write(num + " "); // values are printed on the same line
            }
            Console.WriteLine(); // blank line at the end of array display
        }

        // Method to print array values in reverse (last item first)
        private static void PrintArrayReversed(int[] array)
        {
            for (int i = array.Length - 1; i >=0; i--) // reverse for-loop
            {
                Console.Write(array[i] + " "); // prints each value starting from the end
            }
            Console.WriteLine(); // finish with a new line for clean spacing
        } 
    }
}