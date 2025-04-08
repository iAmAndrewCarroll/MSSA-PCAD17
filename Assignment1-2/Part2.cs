using System; // how we access built in capabilities for C#
using System.Threading; // gives access to Thread.Sleep

namespace Assignment1_2 // keeps this part grouped with the rest of the project
{
    public class Part2 // defines a container for this part of the assignment
    {
        public static void Run() // method that is triggered when the user selects Part 2 from the main menu
        {
            while (true) // loop to allow user to repeat or exit
            {
                double sum = 0; // sum keeps track of running total of natural numbers
                                // double is used to match my project pattern even though all values are whole numbers

                Console.WriteLine("\nSumming up the first 10 natural numbers...");
                Console.Write("Progress: ");

                for (double i = 1; i <= 10; i++) // for loop starts with i = 1 and runs while i <= 10
                                                 // i++ increments i by 1 each time the loop runs
                {
                    sum += i; // adds each number to the total as it goes
                              // sum += i is shorthand for sum = sum + i;

                    if (i < 10)
                    {
                        Console.Write(i + " + "); // this will provide the effect of numbers being written to the console
                    }
                    else
                    {
                        Console.Write(i + " = "); // once i = 10 it will instead print the "="
                    }

                    Thread.Sleep(500); // delay in milliseconds; approximately half a second
                }


                Console.WriteLine("\nThe Sum is : " + sum); // \n creates a line break before printing the total
                                                            // final sum shown after loop finishes

                // allowing the user to run the calculation again
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1 - Run Again");
                Console.WriteLine("2 - Return to Main Menu");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(); // spacing and readability
                        continue; // re-run the loop
                    case "2":
                        return; // exit to main
                    default:
                        Console.WriteLine("Invalid choice.  Returning to Main Menu.");
                        return;
                }
            }
        }
    }
}
