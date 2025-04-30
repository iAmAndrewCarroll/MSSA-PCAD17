using System;
using System.Collections.Generic;
using Assignment_Tools;
using StudyBank.FlashCards;

namespace StudyBank.Runner
{
    public static class FlashCardRunner
    {
        // Entry point for running a batch of flashcards
        public static void Run(List<FlashCard> cards, string sessionTitle)
        {
            Console.Clear();
            Console.WriteLine($"==== {sessionTitle} ====");
            Console.WriteLine($"Total Cards: {cards.Count}");
            Utilities.Pause();

            for (int i = 0; i < cards.Count; i++)
            {
                Console.Clear();
                Console.WriteLine($"Card {i + 1} of {cards.Count} ({cards[i].TypeLabel})\n");

                cards[i].Run(); // each subclass (FillInCard, etc.) defines how it runs
            }

            Console.WriteLine("\nStudy session complete.");
            Utilities.Pause("Press ENTER to return to the main menu...");
        }
    }
}
