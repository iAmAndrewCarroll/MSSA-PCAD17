using System;                             // Gives me access to built-in classes like Console, string, int, etc.
using System.Threading;                   // Lets me use Thread.Sleep to pause the program for a short time

namespace Toolbox                         // I define a namespace to group this class logically and prevent naming conflicts
{
    public static class Utilities         // I make this class static so I can call these methods directly without creating an object
    {
        // ============================================================================
        // UTILITIES TOOLBOX – Reusable Methods for All Assignments
        // ----------------------------------------------------------------------------
        // Use these for:
        // ✓ Validated user input (int, double, positive, range-limited, strings)
        // ✓ Clean array output and reversal
        // ✓ Menus, confirmation prompts, selection routing
        // ✓ Console layout tools (pause, delay, draw box, clear lines, overwrite line)
        // ✓ DRY, safe, and switch-friendly console app UX
        // ============================================================================

        // ============================================
        // USER INPUT METHODS
        // These help me collect and validate user input
        // ============================================

        public static int ReadInt(string prompt)               // Defines a method that asks for an integer and validates it
        {
            while (true)                                       // Loop until the user provides valid input
            {
                Console.Write(prompt);                         // Show the prompt text in the console
                string input = Console.ReadLine();             // Read the user's input as a string

                bool success = int.TryParse(input, out int result); // Try to convert the input to an integer safely

                if (success)                                   // If conversion succeeded (valid integer)
                    return result;                             // Return the parsed integer

                Console.WriteLine("Invalid input. Whole numbers only."); // If input is invalid, show error and loop again
            }
        }

        public static int ReadPositiveInt(string prompt)       // Defines a method that asks for a positive whole number only
        {
            while (true)                                       // Loop until valid input is received
            {
                Console.Write(prompt);                         // Display the custom prompt
                string input = Console.ReadLine();             // Capture user input as a string
                bool success = int.TryParse(input, out int result); // Try to convert the input to an integer

                if (success && result > 0)                     // Check that it's a valid integer and greater than 0
                    return result;                             // Return the valid positive integer

                Console.WriteLine("Invalid input. Enter a number greater than 0."); // Show error message if invalid
            }
        }

        public static int ReadIntInRange(string prompt, int min, int max) // Method to ask for a number within a specific range
        {
            while (true)                                       // Loop until the user provides a valid number in range
            {
                Console.Write(prompt);                         // Prompt the user for input
                bool valid = int.TryParse(Console.ReadLine(), out int result); // Try to convert the input to an integer

                if (valid && result >= min && result <= max)   // Check if the input is both valid and within the range
                    return result;                             // Return the number if it passes both checks

                Console.WriteLine($"Enter a number between {min} and {max}."); // Otherwise, show an error message
            }
        }

        public static double ReadDouble(string prompt)         // Method to request a decimal number (e.g., 3.14)
        {
            while (true)                                       // Keep asking until a valid decimal is entered
            {
                Console.Write(prompt);                         // Display the prompt
                string input = Console.ReadLine();             // Read user input
                bool success = double.TryParse(input, out double result); // Try converting to a double

                if (success)                                   // If conversion worked
                    return result;                             // Return the valid double

                Console.WriteLine("Invalid input. Decimal numbers only."); // Display error for invalid input
            }
        }

        public static double ReadPositiveDouble(string prompt) // Method to request a decimal number that must be greater than 0
        {
            while (true)                                       // Keep looping until a valid positive double is entered
            {
                Console.Write(prompt);                         // Show prompt to the user
                string input = Console.ReadLine();             // Read the input as a string
                bool success = double.TryParse(input, out double result); // Attempt conversion

                if (success && result > 0)                     // Ensure input is both valid and greater than zero
                    return result;                             // Return the valid positive number

                Console.WriteLine("Positive decimal numbers only."); // Error message if validation fails
            }
        }

        public static string ReadNonEmptyString(string prompt) // Method to ensure the user types something meaningful
        {
            while (true)                                       // Repeat until a valid non-empty string is entered
            {
                Console.Write(prompt);                         // Show the prompt text
                string input = Console.ReadLine();             // Read user input

                if (!string.IsNullOrWhiteSpace(input))         // Check if the input is not null, empty, or all spaces
                    return input;                              // Return valid non-empty input

                Console.WriteLine("Input cannot be empty.");   // Warn the user if input is blank or just spaces
            }
        }


        // -------------------------------------------------------------
        // ARRAY HELPERS – GENERIC
        // -------------------------------------------------------------

        public static void PrintArray<T>(T[] array)           // Method to print any array type (like int[], double[], string[])
        {
            foreach (T item in array)                         // I use foreach to loop through every item in the array
                Console.Write(item + " ");                    // I print each item followed by a space (keeps it clean on one line)

            Console.WriteLine();                              // After the array is printed, I move the cursor to the next line
        }


        public static T[] ReverseArray<T>(T[] original)       // Method that creates and returns a reversed copy of the input array
        {
            int length = original.Length;                     // I store the length of the original array so I know how big to make the new one
            T[] reversed = new T[length];                     // I declare a new array of the same length to hold reversed elements

            for (int i = 0; i < length; i++)                  // I loop through each index in the original array
                reversed[i] = original[length - 1 - i];       // I fill the new array starting from the end of the original (reverse indexing)

            return reversed;                                  // I return the reversed array to the caller
        }


        // -------------------------------------------------------------
        // FLOW CONTROL & INTERACTION TOOLS
        // -------------------------------------------------------------

        public static void Delay(int milliseconds = 799)      // Method to pause the program for a short time (default: 799ms)
        {
            Thread.Sleep(milliseconds);                       // Thread.Sleep stops the program for the given number of milliseconds
        }

        public static void Pause(string message = "Press ENTER to continue...") // Method to stop until the user presses ENTER
        {
            Console.WriteLine(message);                       // I show the default or custom message telling the user what to do
            Console.ReadLine();                               // I wait for the user to hit ENTER before continuing
        }

        public static bool Confirm(string question)           // This method asks the user a yes/no question and returns true or false
        {
            while (true)                                      // I loop until the user gives a valid response
            {
                Console.Write($"{question} (y/n): ");         // I ask the user the question with a (y/n) prompt
                string input = Console.ReadLine()?.Trim().ToLower(); // I read their input, trim spaces, and lowercase it for safe comparison

                switch (input)                                // I evaluate their response using a switch
                {
                    case "y": return true;                    // If they type "y", I return true
                    case "n": return false;                   // If they type "n", I return false
                    default:
                        Console.WriteLine("Please type 'y' or 'n'."); // If they type anything else, I explain what’s valid
                        break;                                // Loop again
                }
            }
        }

        // -------------------------------------------------------------
        // MENU SYSTEMS & USER PROMPTS
        // -------------------------------------------------------------

        public static string PromptFollowUpMenu(string[] options) // I use this method when I want to offer a short follow-up menu (like Try Again / Return)
        {
            for (int i = 0; i < options.Length; i++)               // I loop through each item in the options array
                Console.WriteLine($"{i + 1} - {options[i]}");      // I print each option with a number starting from 1

            Console.Write("Choice: ");                             // I prompt the user to make a selection
            return Console.ReadLine()?.Trim() ?? "";               // I return what they typed, trimming whitespace and handling null input safely
        }

        public static string DisplayMenu(string title, string[] options) // This is a full menu system that includes a title and numbered choices
        {
            Console.WriteLine($"\n-- {title} --");                // I print a section heading to make the menu visually distinct

            for (int i = 0; i < options.Length; i++)              // I loop through the options array
                Console.WriteLine($"{i + 1} - {options[i]}");     // I display each option with a number (1-based)

            Console.Write("Select an option: ");                  // I prompt the user to choose
            return Console.ReadLine()?.Trim() ?? "";              // I return the trimmed selection string or empty if null
        }

        public static int GetIndexedChoice(string label, int count, bool includeCancel = true) // This method lets the user pick an item from a list by number
        {
            while (true)                                          // I keep looping until the user gives a valid numeric selection
            {
                Console.Write($"{label} (1 to {count}{(includeCancel ? $", {count + 1} = Cancel" : "")}): "); // I show a prompt with optional cancel

                bool valid = int.TryParse(Console.ReadLine(), out int index); // I try to convert the input to an integer safely

                if (valid && index >= 1 && index <= (includeCancel ? count + 1 : count)) // I check if the input is in the valid range
                    return index;                               // If it is, I return that selection

                Console.WriteLine("Invalid selection. Try again."); // Otherwise, I give feedback and try again
            }
        }


        // -------------------------------------------------------------
        // UI DRAWING TOOLS
        // -------------------------------------------------------------

        public static void DrawBox(string[] lines)              // I use this to draw a stylized box with text lines inside
        {
            Console.Clear();                                   // I clear the screen so the box starts clean

            Console.WriteLine("╔════════════════════════════════════════╗"); // I draw the top border of the box

            foreach (string line in lines)                     // I loop through every string in the provided array
                Console.WriteLine($"║ {line.PadRight(38)} ║"); // I draw each line inside the box, padded to maintain the shape

            Console.WriteLine("╚════════════════════════════════════════╝"); // I draw the bottom border of the box
        }

        public static void OverwriteLine(int lineNumber, string message) // This method writes a single line of text at a specific row in the console
        {
            Console.SetCursorPosition(2, lineNumber);          // I move the cursor to the correct row, leaving 2 spaces for box margin
            Console.Write(message.PadRight(38));               // I write the message, padded with spaces to overwrite anything previously there
        }

        public static void ClearLines(int fromLine, int toLine) // I use this to clear multiple lines in the console (usually inside a drawn box)
        {
            for (int i = fromLine; i <= toLine; i++)           // I loop from the start line to the end line
                OverwriteLine(i, "");                          // I clear each line by writing an empty padded string
        }

    }
}


/*
=============================================================================
UTILITIES.CS – SHARED TOOLBOX
-----------------------------------------------------------------------------
✓ DRY input handling:
  - ReadInt, ReadDouble, ReadPositiveInt, ReadIntInRange, ReadNonEmptyString
✓ Array utilities:
  - PrintArray<T>(), ReverseArray<T>()
✓ Menus and logic routing:
  - DisplayMenu(), PromptFollowUpMenu(), Confirm(), GetIndexedChoice()
✓ Console flow and user interaction:
  - Pause(), Delay(), OverwriteLine(), DrawBox(), ClearLines()
-----------------------------------------------------------------------------
USAGE EXAMPLES:
int age = Utilities.ReadIntInRange("Enter age: ", 0, 130);
double r = Utilities.ReadPositiveDouble("Enter radius: ");
if (!Utilities.Confirm("Try again?")) return;
Utilities.ClearLines(10, 12);
string choice = Utilities.DisplayMenu("Main Menu", new[] { "A", "B", "Exit" });
-----------------------------------------------------------------------------
Every method is tested against Assignments 1.1–1.3 and reusable across future parts.
This is your permanent toolbox for clean, DRY, production-quality console code.
=============================================================================
*/
