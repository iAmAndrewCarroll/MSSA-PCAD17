using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StudyBank.FlashCards;

namespace StudyBank
{
    public static class GPTTutor
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private static readonly string ApiUrl = "https://api.openai.com/v1/chat/completions";
        private const string Model = "gpt-3.5-turbo";
        private const double Temperature = 0.2;
        private const int MaxTokens = 5000;

        public static async Task<string> ExplainAnswerAsync(string cardType, string prompt, string correctAnswer)
        {
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey))
                return "(GPT unavailable: missing OPENAI_API_KEY environment variable)";

            string systemPrompt = LoadSystemPrompt("prompt.txt") ??
                "You are a C# tutor. Provide concise and accurate academic explanations for syntax, patterns, and usage.";

            var messages = new object[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user", content = $"This is a {cardType} flashcard.\nPrompt: {prompt}\nExpected Answer: {correctAnswer}\n\nExplain why this is the correct answer." }
            };

            string jsonRequest = JsonSerializer.Serialize(new
            {
                model = Model,
                messages = messages,
                temperature = Temperature,
                max_tokens = MaxTokens
            });

            var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var response = await httpClient.SendAsync(request);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return $"GPT Error ({response.StatusCode}): {jsonResponse}";

                using var doc = JsonDocument.Parse(jsonResponse);
                return doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString()?
                    .Trim() ?? "(No explanation received)";
            }
            catch (Exception ex)
            {
                return $"GPT Exception: {ex.Message}";
            }
        }

        public static async Task<FillInCard?> GenerateFillInCardFromMethod(string methodName)
        {
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey)) return null;

            string systemPrompt = LoadSystemPrompt("prompt.txt") ??
                "You are a C# tutor who generates structured fill-in-the-blank questions for method drills.";

            var messages = new object[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user", content = $"Generate a new fill-in-the-blank flashcard for practicing the C# method `{methodName}`. Output in this exact JSON format:\n\n{{\n  \"prompt\": \"...\",\n  \"answer\": \"...\",\n  \"explanation\": \"...\"\n}}\n\nUse proper syntax, focus on interview readiness, and do not include any additional commentary." }
            };

            string jsonRequest = JsonSerializer.Serialize(new
            {
                model = Model,
                messages = messages,
                temperature = Temperature,
                max_tokens = MaxTokens
            });

            var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var response = await httpClient.SendAsync(request);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return null;

                using var doc = JsonDocument.Parse(jsonResponse);
                string content = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString() ?? "";

                // Attempt to parse the JSON block from the content
                var jsonStart = content.IndexOf('{');
                var jsonEnd = content.LastIndexOf('}');
                if (jsonStart == -1 || jsonEnd == -1 || jsonEnd <= jsonStart)
                    return null;

                string cleanedJson = content.Substring(jsonStart, jsonEnd - jsonStart + 1);
                var data = JsonSerializer.Deserialize<FlashCardDTO>(cleanedJson);

                if (data == null) return null;

                return new FillInCard(data.prompt, data.answer)
                {
                    Explanation = data.explanation
                };
            }
            catch
            {
                return null;
            }
        }

        public static async Task<FillInCard?> GenerateFillInCardForWeek(int week)
        {
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey)) return null;

            string systemPrompt = LoadSystemPrompt("prompt.txt") ??
                "You are a C# tutor. Generate practical syntax flashcards using fill-in-the-blank format.";

            string topic = GetWeekTopic(week);
            if (string.IsNullOrEmpty(topic)) return null;

            var messages = new object[]
            {
        new { role = "system", content = systemPrompt },
        new
        {
            role = "user",
            content = $"Generate a new fill-in-the-blank flashcard for Week {week}: {topic}.\n" +
                      "Only output valid JSON like this:\n" +
                      "{\n  \"prompt\": \"...\",\n  \"answer\": \"...\",\n  \"explanation\": \"...\"\n}"
        }
            };

            string jsonRequest = JsonSerializer.Serialize(new
            {
                model = Model,
                messages = messages,
                temperature = Temperature,
                max_tokens = MaxTokens
            });

            var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var response = await httpClient.SendAsync(request);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return null;

                using var doc = JsonDocument.Parse(jsonResponse);
                string content = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString() ?? "";

                // Try to isolate and parse the JSON object
                var jsonStart = content.IndexOf('{');
                var jsonEnd = content.LastIndexOf('}');
                if (jsonStart == -1 || jsonEnd == -1 || jsonEnd <= jsonStart)
                    return null;

                string jsonBlock = content.Substring(jsonStart, jsonEnd - jsonStart + 1);
                var data = JsonSerializer.Deserialize<FlashCardDTO>(jsonBlock);

                if (data == null) return null;

                return new FillInCard(data.prompt, data.answer)
                {
                    Explanation = data.explanation
                };
            }
            catch
            {
                return null;
            }
        }

        private static string LoadSystemPrompt(string path)
        {
            try
            {
                return File.Exists(path) ? File.ReadAllText(path).Trim() : "";
            }
            catch
            {
                return "";
            }
        }

        private static string GetWeekTopic(int week)
        {
            return week switch
            {
                1 => "Variables, Data Types, Console Input/Output",
                2 => "Conditionals, Loops, and Control Flow",
                3 => "Arrays, Indexing, and Iteration",
                4 => "Methods, Parameters, Return Types, and Static Modifiers",
                _ => ""
            };
        }

        private class FlashCardDTO
        {
            public string prompt { get; set; } = "";
            public string answer { get; set; } = "";
            public string explanation { get; set; } = "";
        }
    }
}
