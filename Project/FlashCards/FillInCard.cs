using System;
using System.IO.Pipes;
using Assignment_Tools;  // for validated user input; utilities.cs
using StudyBank.FlashCards;

namespace StudyBank.FlashCards
{
    public class FillInCard : FlashCard
    {
        // The correct ansewr to match against user input
        public string Answer {  get; set; }

        // Constructor
        public FillInCard(string prompt, string answer) : base(prompt)
        {
            Answer = answer;
        }

        // Implements the Run method from the base class
        public override void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Fill-in-the-Blank --");
            Console.WriteLine("Complete the following:");

            Console.WriteLine($"\n{Prompt}");
            string userInput = Utilities.ReadNonEmptyString("\nYour Answer: ");

            Console.WriteLine();

            if (userInput.Trim() == Answer.Trim())
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("INCORRECT.");
                Console.WriteLine($"Expected: {Answer}");
            }

            if (!string.IsNullOrWhiteSpace(Explanation))
            {
                Console.WriteLine($"\nExplanation: {Explanation}");
            }

            Utilities.Pause();
        }
    }
}
