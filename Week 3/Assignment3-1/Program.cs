using System;
using Assignment_Tools; // gives us access to Utilities.cs
using Assignment3_1;     // connects to your Part1 class for Week 3

namespace Week_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string choice = Utilities.DisplayMenu("Main Menu – Week 3", new[]
                {
                    "Part 1 – Core Functions: Even Numbers, Leap Year, String Ops",
                    "Exit"
                });

                switch (choice)
                {
                    case "1":
                        Full.Run(); // delegates to Week 3 Full menu and logic
                        break;
                    case "2":
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Utilities.Pause();
                        break;
                }
            }
        }
    }
}
