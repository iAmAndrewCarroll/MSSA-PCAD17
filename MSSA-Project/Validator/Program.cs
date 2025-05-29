using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Validator.Models;

namespace Validator
{
    public static class JsonValidator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting JSON validation...");

            Validate<List<MethodCard>>("Raw/methods.json");
            Validate<List<ProblemCard>>("Raw/methodProblems.json");
            Validate<List<SolutionCard>>("Raw/methodSolutions.json");
            Validate<List<MethodCard>>("Raw/syntax.json");
            Validate<List<ProblemCard>>("Raw/syntaxProblems.json");
            Validate<List<SolutionCard>>("Raw/syntaxSolutions.json");
            Validate<List<WhiteboardCard>>("Raw/whiteboard.json");

            Console.WriteLine("Validation complete.");
        }

        private static void Validate<T>(string path)
        {
            Console.WriteLine($"=> Validating: {path}");

            try
            {
                string json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (data == null)
                {
                    Console.WriteLine("Deserialized object is null.");
                }
                else
                {
                    Console.WriteLine("Loaded successfully: " + data.GetType().Name);
                    Console.WriteLine("   - Entries: " + ((data as System.Collections.ICollection)?.Count ?? -1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
