using System;
using System.Security.Cryptography.X509Certificates;
using Assignment_Tools;  // access Utilities.cs
using StudyBank.FlashCards; // Namespace where FlashCard types live
using StudyBank.Helpers;    // FlashCardLoader
using StudyBank.Runner;     // FlashCardRunner.cs

namespace StudyBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true) // keeps us running until user exits
            {
                Console.Clear();

                // High level menu
                string choice = Utilities.DisplayMenu("Flashcard Study Bank", new[]
                {
                    "Week 1 - Basics",
                    "Week 2 - Conditionals",
                    "Week 3 - Arrays & Loops",
                    "Week 4 - Methods & CLasses",
                    "Exit"
                });

                // Routing logic based on user input
                switch (choice)
                {
                    case "1":
                        LoadAndRunWeek("Week1.json", "Week 1 – Basics");
                        break;
                    case "2":
                        LoadAndRunWeek("Week2.json", "Week 2 – Conditionals");
                        break;
                    case "3":
                        LoadAndRunWeek("Week3.json", "Week 3 – Arrays & Loops");
                        break;
                    case "4":
                        LoadAndRunWeek("Week4.json", "Week 4 – Methods & Classes");
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Utilities.Pause();
                        break;
                }
            }
        }

        // Helper method: loads flashcard set from a file and starts the runner
        private static void LoadAndRunWeek(string filename, string title)
        {
            string path = $"Weeks/{filename}"; // assumes relative path within project dir

            var flashcards = FlashCardLoader.LoadFromFile(path);

            if (flashcards.Count == 0)
            {
                Console.WriteLine("No flashcards found or failed to load.");
                Utilities.Pause();
                return;
            }

            FlashCardRunner.Run(flashcards, title);  // starts session with loaded cards
        }
    }
}