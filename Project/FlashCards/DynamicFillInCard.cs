using System;
using System.Collections.Generic;
using Assignment_Tools;

namespace StudyBank.FlashCards
{
    public class DynamicFillInCard : FlashCard
    {
        public Dictionary<string, string> LabeledAnswers { get; set; }

        public override string TypeLabel => "Dynamic Fill-in-the-Blank";

        public DynamicFillInCard(string prompt, Dictionary<string, string> labeledAnswers)
            : base(prompt)
        {
            LabeledAnswers = labeledAnswers;
        }

        public override async Task Run()
        {
            Console.Clear();
            Console.WriteLine(" Fill in the blanks below:\n");
            Console.WriteLine(Prompt + "\n");

            var userAnswers = new Dictionary<string, string>();
            foreach (var blank in LabeledAnswers.Keys.OrderBy(k => k))
            {
                Console.Write($"{blank}: ");
                string input = Console.ReadLine()?.Trim() ?? "";
                userAnswers[blank] = input;
            }

            Console.WriteLine();
            int correct = 0;

            foreach (var (label, expected) in LabeledAnswers)
            {
                string input = userAnswers.GetValueOrDefault(label, "");
                if (string.Equals(input, expected, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($" {label} correct!");
                    correct++;
                }
                else
                {
                    Console.WriteLine($" {label} incorrect. Expected: {expected}");
                }
            }

            Console.WriteLine($"\n You got {correct}/{LabeledAnswers.Count} correct.");

            if (string.IsNullOrWhiteSpace(Explanation))
            {
                Explanation = await GPTTutor.ExplainAnswerAsync("DynamicFillInCard", Prompt, string.Join(", ", LabeledAnswers.Values));
            }

            Console.WriteLine("\n Explanation:");
            Console.WriteLine(Explanation);

            Utilities.Pause("\n Press ENTER to return to menu...");
        }
    }
}
