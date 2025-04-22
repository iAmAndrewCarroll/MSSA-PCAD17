using System;
using Assignment_Tools;  // for Utilities
using Assignment3_2;     // connects to Full.cs

namespace Week_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string choice = Utilities.DisplayMenu("Main Menu – Week 3.2", new[]
                {
                    "Run Assignment 3-2 Logic",
                    "Exit"
                });

                switch (choice)
                {
                    case "1":
                        Full.Run(); // launches internal menu and logic
                        break;
                    case "2":
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Utilities.Pause();
                        break;
                }
            }
        }
    }
}
