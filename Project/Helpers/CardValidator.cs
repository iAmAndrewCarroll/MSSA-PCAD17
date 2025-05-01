using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace StudyBank.Helpers
{
    public static class CardValidator
    {
        // Validates the raw JSON content from GPT
        public static (bool isValid, string reason) ValidateFillInCardJson(string rawJson)
        {
            try
            {
                // Try parsing JSON into a doc
                using var doc = JsonDocument.Parse(rawJson);

                var root = doc.RootElement;

                if (!root.TryGetProperty("prompt", out var promptProp) || promptProp.ValueKind != JsonValueKind.String)
                    return (false, "Missing or invalid 'prompt' field.");

                if (!root.TryGetProperty("answers", out var answersProp) || answersProp.ValueKind != JsonValueKind.Array)
                    return (false, "Missing or invalid 'answers' field.");

                var promptText = promptProp.GetString() ?? "";
                var answerList = new List<string>();

                foreach (var item in answersProp.EnumerateArray())
                {
                    if (item.ValueKind != JsonValueKind.String)
                        return (false, "One or more answers are not strings.");
                    answerList.Add(item.GetString() ?? "");
                }

                // Count ___N-style placeholders in the prompt
                int blankCount = CountBlanks(promptText);

                if (blankCount != answerList.Count)
                    return (false, $"Mismatch between blanks in prompt ({blankCount}) and answers provided ({answerList.Count}).");

                // Explanation is optional, but if included, it must be a string
                if (root.TryGetProperty("explanation", out var explProp) &&
                    explProp.ValueKind != JsonValueKind.String)
                {
                    return (false, "Explanation must be a string.");
                }

                return (true, "Valid structure.");
            }
            catch (Exception ex)
            {
                return (false, "JSON parse error: " + ex.Message);
            }
        }

        private static int CountBlanks(string text)
        {
            // Match ___ or ___1, ___2, etc.
            var matches = Regex.Matches(text, @"___\d*");
            return matches.Count;
        }
    }
}
