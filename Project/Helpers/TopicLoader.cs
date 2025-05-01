using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StudyBank.Helpers
{
    public static class TopicLoader
    {
        private static readonly string CurriculumPath = "Truth/curriculum.json";

        // Stores the full nested curriculum: Program -> Module -> List of Topics
        private static Dictionary<string, Dictionary<string, List<string>>> _curriculum;

        static TopicLoader()
        {
            try
            {
                if (!File.Exists(CurriculumPath))
                    throw new FileNotFoundException("Missing curriculum.json at: " + CurriculumPath);

                string json = File.ReadAllText(CurriculumPath);
                _curriculum = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<string>>>>(json)
                              ?? new Dictionary<string, Dictionary<string, List<string>>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading curriculum.json: " + ex.Message);
                _curriculum = new Dictionary<string, Dictionary<string, List<string>>>();
            }
        }

        // Returns the full curriculum as a nested dictionary
        public static Dictionary<string, Dictionary<string, List<string>>> GetCurriculum()
        {
            return _curriculum;
        }

        // Returns a flat list of all top-level programs
        public static List<string> GetAllPrograms()
        {
            return new List<string>(_curriculum.Keys);
        }

        // Returns module titles under a specific program
        public static List<string> GetModules(string program)
        {
            if (_curriculum.TryGetValue(program, out var modules))
                return new List<string>(modules.Keys);

            return new List<string>();
        }

        // Returns topics for a specific program + module
        public static List<string> GetTopics(string program, string module)
        {
            if (_curriculum.TryGetValue(program, out var modules) &&
                modules.TryGetValue(module, out var topics))
                return topics;

            return new List<string>();
        }

        // Returns a complete hierarchical dictionary of Program → Module → Topics
        public static Dictionary<string, Dictionary<string, List<string>>> GetAllTopics()
        {
            return _curriculum;
        }

        // Returns a random topic (for testing)
        public static (string program, string module, string topic) GetRandomTopic()
        {
            var rand = new Random();

            var programs = GetAllPrograms();
            if (programs.Count == 0) return ("", "", "");

            string program = programs[rand.Next(programs.Count)];
            var modules = GetModules(program);
            if (modules.Count == 0) return (program, "", "");

            string module = modules[rand.Next(modules.Count)];
            var topics = GetTopics(program, module);
            if (topics.Count == 0) return (program, module, "");

            string topic = topics[rand.Next(topics.Count)];
            return (program, module, topic);
        }
    }
}
