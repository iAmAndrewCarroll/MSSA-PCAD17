# C# Code Patterns – Assignments 1.1 & 1.2

| Code Pattern | Beginner-Friendly Definition | Example Usage |
|--------------|------------------------------|----------------|
| `int i = 0; i < count; i++` | A loop that starts at 0 and runs while `i` is less than `count`, increasing `i` each time. | `for (int i = 0; i < people.Count; i++) { Console.WriteLine(people[i].Name); }` |
| `while (true)` | Creates a loop that repeats forever unless a `return` or `break` stops it. | `while (true) { ShowMenu(); if (choice == "4") return; }` |
| `if (!valid)` | `!` means NOT. This checks if something is NOT valid before running the code inside. | `if (!validAge) { Console.WriteLine("Invalid age"); continue; }` |
| `if (!TryParse(...))` | Checks whether `TryParse` failed (returns false). Used for safe input validation. | `if (!int.TryParse(input, out number)) { Console.WriteLine("Invalid input"); continue; }` |
| `if (string.IsNullOrWhiteSpace(input))` | Checks if the input is empty or just spaces. Prevents saving blank values. | `if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Name required"); continue; }` |
| `List<Type> list = new List<Type>();` | Creates an empty list that can store multiple items of a specific type. | `List<Person> people = new List<Person>();` |
| `list[index - 1]` | Adjusts for 0-based indexing in lists when the user sees 1-based menus. | `Person person = people[index - 1];` |
| `Console.Write(); Console.ReadLine();` | First prints a prompt, then waits for the user to enter text. | `Console.Write("Enter name: "); string name = Console.ReadLine();` |
| `break;` | Stops a loop early and moves on to the next part of the program. | `if (choice == "1") { break; }` |
| `continue;` | Skips the rest of the current loop and jumps to the next round. | `if (!valid) { continue; }` |
| `return;` | Ends a method and goes back to wherever it was called from. | `if (choice == "4") { return; }` |
| `out int variable` | Stores the result of a successful `TryParse()` conversion. | `int.TryParse(input, out int number)` |
| `$"...{variable}..."` | String interpolation: lets you insert variable values inside a string. | `Console.WriteLine($"You entered: {value}");` |
| `a / b; a % b;` | `/` gets how many times `b` fits in `a`; `%` gives what's left over. | `int q = 10 / 3; int r = 10 % 3;` |
| `choice == "1"` | Checks if user input matches the string '1'. Common for menus. | `if (choice == "1") { RunPart1(); }` |
| `runningTotal += value;` | Adds a value to the total. Same as `runningTotal = runningTotal + value;`. | `runningTotal += 5;` |
| `switch (choice)` | Selects one of several possible blocks of code based on a variable's value. | `switch (choice) { case "1": DoThing(); break; default: Console.WriteLine("Invalid"); break; }` |
| `Math.Pow(value, 2)` | Used to square a number in C#. Exponentiation is not done with `^` like in some other languages. | `double area = Math.PI * Math.Pow(radius, 2);` |
| `for (int i = array.Length - 1; i >= 0; i--)` | A reverse loop used to iterate through an array backward. | `for (int i = array.Length - 1; i >= 0; i--) { Console.Write(array[i]); }` |
| `i--` | Decrements the loop counter by 1 each time. Often used in reverse loops. | `i--;` |
| `i-- // re-prompt` | Used to retry input for the same array index when invalid data is entered. | `if (!valid) { i--; continue; }` |