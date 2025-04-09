# C# Code Patterns – MSSA Assignments

| Code Pattern | Beginner-Friendly Definition | Example Usage |
|--------------|------------------------------|----------------|

### Input & Output

| `Console.Write(); Console.ReadLine();` | First prints a prompt, then waits for the user to enter text. | `Console.Write("Enter name: "); string name = Console.ReadLine();` |
| `$"...{variable}..."` | String interpolation: lets you insert variable values inside a string. | `Console.WriteLine($"You entered: {value}");` |
| `double.Parse(Console.ReadLine())` | Reads user input and converts it to a `double`. Unsafe if input isn't a number. | `double num = double.Parse(Console.ReadLine());` |

### Conditional Logic & Validation

| `if (!valid)` | `!` means NOT. This checks if something is NOT valid before running the code inside. | `if (!validAge) { Console.WriteLine("Invalid age"); continue; }` |
| `if (!TryParse(...))` | Checks whether `TryParse` failed (returns false). Used for safe input validation. | `if (!int.TryParse(input, out number)) { Console.WriteLine("Invalid input"); continue; }` |
| `if (string.IsNullOrWhiteSpace(input))` | Checks if the input is empty or just spaces. Prevents saving blank values. | `if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Name required"); continue; }` |
| `choice == "1"` | Checks if user input matches the string '1'. Common for menus. | `if (choice == "1") { RunPart1(); }` |

### Control Flow

| `while (true)` | Creates a loop that repeats forever unless a `return` or `break` stops it. | `while (true) { ShowMenu(); if (choice == "4") return; }` |
| `for (int i = 0; i < count; i++)` | A loop that starts at 0 and runs while `i` is less than `count`, increasing `i` each time. | `for (int i = 0; i < people.Count; i++) { Console.WriteLine(people[i].Name); }` |
| `for (int i = array.Length - 1; i >= 0; i--)` | A reverse loop used to iterate through an array backward. | `for (int i = array.Length - 1; i >= 0; i--) { Console.Write(array[i]); }` |
| `foreach (var item in array)` | Iterates through every element in a collection or array without indexing. | `foreach (double num in array) { Console.WriteLine(num); }` |
| `switch (choice)` | Selects one of several possible blocks of code based on a variable's value. | `switch (choice) { case "1": DoThing(); break; default: Console.WriteLine("Invalid"); break; }` |

### Loop Controls

| `break;` | Stops a loop early and moves on to the next part of the program. | `if (choice == "1") { break; }` |
| `continue;` | Skips the rest of the current loop and jumps to the next round. | `if (!valid) { continue; }` |
| `return;` | Ends a method and goes back to wherever it was called from. | `if (choice == "4") { return; }` |
| `i--` | Decrements the loop counter by 1 each time. Often used in reverse loops. | `i--;` |
| `i-- // re-prompt` | Used to retry input for the same array index when invalid data is entered. | `if (!valid) { i--; continue; }` |

### Collections

| `List<Type> list = new List<Type>();` | Creates an empty list that can store multiple items of a specific type. | `List<Person> people = new List<Person>();` |
| `list[index - 1]` | Adjusts for 0-based indexing in lists when the user sees 1-based menus. | `Person person = people[index - 1];` |
| `out int variable` | Stores the result of a successful `TryParse()` conversion. | `int.TryParse(input, out int number)` |
| `double[] array = new double[5];` | Declares a new array of size 5, defaulting all values to `0`. | `double[] arr = new double[5];` |
| `double[] array = { 1, 2, 3 };` | Declares and sets specific initial values in one line. | `double[] nums = { 1, 2, 3 };` |

### Math & Utility

| `a / b; a % b;` | `/` gets how many times `b` fits in `a`; `%` gives what's left over. | `int q = 10 / 3; int r = 10 % 3;` |
| `runningTotal += value;` | Adds a value to the total. Same as `runningTotal = runningTotal + value;`. | `runningTotal += 5;` |
| `Math.Pow(value, 2)` | Used to square a number in C#. Exponentiation is not done with `^` like in some other languages. | `double area = Math.PI * Math.Pow(radius, 2);` |
| `Math.PI` | Built-in constant that represents the mathematical value of pi. Often used in circle or sphere calculations. | `double area = Math.PI * Math.Pow(radius, 2);` |

### Custom Helper Methods (DRY)

| `PrintArray(array)` | Custom method that loops through an array and prints its elements. Used to avoid repeating printing code. | `PrintArray(myArray);` |
| `PrintArrayReversed(array)` | Custom method that prints array elements in reverse. Uses a decrementing loop internally. | `PrintArrayReversed(myArray);` |
