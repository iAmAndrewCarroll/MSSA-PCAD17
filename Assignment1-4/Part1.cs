using System;
using Assignment_Tools; // gives access to Utilities like ReadDouble()

namespace Assignment1_4
{
    public class Part1
    {
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n-- Point Comparison Tool --");

                // prompt user for P1.X and P1.Y
                double p1x = Utilities.ReadDouble("Enter X for Point 1: ");
                double p1y = Utilities.ReadDouble("Enter Y for Point 1: ");

                // prompt user for P2.X and P2.Y
                double p2x = Utilities.ReadDouble("Enter X for Point 2: ");
                double p2y = Utilities.ReadDouble("Enter Y for Point 2: ");

                // Structs are value types, simple and fast
                Point p1 = new Point { X = p1x, Y = p1y };
                Point p2 = new Point { X = p2x, Y = p2y };

                // Compare the x
                if (p2.X > p1.X)
                    Console.WriteLine("\nPoint 2 is to the right of Point 1.");
                else if (p2.X < p1.X)
                    Console.WriteLine("\nPoint 2 is to the left of Point 1.");
                else
                    Console.WriteLine("\nPoint 2 is aligned vertically with Point 1 (same X).");

                // Follow-up menu
                switch (Utilities.PromptFollowUpMenu(new[] { "Try Another", "Return to Main Menu" }))
                {
                    case "1":
                        Console.Clear();
                        continue;
                    case "2":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Returning to Main Menu...");
                        return;
                }
            }
        }

        // Struct (value type) instead of class - use case: simple data containers
        //public struct Point
        //{
        //    public double X;
        //    public double Y;
        //}
    }

    // Class wtih X and Y properties per John's modified instructions
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}