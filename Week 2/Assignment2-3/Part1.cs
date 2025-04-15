/*
=======================================================================
PART1.cs – Assignment 2.5: Write and Read Personal Details from a File
=======================================================================

This module demonstrates:
- Writing a string of personal details (name, age, address) to a text file
- Reading the same file and printing the contents to the console
- Using helper methods from Utilities.cs for DRY and safe file handling

| Step | What Happens                                                       | Where It Happens                         |
|------|--------------------------------------------------------------------|------------------------------------------|
| 1    | Dummy details are defined (hardcoded string or string builder)    | Local variable in Part1.Run()            |
| 2    | File path is declared                                              | e.g., `string path = "PersonalInfo.txt"` |
| 3    | `Utilities.WriteTextFile()` is called to save the string          | Writes to disk using StreamWriter        |
| 4    | File is closed automatically via using block                      | Inside Utilities.WriteTextFile()         |
| 5    | `Utilities.ReadTextFile()` is called to read the full file        | Reads file into string using StreamReader|
| 6    | File content is printed to console                                | `Console.WriteLine()`                    |
| 7    | Program waits for user before returning                           | `Utilities.Pause()`                      |

Key Concepts:
- File creation and overwrite
- Reading file contents into memory
- Full use of helper methods for abstraction and reusability
- Error handling wrapped in Utilities
*/

using System;
using System.Diagnostics;
using Assignment_Tools;

namespace Assignment2_3
{
    public class Part1
    {
        public static void Run()
        {
            Console.WriteLine("REACHED THE TOP OF PART1.RUN()");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("-- Assignment 2.5 Part1: Write and Read Personal Info --\n");

            // Step 1: Prepare dummy personal data to write to file
            string name = "Jane Doe";
            int age = 30;
            string address = "666 Baker Street, London, England";

            // Step 2 Build a multi-line string using interpolated text
            string details =
                $"Name    : {name}{Environment.NewLine}" +
                $"Age     : {age}{Environment.NewLine}" +
                $"Address : {address}{Environment.NewLine}";

            // Step 3: Define a file path (file will be created in current working dir)
            string path = Path.GetFullPath("PersonalInfo.txt");

            Console.WriteLine(">>> BEFORE DEBUG PATH OUTPUT <<<");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[DEBUG] Saving to path: {path}");
            Console.ResetColor();
            Console.WriteLine(">>> AFTER DEBUG PATH OUTPUT <<<");
            Console.WriteLine("\nPress Enter to verify path...");
            Console.ReadLine(); // <-- TEMPORARY HOLD



            // Step 4: Write the details to the text file (overwrites if it exists)
            Utilities.WriteTextFile(path, details);

            Console.WriteLine("Data successfully written to file.\n");

            // Step 5: Read the file back in as a single string
            string result = Utilities.ReadTextFile(path);

            // Step 6: Display the contents of the file to the console
            Console.WriteLine("Reading back from file:\n");
            Console.WriteLine(result);

            // Just before Pause
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[DEBUG] Final path used: {path}");
            Console.ResetColor();

            // Step 7: Pause before returning to menu
            Utilities.Pause();
        }
    }
}