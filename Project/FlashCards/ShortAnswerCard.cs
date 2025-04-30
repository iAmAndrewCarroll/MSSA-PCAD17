using System;
using Assignment_Tools;
using StudyBank.FlashCards;

namespace StudyBank.FlashCards
{
    internal class ShortAnswerCard : FlashCard
    {
        // The expected answer (optional for now - feedback is manual / self-check)
        public string Expected {  get; set; }

        // Constructor
        public ShortAnswerCard(string prompt, string expected = "", string explanation = "")
            : base(prompt)
        {
            Expected = expected;
            Explanation = explanation;
        }

        public override void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Short Answer --");
            Console.WriteLine($"Question:\n\n{Prompt}");

            Console.WriteLine();
            string response = Utilities.ReadNonEmptyString("Your response: ");
            Console.WriteLine();

            // Show expected answer (optional) and explanation
            if (!string.IsNullOrWhiteSpace(Expected))
            {
                Console.WriteLine($"Suggested Answer:\n{Expected}");
            }

            if (!string.IsNullOrWhiteSpace(Explanation))
            {
                Console.WriteLine($"\nExplanation: {Explanation}");
            }

            Utilities.Pause();
        }
    }
}
