using System;
using System.IO;
using Assignment_Tools;                  // Utilities
using StudyBank.FlashCards;             // FlashCard base + children
using StudyBank.Helpers;                // TopicLoader, Utilities
using StudyBank.Runner;                 // FlashCardRunner


namespace StudyBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- StudyBank: GPT Flashcard Tutor --\n");

                string choice = Utilities.DisplayMenu("Main Menu", new[]
                {
                    "Generate a Flashcard from a Topic",
                    "Flashcard Session",
                    "Exit"
                });

                switch (choice)
                {
                    case "1":
                        GenerateFromCurriculum().Wait();
                        break;
                    case "2":
                        RoslynCardSession.Run();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Utilities.Pause();
                        break;
                }
            }
        }

        private static async Task GenerateFromCurriculum()
        {
            Console.Clear();
            Console.WriteLine("-- Generate Flashcard from Topic --");

            // Select Program
            var programs = TopicLoader.GetAllPrograms();
            int pIndex = Utilities.GetIndexedChoice("Select a program", programs.Count);
            if (pIndex > programs.Count) return;
            string program = programs[pIndex - 1];

            // Select Module
            var modules = TopicLoader.GetModules(program);
            int mIndex = Utilities.GetIndexedChoice("Select a module", modules.Count);
            if (mIndex > modules.Count) return;
            string module = modules[mIndex - 1];

            // Select Topic
            var topics = TopicLoader.GetTopics(program, module);
            int tIndex = Utilities.GetIndexedChoice("Select a topic", topics.Count);
            if (tIndex > topics.Count) return;
            string topic = topics[tIndex - 1];

            // Generate card
            Console.Clear();
            Console.WriteLine($"Generating flashcard for:\n{program} → {module} → {topic}\n");

            var card = await GPTTutor.GenerateFromTopic(program, module, topic);

            if (card == null)
            {
                Console.WriteLine("⚠️ GPT failed to generate a flashcard.");
                Utilities.Pause();
                return;
            }

            Console.WriteLine("\n🧠 Flashcard:");
            await card.Run();

            if (Utilities.Confirm("Save this card to your StudyBank?"))
            {
                SaveCardToTopic(card, program, module, topic);
                Console.WriteLine("✅ Card saved.");
            }

            Utilities.Pause();
        }

        // Save flashcard to a categorized location
        private static void SaveCardToTopic(FlashCard card, string program, string module, string topic)
        {
            string safeProgram = program.Replace(" ", "_");
            string safeModule = module.Replace(" ", "_").Replace(":", "");
            string safeTopic = topic.Replace(" ", "_").Replace(":", "");

            string dir = Path.Combine("Truth", "StudyBankCards", safeProgram, safeModule);
            Directory.CreateDirectory(dir);

            string filePath = Path.Combine(dir, $"{safeTopic}.jsonl");

            string json = System.Text.Json.JsonSerializer.Serialize(card);
            Utilities.AppendTextFile(filePath, json);
        }
    }
}
