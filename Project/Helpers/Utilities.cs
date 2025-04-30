using System;
using System.IO;
using System.Text;
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

        // String Validator
        public static bool IsValidString(string input, string? fieldName = null)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                if (!string.IsNullOrEmpty(fieldName))
                {
                    Console.WriteLine($"{fieldName} cannot be blank.");
                }
                else
                {
                    Console.WriteLine("Input cannot be blank.");
                }

                return false;
            }

            return true;
        }

        // Prompts for user credentials and returns a (username, password) tuple
        public static (string userId, string password) ReadCredentials()
        {
            Console.Write("User ID: ");
            string userId = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine()?.Trim() ?? "";

            return (userId, password);
        }
        
        // Pre-validated Credential Version
        public static (string userId, string password) ReadValidatedCredentials()
        {
            string userId = ReadNonEmptyString("User ID: ");
            string password = ReadNonEmptyString("Password: ");
            return (userId, password);
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

        public static void Delay(int milliseconds = 499)
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
        // FILE I/O HELPERS – TEXT FILES
        // -------------------------------------------------------------

        // Overwrites or creates a file with a full block of content
        public static void WriteTextFile(string path, string content)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing file: " + e.Message);
            }
        }

        // Appends content to an existing file. Creates the file if it doesn't exist.
        public static void AppendTextFile(string path, string content)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, append: true))
                {
                    sw.WriteLine(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error appending to file: " + e.Message);
            }
        }

        // Reads all text from a file and returns it as a string.
        // Returns empty string if the file does not exist or an error occurs.
        public static string ReadTextFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
                return "";
            }
        }

        // Checks whether a file exists at the specified path
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        // Writes an array of strings to a file (each element on a new line)
        public static void WriteLinesToFile(string path, string[] lines)
        {
            try
            {
                File.WriteAllLines(path, lines);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing lines to file: " + e.Message);
            }
        }

        // Reads all lines from a file and returns them as an array of strings
        public static string[] ReadLinesFromFile(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading lines from file: " + e.Message);
                return new string[0];
            }
        }


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
