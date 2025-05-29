using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls.Platform.Compatibility;
using MSSA_Project.Models;

namespace MSSA_Project.Utility
{
    public static class AnswerUtility
    {
        public static List<string> CollectAnswersFromLayout(Layout inputStack)
        {
            var seen = new HashSet<string>(); // ClassId values
            var answers = new Dictionary<string, string>(); // ClassId → answer

            CollectEntriesRecursive(inputStack, answers, seen);

            // Return answers ordered by blank number (___1___, ___2___, etc.)
            return answers
                .OrderBy(kvp => int.Parse(kvp.Key.Replace("blank-", "")))
                .Select(kvp => kvp.Value)
                .ToList();
        }

        private static void CollectEntriesRecursive(IView view, Dictionary<string, string> answers, HashSet<string> seen)
        {
            if (view is Entry entry && entry.ClassId != null && !seen.Contains(entry.ClassId))
            {
                answers[entry.ClassId] = entry.Text?.Trim() ?? "";
                seen.Add(entry.ClassId);
                return;
            }

            if (view is Layout layout)
            {
                foreach (var child in layout.Children)
                {
                    CollectEntriesRecursive(child, answers, seen);
                }
            }

            // Safe and explicit: handle both Border and ContentView cleanly
            if (view is ContentView contentView && contentView.Content is IView content1)
            {
                CollectEntriesRecursive(content1, answers, seen);
            }
            else if (view is Border border && border.Content is IView content2)
            {
                CollectEntriesRecursive(content2, answers, seen);
            }
        }


        public static AnswerResult ValidateWithDetails(List<string> userAnswers, List<string> correctAnswers)
        {
            var result = new AnswerResult();

            if (userAnswers.Count != correctAnswers.Count)
            {
                result.Message = $"Expected {correctAnswers.Count} answers, but got {userAnswers.Count}.";
                result.Color = Colors.Orange;
                result.AllCorrect = false;
                return result;
            }

            for (int i = 0; i < correctAnswers.Count; i++)
            {
                result.Details.Add(new AnswerFeedback
                {
                    UserInput = userAnswers[i],
                    CorrectAnswer = correctAnswers[i]
                });
            }

            result.AllCorrect = result.Details.All(d => d.IsCorrect);
            result.Message = result.AllCorrect
                ? "All answers correct!"
                : $"{result.Details.Count(d => !d.IsCorrect)} incorrect answer(s).";

            result.Color = result.AllCorrect ? Colors.LimeGreen : Colors.Red;
            return result;
        }

        public static Dictionary<string, CardPerformance> PerformanceLog { get; } = new();

        public static void TrackPerformance(ICard card, bool wasCorrect, string mode)
        {
            string type = card.GetType().Name;
            string compositeKey = $"{card.Id}::{mode}::{type}";

            if (!PerformanceLog.TryGetValue(compositeKey, out var record))
            {
                record = new CardPerformance();
                PerformanceLog[compositeKey] = record;
            }

            record.Attempts++;
            if (wasCorrect) record.CorrectAttempts++;
            if (record.Attempts == 1) record.WasCorrectOnFirstTry = wasCorrect;
            record.LastAttempted = DateTime.Now;
        }

        public static void HighlightAnswerBoxes(StackLayout inputStack, AnswerResult result)
        {
            var correctnessMap = new Dictionary<string, bool>();
            for (int i = 0; i < result.Details.Count; i++)
            {
                string key = $"blank-{i + 1}";
                correctnessMap[key] = result.Details[i].IsCorrect;
            }

            foreach (var child in inputStack.Children)
            {
                HighlightRecursive(child, correctnessMap);
            }
        }

        private static void HighlightRecursive(IView view, Dictionary<string, bool> correctnessMap)
        {
            if (view is Border border && border.Content is Entry entry && entry.ClassId?.StartsWith("blank-") == true)
            {
                if (correctnessMap.TryGetValue(entry.ClassId, out bool isCorrect))
                {
                    border.Stroke = isCorrect ? Colors.LimeGreen : Colors.Red;
                    entry.TextColor = isCorrect ? Colors.LimeGreen : Colors.White;
                    entry.BackgroundColor = isCorrect
                        ? Colors.DarkGreen : Colors.Maroon;
                }
            }

            if (view is Layout layout)
            {
                foreach (var child in layout.Children)
                {
                    HighlightRecursive(child, correctnessMap);
                }
            }

            if (view is ContentView contentView && contentView.Content != null)
            {
                HighlightRecursive(contentView.Content, correctnessMap);
            }

            if (view is Border innerBorder && innerBorder.Content != null)
            {
                HighlightRecursive(innerBorder.Content, correctnessMap);
            }
        }
        public static void ApplyAnswersToLayout(StackLayout inputStack, List<string> answers)
        {
            foreach (var child in inputStack.Children)
            {
                if (child is Border border && border.Content is Entry entry && entry.ClassId?.StartsWith("blank-") == true)
                {
                    if (int.TryParse(entry.ClassId.Replace("blank-", ""), out int blankNumber))
                    {
                        int index = blankNumber - 1;
                        if (index >= 0 && index < answers.Count)
                        {
                            entry.Text = answers[index];
                        }
                    }
                }
            }
        }

        public static async Task SavePerformanceLogAsync()
        {
            await PerformanceStorage.SaveAsync(PerformanceLog);
        }

        public static async Task LoadPerformanceLogAsync()
        {
            var loaded = await PerformanceStorage.LoadAsync();
            foreach (var kvp in loaded)
            {
                PerformanceLog[kvp.Key] = kvp.Value;
            }
        }

    }

    public class AnswerResult
    {
        public bool AllCorrect { get; set; }
        public string Message { get; set; }
        public Color Color { get; set; }
        public List<AnswerFeedback> Details { get; set; } = new();
    }

    public class AnswerFeedback
    {
        public string UserInput { get; set; }
        public string CorrectAnswer { get; set; }
        public bool IsCorrect => string.Equals(UserInput, CorrectAnswer, StringComparison.OrdinalIgnoreCase);
    }

    public class CardPerformance
    {
        public int Attempts { get; set; }
        public int CorrectAttempts { get; set; }
        public bool WasCorrectOnFirstTry { get; set; }
        public DateTime LastAttempted { get; set; }
    }
}
