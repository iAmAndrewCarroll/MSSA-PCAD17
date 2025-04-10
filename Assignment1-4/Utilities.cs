using System;
using System.Threading;

namespace Assignment_Tools
{
    public static class Utilities
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

        // -------------------------------------------------------------
        // USER INPUT METHODS
        // -------------------------------------------------------------

        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int result);

                if (success)
                    return result;

                Console.WriteLine("Invalid input. Whole numbers only.");
            }
        }

        public static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int result);

                if (success && result > 0)
                    return result;

                Console.WriteLine("Invalid input. Enter a number greater than 0.");
            }
        }

        public static int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                bool valid = int.TryParse(Console.ReadLine(), out int result);

                if (valid && result >= min && result <= max)
                    return result;

                Console.WriteLine($"Enter a number between {min} and {max}.");
            }
        }
        // Usage: int age = Utilities.ReadIntInRange("Enter age: ", 0, 130);

        public static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                bool success = double.TryParse(input, out double result);

                if (success)
                    return result;

                Console.WriteLine("Invalid input. Decimal numbers only.");
            }
        }

        public static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                bool success = double.TryParse(input, out double result);

                if (success && result > 0)
                    return result;

                Console.WriteLine("Positive decimal numbers only.");
            }
        }

        public static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty.");
            }
        }

        // -------------------------------------------------------------
        // ARRAY HELPERS – GENERIC
        // -------------------------------------------------------------

        public static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
                Console.Write(item + " ");
            Console.WriteLine();
        }
        // Usage: Utilities.PrintArray(myArray);

        public static T[] ReverseArray<T>(T[] original)
        {
            int length = original.Length;
            T[] reversed = new T[length];

            for (int i = 0; i < length; i++)
                reversed[i] = original[length - 1 - i];

            return reversed;
        }
        // Usage: var reversed = Utilities.ReverseArray(myArray);

        // -------------------------------------------------------------
        // FLOW CONTROL & INTERACTION TOOLS
        // -------------------------------------------------------------

        public static void Delay(int milliseconds = 799)
        {
            Thread.Sleep(milliseconds);
        }

        public static void Pause(string message = "Press ENTER to continue...")
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public static bool Confirm(string question)
        {
            while (true)
            {
                Console.Write($"{question} (y/n): ");
                string input = Console.ReadLine()?.Trim().ToLower();

                switch (input)
                {
                    case "y": return true;
                    case "n": return false;
                    default:
                        Console.WriteLine("Please type 'y' or 'n'.");
                        break;
                }
            }
        }
        // Usage: if (!Utilities.Confirm("Would you like to continue?")) return;

        public static string PromptFollowUpMenu(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine($"{i + 1} - {options[i]}");

            Console.Write("Choice: ");
            return Console.ReadLine()?.Trim() ?? "";
        }
        // Usage:
        // switch (Utilities.PromptFollowUpMenu(new[] { "Try Again", "Return" }))
        // {
        //     case "1": continue;
        //     case "2": return;
        //     default: return;
        // }

        public static string DisplayMenu(string title, string[] options)
        {
            Console.WriteLine($"\n-- {title} --");
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine($"{i + 1} - {options[i]}");

            Console.Write("Select an option: ");
            return Console.ReadLine()?.Trim() ?? "";
        }
        // Usage:
        // string choice = Utilities.DisplayMenu("Main Menu", new[] { "Part1", "Part2", "Exit" });

        public static int GetIndexedChoice(string label, int count, bool includeCancel = true)
        {
            while (true)
            {
                Console.Write($"{label} (1 to {count}{(includeCancel ? $", {count + 1} = Cancel" : "")}): ");
                bool valid = int.TryParse(Console.ReadLine(), out int index);

                if (valid && index >= 1 && index <= (includeCancel ? count + 1 : count))
                    return index;

                Console.WriteLine("Invalid selection. Try again.");
            }
        }
        // Usage:
        // int selection = Utilities.GetIndexedChoice("Select a record", people.Count);
        // if (selection == people.Count + 1) return;

        // -------------------------------------------------------------
        // UI DRAWING TOOLS
        // -------------------------------------------------------------

        public static void DrawBox(string[] lines)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            foreach (string line in lines)
                Console.WriteLine($"║ {line.PadRight(38)} ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
        }

        public static void OverwriteLine(int lineNumber, string message)
        {
            Console.SetCursorPosition(2, lineNumber);
            Console.Write(message.PadRight(38));
        }

        public static void ClearLines(int fromLine, int toLine)
        {
            for (int i = fromLine; i <= toLine; i++)
                OverwriteLine(i, "");
        }
        // Usage: Utilities.ClearLines(10, 12);
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
