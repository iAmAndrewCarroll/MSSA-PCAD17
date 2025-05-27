using System; // access to classes and tools in System namespace

namespace Assignment1_1 // similar to python modules and packages, namespaces help me organize code and avoid naming conflicts.
                        // They help organize code into groups like folders or directories in a file system.
                        // I can refer to this code elsewhere by using: Assignment1_1.Part1 (this is similar to a python import statement)
{
    public class Exit // classes are blueprints for organizing code.
                      // Like a container that groups methods (actions) & variables (data) together
    {
        public static void Run() // this method is called by Program.Main() upon user selection.
                                 // It's the entry point for this part.
        {
            Console.WriteLine("Thanks for checking out Assignment 1.1!");
            Console.WriteLine("Goodbye!");
            Environment.Exit(0); // Exits the application successfully
        }
    }
}