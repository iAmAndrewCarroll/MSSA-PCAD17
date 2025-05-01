using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StudyBank.Helpers
{
    public static class CodeSnippetLoader
    {
        // Known sensitive or excluded file name patterns
        private static readonly string[] ExcludedFileNames =
        {
            "Program.cs",           // entry point, config logic
            "GPTTutor.cs",          // OpenAI key usage
            "Secrets",              // potential sensitive folder
            "TestRoslynFlashcard",  // avoid recursive analysis
            ".env",                 // env var logic, even if .cs
        };

        public static List<(string Name, string Code)> LoadAllMethods(string rootPath)
        {
            var methods = new List<(string, string)>();

            foreach (var file in Directory.EnumerateFiles(rootPath, "*.cs", SearchOption.AllDirectories))
            {
                string normalized = file.Replace("\\", "/").ToLower();

                // ✅ Skip bin/obj/known-sensitive/test/config files
                if (normalized.Contains("/bin/") ||
                    normalized.Contains("/obj/") ||
                    ExcludedFileNames.Any(exclude => normalized.Contains(exclude.ToLower())))
                {
                    continue;
                }

                string code = File.ReadAllText(file);
                var tree = CSharpSyntaxTree.ParseText(code);
                var root = tree.GetRoot();

                var classNodes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                foreach (var classNode in classNodes)
                {
                    var methodNodes = classNode.DescendantNodes().OfType<MethodDeclarationSyntax>();

                    foreach (var method in methodNodes)
                    {
                        // Optional: Skip constructors
                        if (method.Identifier.Text == classNode.Identifier.Text)
                            continue;

                        string methodName = method.Identifier.ToString();
                        string fullMethodCode = method.ToFullString();

                        methods.Add((methodName, fullMethodCode));
                    }
                }
            }

            return methods;
        }
    }
}
