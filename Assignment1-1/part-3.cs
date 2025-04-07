using System; // access to classes and tools in System namespace

namespace Assignment1_1 // similar to python modules and packages, namespaces help me organize code and avoid naming conflicts.
                        // They help organize code into groups like folders or directories in a file system.
                        // I can refer to this code elsewhere by using: Assignment1_1.Part1 (this is similar to a python import statement)
{
    public class Part3 // classes are blueprints for organizing code.
                       // Like a container that groups methods (actions) & variables (data) together
    {
        public static void Run() // this method is called by Program.Main() upon user selection.
                                 // It's the entry point for this part.
        {
            while (true)
            {
                Console.WriteLine("\nDivision Calculator: Quotient & Remainder");

                // input + validation loop
                int dividend = 0;
                int divisor = 0;

                while (true)
                {
                    // enter the dividend
                    Console.Write("Enter the first number (dividend): ");
                    string dividendInput = Console.ReadLine();

                    // enter the divisor
                    Console.Write("Enter the second number (divisor): ");
                    string divisorInput = Console.ReadLine();

                    // parse both inputs
                    bool dividendValid = int.TryParse(dividendInput, out dividend);
                    bool divisorValid = int.TryParse(divisorInput, out divisor);

                    if (!dividendValid || !divisorValid)
                    {
                        Console.WriteLine("Invalid input.  Whole numbers only.");
                        Console.WriteLine(); // readability spacing
                        continue; // back to top of loop
                    }

                    // check for zero
                    if (divisor == 0)
                    {
                        Console.WriteLine("Division by zero breaks the world.");
                        Console.WriteLine();
                        continue;
                    }

                    break;
                }

                // computation
                int quotient = dividend / divisor; // div result
                int remainder = dividend % divisor; // modulo (%) give the remainder

                // results
                Console.WriteLine("Quotient: " + quotient);
                Console.WriteLine("Remainder: " + remainder);

                // follow-up menu
                while (true)
                {
                    Console.WriteLine("\nWhat would you like to do next?");
                    Console.WriteLine("1 - Try another pair");
                    Console.WriteLine("2 - Return to Main Menu");
                    Console.Write("Choice: ");

                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        break; // back to initial loop to enter new numbers
                    }
                    else if (choice =="2")
                    {
                        return; // back to main menu
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Try AGAIN!!!!!!");
                    }
                }
            }
        }
    }
}