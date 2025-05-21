/*
# Assignment 1.2 – Problem Prompts

## 1. Check for Equality
Write a C# Sharp program to accept two integers and check whether they are equal or not.

### Test Data:
Input 1st number: 5  
Input 2nd number: 5  

**Expected Output:**  
5 and 5 are equal

### Test Data:
Input 1st number: 5  
Input 2nd number: 15  

**Expected Output:**  
5 and 15 are not equal

---

## 2. Sum of First 10 Natural Numbers
Write a C# Sharp program to find the sum of the first 10 natural numbers.

**Expected Output:**  
The first 10 natural numbers are:  
1 2 3 4 5 6 7 8 9 10  
The Sum is: 55

---

## 3. Menu-Driven Calculator
Write a menu-driven application to perform calculation functions like addition, subtraction, 
multiplication, and division. Call them appropriately when the user selects the option. 
Give the user the option to continue or exit the program.
*/


using System; // we import the buil-in tools

namespace Assignment1_2 // this organizes code into logical groups
{
    public class Program // public makes a class or method accessible from other places
                         // class: container for methods and variables
    {
        public static void Main(string[] args) // static: tied to the class itself; no object required
                                               // void: the method doesn't return a value
        {
            while (true)
            {
                Console.WriteLine("\n-- Assignment 1.2 Menu --");
                Console.WriteLine("1 - Check if two numbers are equal");
                Console.WriteLine("2 - Sum of first 10 natural numbers");
                Console.WriteLine("3 - Basic Calculator");
                Console.WriteLine("4 - Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                if (choice == "1") Part1.Run(); // Run() is the custom method name (like a function in Python)
                else if (choice == "2") Part2.Run();
                else if (choice == "3") Part3.Run();
                else if (choice == "4") return;
                else Console.WriteLine("Invalid choice.");
            }
        }
    }
}