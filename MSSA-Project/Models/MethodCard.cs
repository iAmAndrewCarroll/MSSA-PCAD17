using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MSSA_Project.Models
{

    public interface ICard
    {
        string Id { get; }
        string DisplayTitle { get; }
        string DisplayBody(); // returns a readable prompt string
    }

    public class AssignmentCard : ICard
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("assignment")]
        public string Assignment { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [JsonPropertyName("focus")]
        public string Focus { get; set; }

        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }

        [JsonPropertyName("methodProblem")]
        public ProblemBlock MethodProblem { get; set; }

        [JsonPropertyName("syntaxProblem")]
        public ProblemBlock SyntaxProblem { get; set; }

        public string DisplayTitle => $"Assignment: {Title}";

        public string DisplayBody()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Assignment: {Assignment}");
            sb.AppendLine($"Difficulty: {Difficulty}");
            sb.AppendLine($"Source: {Source}");
            sb.AppendLine($"Focus: {Focus}");
            sb.AppendLine($"Tags: {string.Join(", ", Tags ?? new())}");
            sb.AppendLine();

            if (MethodProblem != null)
            {
                sb.AppendLine("--- Method Problem ---");
                sb.AppendLine($"Description: {MethodProblem.Description}");
                sb.AppendLine($"Variables: {MethodProblem.Variables}");
                sb.AppendLine($"Example: {MethodProblem.Example}");
                //sb.AppendLine($"Hint: {MethodProblem.Hint}");
                sb.AppendLine();
            }

            if (SyntaxProblem != null)
            {
                sb.AppendLine("--- Syntax Problem ---");
                sb.AppendLine($"Description: {SyntaxProblem.Description}");
                sb.AppendLine($"Variables: {SyntaxProblem.Variables}");
                sb.AppendLine($"Example: {SyntaxProblem.Example}");
                //sb.AppendLine($"Hint: {SyntaxProblem.Hint}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

    }

    public class ProblemBlock
    {
        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("prompt")]
        public List<string>? Prompt { get; set; }

        [JsonPropertyName("answers")]
        public List<string>? Answers { get; set; }

        [JsonPropertyName("variables")]
        public string Variables { get; set; }

        [JsonPropertyName("example")]
        public string Example { get; set; }

        [JsonPropertyName("hint")]
        public string Hint { get; set; }
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
        public List<string> Common_Errors { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("hint")]
        public string Hint { get; set; }

        [JsonPropertyName("variables")]
        public List<string> Variables { get; set; }

        public string DisplayTitle => Title;

        public string DisplayBody()
        {
            Console.WriteLine($"Rendering DisplayBody for card: {Title}");

            return $"Skills:\n• {string.Join("\n• ", Skills ?? new())}\n\n" +
                   $"Common Errors:\n• {string.Join("\n• ", Common_Errors ?? new())}\n\n" +
                   $"Tags: {string.Join(", ", Tags ?? new())}";
        }
    }



    public class ProblemCard : ICard
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("prompt")]
        public List<string> Prompt { get; set; }

        [JsonPropertyName("answers")]
        public List<string>? Answers { get; set; }

        [JsonPropertyName("skills")]
        public List<string> Skills { get; set; }

        [JsonPropertyName("common_errors")]
        public List<string> Common_Errors { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("hint")]
        public string Hint { get; set; }

        [JsonPropertyName("variables")]
        public List<string> Variables { get; set; }
        public string DisplayTitle => $"Code Challenge ({Language})";

        public string DisplayBody()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Skills:\n• {string.Join("\n• ", Skills ?? new())}\n");
            sb.AppendLine($"Common Errors:\n• {string.Join("\n• ", Common_Errors ?? new())}\n");
            sb.AppendLine($"Tags: {string.Join(", ", Tags ?? new())}");

            //if (!string.IsNullOrWhiteSpace(Hint))
            //    sb.AppendLine($"\nHint: {Hint}");

            if (Variables?.Count > 0)
                sb.AppendLine($"\nVariables: {string.Join(", ", Variables)}");

            return sb.ToString();
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

        [JsonPropertyName("hint")]
        public string Hint { get; set; }

        [JsonPropertyName("variables")]
        public List<string> Variables { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
        public string DisplayTitle => Title;

        public string DisplayBody()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Skills:\n• {string.Join("\n• ", Skills ?? new())}\n");
            sb.AppendLine($"Common Errors:\n• {string.Join("\n• ", Common_Errors ?? new())}\n");
            sb.AppendLine($"Tags: {string.Join(", ", Tags ?? new())}");

            //if (!string.IsNullOrWhiteSpace(Hint))
                //sb.AppendLine($"\nHint: {Hint}");

            if (Variables?.Count > 0)
                sb.AppendLine($"\nVariables: {string.Join(", ", Variables)}");

            return sb.ToString();
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
}
