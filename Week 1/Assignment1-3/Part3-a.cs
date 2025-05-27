using System;             // gives us access to core C# functionality like Console.ReadLine, WriteLine, etc.
using System.Threading;   // lets us use Thread.Sleep() to delay execution (for smoother UX transitions)

namespace Assignment1_3   // groups this class under a logical folder/namespace for this assignment
{
    public class Part3_a  // class declaration: container that holds all methods related to this part of the app
    {
        // this is the main method that gets called when the user selects "Part3_a" from Program.cs
        public static void Run()
        {
            while (true) // infinite loop — we break out with return; or continue; based on user choice
            {
                // prompt user for how many numbers they want to enter into the array
                Console.Write("\nEnter the number of elements to store in the array: ");
                int size = GetPositiveIntFromUser(); // this will keep asking until the user enters a valid positive integer

                // collect that many numbers from the user
                int[] originalArray = GetArrayFromUser(size); // uses a helper method to gather the entire array

                // show the array back to the user in the original order
                Console.WriteLine("\nThe values stored in the array are:");
                PrintArray(originalArray); // outputs all values in a single row, space-separated

                // reverse the array (without modifying the original) and show that as well
                Console.WriteLine("\nThe values stored in the array in reverse order are:");
                int[] reversedArray = ReverseArray(originalArray); // creates a new reversed array
                PrintArray(reversedArray); // prints the reversed array values

                // give the user some options for what to do next
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1 - Run Again");              // reruns the input/reverse process
                Console.WriteLine("2 - Return to Main Menu");    // exits this module
                Console.Write("Choice: ");
                string choice = Console.ReadLine();              // capture their selection

                // control the flow of the app based on the user's selection
                switch (choice)
                {
                    case "1":     // if user types "1", restart the loop and run again
                        continue;
                    case "2":     // if user types "2", pause and exit this module cleanly
                        Console.WriteLine("Returning to main menu...");
                        Thread.Sleep(799); // pause briefly before clearing
                        Console.Clear();   // clears the console before returning
                        return;
                    default:      // if user types anything else, treat it as invalid and still return
                        Console.WriteLine("Bad input. Returning to main menu...");
                        Thread.Sleep(799);
                        Console.Clear();
                        return;
                }
            }
        }

        // helper method to read and validate that the input is a positive whole number (int > 0)
        private static int GetPositiveIntFromUser()
        {
            int value;

            while (true) // loop until valid input is entered
            {
                string input = Console.ReadLine() ?? ""; // null-coalescing operator prevents null crash
                bool valid = int.TryParse(input, out value) && value > 0; // input must be a valid int and greater than 0

                if (valid)
                    return value;

                // if input fails, show a friendly error message
                Console.WriteLine("Invalid input. Please enter a positive whole number.");
            }
        }

        // prompts the user to fill an array of the given size, one value at a time
        private static int[] GetArrayFromUser(int size)
        {
            int[] array = new int[size]; // declare an empty array of the specified size

            // loop over each index and collect a value from the user
            for (int i = 0; i < size; i++)
            {
                // label each input prompt with its index (e.g., "Element - 0:")
                array[i] = GetIntFromUser($"Element - {i}");
            }

            return array; // return the fully filled array
        }

        // prompts the user to enter a single integer for a given label (e.g., "Element - 3")
        private static int GetIntFromUser(string label)
        {
            int value;

            while (true) // keep looping until valid input is entered
            {
                Console.Write($"{label}: ");           // prompt for input
                string input = Console.ReadLine();     // get user input
                bool valid = int.TryParse(input, out value); // safely convert input to integer

                if (valid)
                    return value; // valid input returns immediately

                // bad input: show error message and loop again
                Console.WriteLine("Invalid input. Whole numbers only.");
            }
        }

        // this method takes in an array and returns a new array with elements reversed
        private static int[] ReverseArray(int[] original)
        {
            int length = original.Length;               // get the size of the input array
            int[] reversed = new int[length];           // declare a new array with the same size

            for (int i = 0; i < length; i++)            // loop through original array
            {
                // calculate index from the end and store it in reverse order
                reversed[i] = original[length - 1 - i]; // e.g., reversed[0] = original[4] if length = 5
            }

            return reversed; // return the newly reversed array
        }

        // this method prints all elements of an array in one line
        private static void PrintArray(int[] array)
        {
            foreach (int num in array)       // loop over each element in the array
            {
                Console.Write(num + " ");    // print each number followed by a space
            }
            Console.WriteLine();             // add a newline after printing the full array
        }
    }
}
