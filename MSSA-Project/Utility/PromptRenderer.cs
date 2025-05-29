using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Collections.Generic;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace MSSA_Project.Utility
{
    public static class PromptRenderer
    {
        private static readonly Regex placeholderPattern = new(@"___(\d+)___", RegexOptions.Compiled);

        // Tracks all Entry fields by ClassId (e.g., "blank-1")
        private static Dictionary<string, List<Entry>> syncGroups = new();

        public static View RenderInlinePrompt(string promptLine)
        {
            var layout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Start
            };

            int lastIndex = 0;
            foreach (Match match in placeholderPattern.Matches(promptLine))
            {
                // Add static label before the blank
                if (match.Index > lastIndex)
                {
                    string before = promptLine.Substring(lastIndex, match.Index - lastIndex);
                    layout.Children.Add(new Label
                    {
                        Text = before,
                        FontSize = 14,
                        FontFamily = "Courier New",
                        TextColor = Colors.White
                    });
                }

                string classId = $"blank-{match.Groups[1].Value}";

                // Create synced Entry
                var inputEntry = new Entry
                {
                    Placeholder = match.Value,
                    ClassId = classId,
                    FontSize = 12,
                    FontFamily = "Courier New",
                    TextColor = Colors.LimeGreen,
                    BackgroundColor = Colors.Transparent,
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HeightRequest = 20,
                    Margin = 0,
                    HorizontalOptions = LayoutOptions.Fill
                };

                // Add to sync group
                if (!syncGroups.ContainsKey(classId))
                    syncGroups[classId] = new List<Entry>();

                syncGroups[classId].Add(inputEntry);

                // Sync live input to all other entries with same ClassId
                inputEntry.TextChanged += (s, e) =>
                {
                    if (syncGroups.TryGetValue(classId, out var linkedEntries))
                    {
                        foreach (var other in linkedEntries)
                        {
                            if (other != inputEntry)
                                other.Text = inputEntry.Text;
                        }
                    }
                };

                // Add Entry wrapped in Border
                layout.Children.Add(new Border
                {
                    Stroke = Colors.Gray,
                    StrokeThickness = 1,
                    Background = new SolidColorBrush(Colors.DarkSlateGray),
                    HeightRequest = 24,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    StrokeShape = new RoundRectangle
                    {
                        CornerRadius = new CornerRadius(5, 5, 5, 5)
                    },
                    Content = inputEntry
                });

                lastIndex = match.Index + match.Length;
            }

            // Add any trailing static text
            if (lastIndex < promptLine.Length)
            {
                string after = promptLine.Substring(lastIndex);
                layout.Children.Add(new Label
                {
                    Text = after,
                    FontSize = 14,
                    FontFamily = "Courier New",
                    TextColor = Colors.White
                });
            }

            return layout;
        }

        public static void RenderPrompt(Models.ProblemCard card, Layout inputStack)
        {
            syncGroups.Clear(); // Clear sync state
            inputStack.Children.Clear();

            foreach (var line in card.Prompt)
            {
                var row = RenderInlinePrompt(line);
                inputStack.Children.Add(row);
            }
        }

        public static void RenderAssignmentPrompt(Models.AssignmentCard card, Layout inputStack, string mode)
        {
            syncGroups.Clear(); // Clear sync state
            inputStack.Children.Clear();

            var block = mode.ToLower() == "method"
                ? card.MethodProblem
                : card.SyntaxProblem;

            if (block == null || block.Prompt == null)
                return;

            foreach (var line in block.Prompt)
            {
                var row = RenderInlinePrompt(line);
                inputStack.Children.Add(row);
            }
        }
    }
}
