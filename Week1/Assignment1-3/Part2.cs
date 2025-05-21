using System; // gives access to everything under the hood (Console, Array, etc)

namespace Assignment1_3 // keeps this part grouped with the rest of the project
{
    public class Part2 // defines the container for this part of the assignment
    {
        public static void Run() // method that is triggered when the user selects Part 2 from the menu
        {
            while (true)
            {
                // display information and menu options to the user
                Console.WriteLine("\n-- Array Menu --");
                Console.WriteLine("Fixed Array Default Size: 5");
                Console.WriteLine("Fixed Array Default Values: 0");
                Console.WriteLine();
                Console.WriteLine("1 - Declare Fixed Size Array");
                Console.WriteLine("2 - Declare & Initialize Array with Values");
                Console.WriteLine("3 - Explore Array Properties & Methods");
                Console.WriteLine("4 - Return to Main Menu");
                Console.Write("Select option: ");

                string choice = Console.ReadLine(); // gathers user input as a string

                // menu routing logic using switch (so fresh, so clean)
                switch (choice)
                {
                    case "1":
                        DeclareFixedSizeArray(); // method to demo predefined array
                        break;
                    case "2":
                        DeclareInitializedArray(); // method to demo array with explicit values
                        break;
                    case "3":
                        ExploreArrayMethods(); // method to demo built in tools that operate on arrays
                        break;
                    case "4":
                        Console.Clear();
                        return; // exit this part and return to Program.cs main menu
                    default:
                        Console.WriteLine("Bad Selection. Go again."); // graceful handling of invalid inputs
                        break;
                }
            }
        }

        // Demo creating an array with a fixed size but no assigned values
        private static void DeclareFixedSizeArray()
        {
            double[] numbers = new double[5]; // default to 0, array data type is doubles
            Console.WriteLine("\nArray declared with a fixed size of 5. Default values:");

            foreach (double num in numbers) // loop through each element in the array
            {
                Console.WriteLine(num + " "); // each will print 0 because values have not been assigned
            }
            Console.WriteLine(); // blank line for spacing
        }

        // Demo declaring an array and initializing it immediately wtih specific values
        private static void DeclareInitializedArray()
        {
            double[] initialized = { 10, 5, 7, 3, 8 }; // array with explicit values
            Console.WriteLine("\nArray declared and initialized with values:");
            
            foreach (double num in initialized) // loop through and display each value
            {
                Console.WriteLine(num + " ");
            }
            Console.WriteLine(); // blank line for readability
        }

        // Demo use of Array class methods & properties (Length, Sort, Reverse)
        private static void ExploreArrayMethods()
        {
            double[] sample = { 42, 17, 23, 5, 99 }; // unsorted array to demo sorting & reversin

            Console.WriteLine("\nOriginal Array:");
            PrintArray(sample); // call helper method to print array contents

            Console.WriteLine($"Length: {sample.Length}"); // .Length returns number of elements in array

            Array.Sort(sample); // sorts in ascending order; small to large
            Console.WriteLine("Sorted:");
            PrintArray(sample);

            Array.Reverse(sample); // reverse the current order; descending
            Console.WriteLine("Reversed:");
            PrintArray(sample);
        }

        // Helper method for printing arrays cleanly (avoids duplicate code, DRY principle)
        private static void PrintArray(double[] array)
        {
            foreach (double num in array) // iterate through and display each item
            {
                Console.WriteLine(num + " ");
            }
            Console.WriteLine(); // blank line after printing array
        }
    }
}