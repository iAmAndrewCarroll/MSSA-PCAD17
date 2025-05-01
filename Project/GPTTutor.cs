using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using StudyBank.FlashCards;
using StudyBank.Helpers;

namespace StudyBank
{
    public static class GPTTutor
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiUrl = "https://api.openai.com/v1/chat/completions";
        private const string Model = "gpt-3.5-turbo";
        private const double Temperature = 0.1;
        private const int MaxTokens = 3000;

        public static async Task<string> ExplainAnswerAsync(string cardType, string prompt, string correctAnswer)
        {
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey))
                return "(GPT unavailable: missing OPENAI_API_KEY)";

            string systemPrompt = LoadSystemPrompt("prompt.txt") ?? "You are a C# tutor.";

            var messages = new object[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user", content = $"Explain this {cardType} flashcard.\nPrompt: {prompt}\nAnswer: {correctAnswer}" }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
            {
                Content = new StringContent(JsonSerializer.Serialize(new
                {
                    model = Model,
                    messages,
                    temperature = Temperature,
                    max_tokens = MaxTokens
                }), Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var response = await httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return $"GPT error: {response.StatusCode}";

                using var doc = JsonDocument.Parse(body);
                return doc.RootElement
                          .GetProperty("choices")[0]
                          .GetProperty("message")
                          .GetProperty("content")
                          .GetString()?.Trim() ?? "(No explanation)";
            }
            catch (Exception ex)
            {
                return $"GPT Exception: {ex.Message}";
            }
        }

        public static async Task<FlashCard?> GenerateFromTopic(string program, string module, string topic)
        {
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey)) return null;

            string systemPrompt = LoadSystemPrompt("prompt.txt") ?? "You are a C# tutor who generates flashcards.";

            var messages = new object[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user", content = $"Generate a flashcard for:\nProgram: {program}\nModule: {module}\nTopic: {topic}\nOutput only JSON. Do not explain anything." }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
            {
                Content = new StringContent(JsonSerializer.Serialize(new
                {
                    model = Model,
                    messages,
                    temperature = Temperature,
                    max_tokens = MaxTokens
                }), Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var response = await httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("GPT Error: " + response.StatusCode);
                    return null;
                }

                var json = ExtractJsonBlock(body);
                if (json == null) return null;

                (bool isValid, string reason) = CardValidator.ValidateFillInCardJson(json);
                if (!isValid)
                {
                    Console.WriteLine("❌ Invalid card structure: " + reason);
                    return null;
                }

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                string prompt = root.GetProperty("prompt").GetString() ?? "";
                string explanation = root.TryGetProperty("explanation", out var explProp) ? explProp.GetString() ?? "" : "";

                // Type 1: DynamicFillInCard (answers[])
                if (root.TryGetProperty("answers", out var answersProp) && answersProp.ValueKind == JsonValueKind.Array)
                {
                    var answers = new Dictionary<string, string>();
                    int i = 1;
                    foreach (var answer in answersProp.EnumerateArray())
                        answers[$"___{i++}"] = answer.GetString() ?? "";

                    return new DynamicFillInCard(prompt, answers)
                    {
                        Explanation = explanation
                    };
                }

                // Type 2: FillInCard (single answer)
                if (root.TryGetProperty("answer", out var answerProp) && answerProp.ValueKind == JsonValueKind.String)
                {
                    return new FillInCard(prompt, answerProp.GetString() ?? "")
                    {
                        Explanation = explanation
                    };
                }

                // Type 3: MultipleChoiceCard
                if (root.TryGetProperty("correctAnswer", out var correctAnswerProp) &&
                    root.TryGetProperty("options", out var optionsProp) &&
                    optionsProp.ValueKind == JsonValueKind.Array)
                {
                    var options = new List<string>();
                    foreach (var option in optionsProp.EnumerateArray())
                        options.Add(option.GetString() ?? "");

                    return new MultipleChoiceCard(prompt, correctAnswerProp.GetString() ?? "", options)
                    {
                        Explanation = explanation
                    };
                }

                Console.WriteLine("⚠️ Could not determine card type.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GPT error: " + ex.Message);
                return null;
            }
        }

        private static string? ExtractJsonBlock(string content)
        {
            int start = content.IndexOf('{');
            int end = content.LastIndexOf('}');
            if (start == -1 || end == -1 || end <= start)
                return null;

            return content.Substring(start, end - start + 1);
        }

        private static string? LoadSystemPrompt(string path)
        {
            try
            {
                return File.Exists(path) ? File.ReadAllText(path).Trim() : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
