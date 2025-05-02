using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        DotNetEnv.Env.Load();
        string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Console.WriteLine("❌ Missing API key.");
            return;
        }

        string systemPrompt = File.ReadAllText("prompt.txt").Trim();
        string method = "Array.Sort";

        var messages = new object[]
        {
            new { role = "system", content = systemPrompt },
            new { role = "user", content = $"Generate a fill-in-the-blank flashcard for: {method}" }
        };

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = messages,
            temperature = 0.2,
            max_tokens = 1000
        };

        string jsonRequest = JsonSerializer.Serialize(requestBody);

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var response = await client.PostAsync(
            "https://api.openai.com/v1/chat/completions",
            new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        );

        string jsonResponse = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"❌ GPT error: {response.StatusCode}");
            Console.WriteLine(jsonResponse);
            return;
        }

        using var doc = JsonDocument.Parse(jsonResponse);
        string content = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? "";

        Console.WriteLine("✅ GPT Response:\n");
        Console.WriteLine(content);
    }
}
