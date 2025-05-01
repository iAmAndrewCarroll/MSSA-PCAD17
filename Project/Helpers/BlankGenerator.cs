using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StudyBank.Helpers
{
    public static class BlankGenerator
    {
        // Entry point: parse code and blank a set number of good tokens
        public static (string blankedCode, Dictionary<string, string> labeledAnswers) CreateBlanks(string code, int maxBlanks = 3)
        {
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();

            // Find all good candidates
            var candidates = root.DescendantNodes()
                .Where(n => n is IdentifierNameSyntax || n is LiteralExpressionSyntax)
                .Where(IsGoodCandidate)
                .Distinct()
                .ToList();

            // Adaptive blanking strategy
            int maxBasedOnSize = candidates.Count switch
            {
                <= 5 => 1,
                <= 10 => 2,
                <= 20 => 3,
                _ => 4
            };

            int blanksToUse = Math.Min(maxBlanks, maxBasedOnSize);

            // Randomly select which to blank
            var selected = candidates
                .OrderBy(n => n.GetLocation().SourceSpan.Start) // order by appearance
                .Take(blanksToUse)
                .ToList();

            var replacements = new Dictionary<SyntaxNode, SyntaxNode>();
            var labeledAnswers = new Dictionary<string, string>();
            int labelIndex = 1;

            foreach (var node in selected)
            {
                string originalText = node.ToString();
                string label = $"___{labelIndex++}";
                labeledAnswers[label] = originalText;

                SyntaxNode replacement;

                if (node is IdentifierNameSyntax)
                    replacement = SyntaxFactory.IdentifierName(label);
                else if (node is LiteralExpressionSyntax)
                    replacement = SyntaxFactory.ParseExpression(label);
                else
                    continue;

                replacements[node] = replacement;
            }

            var newRoot = root.ReplaceNodes(replacements.Keys, (orig, _) => replacements[orig]);
            string modifiedCode = newRoot.ToFullString();

            return (modifiedCode, labeledAnswers);
        }


        // Only include non-trivial, non-structural identifiers/literals
        private static bool IsGoodCandidate(SyntaxNode node)
        {
            if (node is IdentifierNameSyntax ident)
            {
                var name = ident.Identifier.Text;

                // Filter out structural/framework keywords
                var disallowed = new HashSet<string>
                {
                    "Console", "Main", "Program", "ToString", "args", "WriteLine", "ReadLine"
                };

                if (string.IsNullOrWhiteSpace(name) || disallowed.Contains(name))
                    return false;

                return true;
            }

            if (node is LiteralExpressionSyntax literal)
            {
                // Exclude '0', '1', empty strings, or too short
                var value = literal.ToString();
                if (value.Length < 3 || value == "\"\"" || value == "0" || value == "1")
                    return false;

                return true;
            }

            return false;
        }
    }
}
