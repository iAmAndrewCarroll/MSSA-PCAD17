using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using StudyBank.FlashCards;

namespace StudyBank.Helpers
{
    public static class FlashCardLoader
    {
        // Reads JSON file and returns a list of flashcards
        public static List<FlashCard> LoadFromFile(string path)
        {
            var flashcards = new List<FlashCard>();

            if (!File.Exists(path))
            {
                Console.WriteLine($"File not found: {path}");
                return flashcards;
            }

            try
            {
                string json = File.ReadAllText(path);
                using var doc = JsonDocument.Parse(json);

                foreach (var element in doc.RootElement.EnumerateArray())
                {
                    string type = element.GetProperty("type").GetString() ?? "";

                    switch (type)
                    {
                        case "FillInCard":
                            flashcards.Add(new FillInCard(
                                element.GetProperty("prompt").GetString() ?? "",
                                element.GetProperty("answer").GetString() ?? ""
                            )
                            {
                                Explanation = GetOptional(element, "explanation")
                            });
                            break;

                        case "CodeTraceCard":
                            flashcards.Add(new CodeTraceCard(
                                element.GetProperty("prompt").GetString() ?? "",
                                element.GetProperty("expectedOutput").GetString() ?? "",
                                GetOptional(element, "explanation")
                            ));
                            break;

                        case "ShortAnswerCard":
                            flashcards.Add(new ShortAnswerCard(
                                element.GetProperty("prompt").GetString() ?? "",
                                GetOptional(element, "expected"),
                                GetOptional(element, "explanation")
                            ));
                            break;

                        default:
                            Console.WriteLine($"Unknown card type: {type}");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flashcards: {ex.Message}");
            }

            return flashcards;
        }

        // Helper to avoid missing JSON property exceptions
        private static string GetOptional(JsonElement element, string property)
        {
            return element.TryGetProperty(property, out var value) ? value.GetString() ?? "" : "";
        }
    }
}
