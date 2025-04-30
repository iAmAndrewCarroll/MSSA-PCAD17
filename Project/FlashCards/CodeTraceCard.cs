using System;
using Assignment_Tools;
using StudyBank.FlashCards;

namespace StudyBank.FlashCards
{
    public class CodeTraceCard : FlashCard
    {
        // The correct expected output from the code
        public string ExpectedOutput {  get; set; }

        // Constuctor
        public CodeTraceCard(string prompt, string expectedOutput, string explanation = "")
            : base(prompt)
        {
            ExpectedOutput = expectedOutput;
            Explanation = explanation;
        }

        public override void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Code Trace --");
            Console.WriteLine("Read the following code and predict the output:");

            Console.WriteLine("\n" + Prompt);
            string userGuess = Utilities.ReadNonEmptyString("\nYour Predicted Output: ");
            Console.WriteLine();

            if (userGuess.Trim() == ExpectedOutput.Trim())
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Not quite...");
                Console.WriteLine($"Expected Output: {ExpectedOutput}");
            }

            if (!string.IsNullOrWhiteSpace(Explanation))
            {
                Console.WriteLine($"\nExplanation: {Explanation}");
            }

            Utilities.Pause();
        }
    }
}
