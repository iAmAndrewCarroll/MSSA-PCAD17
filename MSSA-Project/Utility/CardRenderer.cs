using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MSSA_Project.Models;

namespace MSSA_Project.Utility
{
    public static class CardRenderer
    {
        public static string GetAssignmentDisplayBody(AssignmentCard card, string mode)
        {
            var block = mode == "syntax" ? card.SyntaxProblem : card.MethodProblem;

            var sb = new StringBuilder();
            sb.AppendLine($"Assignment: {card.Assignment}");
            sb.AppendLine($"Difficulty: {card.Difficulty}");
            sb.AppendLine($"Source: {card.Source}");
            sb.AppendLine($"Focus: {card.Focus}");
            sb.AppendLine($"Tags: {string.Join(", ", card.Tags ?? new())}");
            sb.AppendLine();
            sb.AppendLine($"--- {mode.ToUpper()} Problem ---");
            sb.AppendLine($"Description: {block.Description}");
            sb.AppendLine($"Variables: {block.Variables}");
            sb.AppendLine($"Example: {block.Example}");
            //sb.AppendLine($"Hint: {block.Hint}");

            return sb.ToString();
        }

        public static void Render(ICard card, StackLayout targetStack, string mode = "method")
        {
            targetStack.Children.Clear();

            if (card is ProblemCard pc)
            {
                PromptRenderer.RenderPrompt(pc, targetStack);
            }
            else if (card is AssignmentCard ac)
            {
                PromptRenderer.RenderAssignmentPrompt(ac, targetStack, mode);
            }
            else if (card is WhiteboardCard wc)
            {
                targetStack.Children.Add(new Label
                {
                    Text = wc.Restate,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 18,
                    TextColor = Colors.LightSkyBlue
                });

                if (!string.IsNullOrWhiteSpace(wc.Code_Example))
                {
                    targetStack.Children.Add(new Label
                    {
                        Text = wc.Code_Example,
                        FontFamily = "Courier New",
                        FontSize = 14,
                        TextColor = Colors.White
                    });
                }

                AddBulletSection(targetStack, "Logic Steps", wc.Logic_Steps);
                AddBulletSection(targetStack, "Edge Cases", wc.Edge_Cases);
                AddBulletSection(targetStack, "Pseudocode", wc.Pseudo_Code);
            }
            else
            {
                targetStack.Children.Add(new Label
                {
                    Text = "No input required for this card.",
                    FontSize = 12,
                    TextColor = Colors.Gray
                });
            }
        }

        private static void AddBulletSection(StackLayout stack, string header, List<string> items)
        {
            if (items == null || items.Count == 0) return;

            stack.Children.Add(new Label
            {
                Text = $"\n{header}:",
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.MediumPurple,
                FontSize = 16
            });

            foreach (var item in items)
            {
                stack.Children.Add(new Label
                {
                    Text = "- " + item,
                    FontSize = 14,
                    TextColor = Colors.White
                });
            }
        }
    }
}
