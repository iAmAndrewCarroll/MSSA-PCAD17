using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Validator.Models
{
    //class Program
    //{
        public interface ICard
        {
            string Id { get; }
            string DisplayTitle { get; }
            string DisplayBody(); // returns a readable prompt string
        }

        public class MethodCard : ICard
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("skills")]
            public List<string> Skills { get; set; }

            [JsonPropertyName("common_errors")]
            public List<string> Common_Errors {  get; set; }

            [JsonPropertyName("leetcode_tags")]
            public List<string> Leetcode_Tags { get; set; }
            public string DisplayTitle => Title;

            public string DisplayBody()
            {
                Console.WriteLine($"Rendering DisplayBody for card: {Title}");

                return $"Skills:\n• {string.Join("\n• ", Skills ?? new())}\n\n" +
                       $"Common Errors:\n• {string.Join("\n• ", Common_Errors ?? new())}\n\n" +
                       $"Tags: {string.Join(", ", Leetcode_Tags ?? new())}";
            }
        }

        public class ProblemCard : ICard
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("language")]
            public string Language { get; set; }

            [JsonPropertyName("prompt")]
            public List<string> Prompt { get; set; }

            public string DisplayTitle => $"Code Challenge ({Language})";

            public string DisplayBody()
            {
                return string.Join("\n", Prompt ?? new());
            }
        }

        public class SyntaxCard : ICard
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("skills")]
            public List<string> Skills { get; set; }

            [JsonPropertyName("common_errors")]
            public List<string> Common_Errors { get; set; }

            [JsonPropertyName("tags")]
            public List<string> Tags { get; set; }
            public string DisplayTitle => Title;

            public string DisplayBody()
            {
                return $"Skills:\n• {string.Join("\n• ", Skills ?? new())}\n\n" +
                       $"Common Errors:\n• {string.Join("\n• ", Common_Errors ?? new())}\n\n" +
                       $"Tags: {string.Join(", ", Tags ?? new())}";
            }
        }

        public class SolutionCard
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("answers")]
            public List<string> Answers { get; set; }
        }

        public class WhiteboardCard : ICard
        {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("restate")]
        public string Restate { get; set; }
        [JsonPropertyName("code_example")]
        public string Code_Example { get; set; }
        [JsonPropertyName("logic_steps")]
        public List<string> Logic_Steps { get; set; }
        [JsonPropertyName("edge_cases")]
        public List<string> Edge_Cases { get; set; }
        [JsonPropertyName("pseudo_code")]
        public List<string> Pseudo_Code { get; set; }

            public string DisplayTitle => $"Whiteboard: {Id}";

            public string DisplayBody()
            {
                return $"Restate:\n{Restate}\n\n" +
                   $"Example:\n{Code_Example}\n\n" +
                   $"Logic Steps:\n- {string.Join("\n- ", Logic_Steps ?? new())}\n\n" +
                   $"Edge Cases:\n- {string.Join("\n- ", Edge_Cases ?? new())}\n\n" +
                   $"Pseudocode:\n- {string.Join("\n- ", Pseudo_Code ?? new())}";
            }
        }

    //}

}
