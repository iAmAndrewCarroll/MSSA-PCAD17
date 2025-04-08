using System; // access to built in C# functionality

namespace Assignment1_2 // groups things together for this assignment
{
    public class Part3 //defines the container for this part of the assignment
    {
        public static void Run() // method triggered when user selects part 3 from main menu
        {
            while (true) // this loop will run until the user selects option 5 to return to main menu
            {
                Console.WriteLine("\n-- Calculator --"); // will display the calculator menu
                Console.WriteLine("1 - Add");
                Console.WriteLine("2 - Subtract");
                Console.WriteLine("3 - Multiply");
                Console.WriteLine("4 - Divide");
                Console.WriteLine("5 - Return to Main Menu");
                Console.Write("Select an operation: ");

                string op = Console.ReadLine(); // stores user input as a string.  Compared against expected values in an if or a switch.

                if (op == "5") return; // exits to main menu if user selects option 5.

                // TryParer() gracefully tries to convert user input into a double data type
                // if parsing fails, TryParse() returns false instead of crashing the program
                // out double a & out double b store the converted values if successful
                Console.Write("Enter first number: ");
                bool valid1 = double.TryParse(Console.ReadLine(), out double a);

                Console.Write("Enter second number: ");
                bool valid2 = double.TryParse(Console.ReadLine(), out double b);

                // if either input is invalid this error message will skip the rest of the loop
                // continue puts us back to the top of the loop menu without exiting the program
                if (!valid1 || !valid2)
                {
                    Console.WriteLine("Invalid input. Numbers only.");
                    continue;
                }

                // use of a switch statement since John mentioned them yesterday
                switch (op)
                // each case adds, subtracts, multiplies or divides based on the provided input
                // uses string interpolation ($"") to print readable results
                {
                    case "1":
                        Console.WriteLine($"Result: {a} + {b} = {a + b}");
                        break;
                    case "2":
                        Console.WriteLine($"Result: {a} - {b} = {a - b}");
                        break;
                    case "3":
                        Console.WriteLine($"Result: {a} * {b} = {a * b}");
                        break;
                    case "4":
                        // Prevents a crash out by handling attempts to divide by zero gracefully
                        if (b == 0)
                            Console.WriteLine("Division by zero breaks the world.");
                        else
                            Console.WriteLine($"Result: {a} / {b} = {a / b}");
                        break;
                    // if user types something outside of 1-5 (menu) this error message handles it gracefully and lets them try again.
                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }
            }
        }
    }
}

// switch helps simplify decision-making based on input - more readable that a ton of if/else.
// TryParse() allows for more graceful operations
// always protect against division by zero when building calculators.