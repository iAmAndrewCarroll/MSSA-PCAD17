using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StudyBank.FlashCards;

namespace StudyBank.Helpers
{
    public static class RoslynBlanker
    {
        public static DynamicFillInCard GenerateDynamicCardFromMethod(string methodCode)
        {
            string wrapped = $"class Dummy {{ {methodCode} }}";
            var tree = CSharpSyntaxTree.ParseText(wrapped);
            var root = tree.GetRoot();

            var method = root.DescendantNodes().OfType<MethodDeclarationSyntax>().FirstOrDefault();
            if (method == null)
                throw new Exception("No method declaration found.");

            var rewriter = new BlankingRewriter();
            var rewritten = rewriter.Visit(method);

            string prompt = rewritten.ToFullString();
            var labeledAnswers = rewriter.LabelToAnswerMap;

            return new DynamicFillInCard(prompt, labeledAnswers);
        }

        private class BlankingRewriter : CSharpSyntaxRewriter
        {
            private int _counter = 1;
            public Dictionary<string, string> LabelToAnswerMap { get; } = new();

            public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
            {
                var original = node.ToFullString();
                var label = $"___{_counter++}";
                LabelToAnswerMap[label] = original;

                return SyntaxFactory.IdentifierName(label)
                                     .WithLeadingTrivia(node.GetLeadingTrivia())
                                     .WithTrailingTrivia(node.GetTrailingTrivia());
            }

            public override SyntaxNode VisitLiteralExpression(LiteralExpressionSyntax node)
            {
                // Example: string literals like "Hello"
                var original = node.ToFullString();
                var label = $"___{_counter++}";
                LabelToAnswerMap[label] = original;

                return SyntaxFactory.IdentifierName(label)
                                     .WithLeadingTrivia(node.GetLeadingTrivia())
                                     .WithTrailingTrivia(node.GetTrailingTrivia());
            }
        }
    }
}
