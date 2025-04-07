using System; // access to classes and tools in System namespace

namespace Assignment1_1 // similar to python modules and packages, namespaces help me organize code and avoid naming conflicts.
                        // They help organize code into groups like folders or directories in a file system.
                        // I can refer to this code elsewhere by using: Assignment1_1.Part1 (this is similar to a python import statement)
{
    public class Part2 // classes are blueprints for organizing code.
                       // Like a container that groups methods (actions) & variables (data) together
    {
        public static void Run()// this method is called by Program.Main() upon user selection.
                                // It's the entry point for this part.
        {
            int runningTotal = 0;

            while (true)
            {
                Console.WriteLine("\nSum Calculator");
                Console.WriteLine("Current sum: " + runningTotal);

                Console.Write("Enter the first number: ");
                bool valid1 = int.TryParse(Console.ReadLine(), out int number1);

                Console.Write("Enter the second number: ");
                bool valid2 = int.TryParse(Console.ReadLine(), out int number2);

                if (!valid1 || !valid2)
                {
                    Console.WriteLine("Invalid input.  Whole numbers only.");
                    continue;
                }

                int sum = number1 + number2;
                runningTotal = sum; // replaces the running total by default
                Console.WriteLine("The sum is: " + sum);

                while (true)
                {
                    Console.WriteLine("\nWhat would you like to do next?");
                    Console.WriteLine("1 - Add another pair (new total)");
                    Console.WriteLine("2 - Add to current total");
                    Console.WriteLine("3 - Return to Main Menu");
                    Console.Write("Choice: ");

                    string nextChoice = Console.ReadLine();

                    if (nextChoice == "1")
                    {
                        break; // re-enter loop with fresh inputs
                    }
                    else if (nextChoice == "2")
                    {
                        Console.Write("Enter a number to add to the current sum: ");
                        bool validAdd = int.TryParse(Console.ReadLine(), out int addVal);
                        if (validAdd)
                        {
                            runningTotal += addVal;
                            Console.WriteLine("New sum: " + runningTotal);
                        }
                        else
                        {
                            {
                                Console.WriteLine("Invalid input.  Must be a number.");
                            }
                        }
                    }
                    else if (nextChoice == "3")
                    {
                        return; // main menu
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
            }
        }
    }
}
