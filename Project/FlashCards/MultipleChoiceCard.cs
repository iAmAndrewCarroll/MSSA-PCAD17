using System;
using Assignment_Tools;
using StudyBank.FlashCards;

namespace StudyBank.FlashCards
{
    // FlashCards/MultipleChoiceCard.cs
    public class MultipleChoiceCard : FlashCard
    {
        public string CorrectAnswer { get; set; }
        public List<string> Options { get; set; }

        public override string TypeLabel => "Multiple Choice";

        public MultipleChoiceCard(string prompt, string correctAnswer, List<string> options)
            : base(prompt)
        {
            CorrectAnswer = correctAnswer;
            Options = options;
        }

        public override async Task Run()
        {
            Console.WriteLine($"\n{Prompt}");
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }

            Console.Write("\nChoose the correct option (1-4): ");
            string? input = Console.ReadLine();
            int.TryParse(input, out int selected);
            string selectedAnswer = Options.ElementAtOrDefault(selected - 1) ?? "";

            Console.WriteLine(selectedAnswer == CorrectAnswer
                ? "✅ Correct!"
                : $"❌ Incorrect. Answer: {CorrectAnswer}");

            if (!string.IsNullOrWhiteSpace(Explanation))
                Console.WriteLine($"\nExplanation: {Explanation}");

            await Task.CompletedTask;
        }
    }
}
