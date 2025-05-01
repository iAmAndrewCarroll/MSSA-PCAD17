using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StudyBank.FlashCards;
using StudyBank.Helpers;
using Assignment_Tools;

namespace StudyBank
{
    public static class TestRoslynFlashcard
    {
        private static readonly string[] ExcludedFileNames =
        {
            "Program.cs", "GPTTutor.cs", "Secrets", "TestRoslynFlashcard", ".env"
        };

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("🧪 Roslyn Flashcard Test\n");

            string projectRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..");
            Console.WriteLine("🔍 Scanning project root: " + Path.GetFullPath(projectRoot));

            var methods = LoadAllMethodsWithTracing(projectRoot);

            if (methods.Count == 0)
            {
                Console.WriteLine("❌ No methods found: " + Path.GetFullPath(projectRoot));
                Utilities.Pause();
                return;
            }

            Console.WriteLine($"\n✅ Found {methods.Count} method(s).");
            for (int i = 0; i < methods.Count; i++)
                Console.WriteLine($"{i + 1}. {methods[i].Name}");

            Console.Write("\nSelect a method to convert into a flashcard: ");
            int index = Utilities.ReadIntInRange("Choice: ", 1, methods.Count) - 1;

            var (methodName, methodCode) = methods[index];

            Console.WriteLine($"\n🔍 Selected: {methodName}\n");
            Console.WriteLine("Original Method Code:");
            Console.WriteLine(methodCode);
            Utilities.Pause();

            var card = RoslynBlanker.GenerateDynamicCardFromMethod(methodCode);

            Console.WriteLine("\n🧠 Flashcard Prompt:\n" + card.Prompt);
            Console.WriteLine("\n🔎 Answers:");
            foreach (var kvp in card.LabeledAnswers)
                Console.WriteLine($"{kvp.Key} = {kvp.Value}");

            Utilities.Pause("Start flashcard interaction? Press ENTER...");
            card.Run().Wait();
        }

        private static List<(string Name, string Code)> LoadAllMethodsWithTracing(string rootPath)
        {
            var methods = new List<(string, string)>();
            Console.WriteLine("🔎 Starting method scan in: " + Path.GetFullPath(rootPath));

            foreach (var file in Directory.EnumerateFiles(rootPath, "*.cs", SearchOption.AllDirectories))
            {
                string fullPath = Path.GetFullPath(file).Replace("\\", "/").ToLower();

                if (fullPath.Contains("/bin/") || fullPath.Contains("/obj/"))
                {
                    Console.WriteLine($"⏭️ Skipped build artifact: {fullPath}");
                    continue;
                }

                if (ExcludedFileNames.Any(exclude => fullPath.EndsWith(exclude.ToLower())))
                {
                    Console.WriteLine($"⛔ Skipped sensitive file: {fullPath}");
                    continue;
                }

                Console.WriteLine($"📂 Scanning file: {fullPath}");

                string code = File.ReadAllText(file);
                var tree = CSharpSyntaxTree.ParseText(code);
                var root = tree.GetRoot();

                var classNodes = root.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();
                Console.WriteLine($"  - Found {classNodes.Count} class(es)");

                foreach (var classNode in classNodes)
                {
                    var methodNodes = classNode.DescendantNodes().OfType<MethodDeclarationSyntax>().ToList();
                    Console.WriteLine($"    🔎 Class '{classNode.Identifier}': {methodNodes.Count} method(s)");

                    foreach (var method in methodNodes)
                    {
                        if (method.Identifier.Text == classNode.Identifier.Text)
                        {
                            Console.WriteLine($"      🚫 Skipped constructor: {method.Identifier.Text}()");
                            continue;
                        }

                        string methodName = method.Identifier.ToString();
                        string fullMethodCode = method.ToFullString();

                        Console.WriteLine($"      ✅ Found method: {methodName}");
                        methods.Add((methodName, fullMethodCode));
                    }
                }
            }

            Console.WriteLine($"\n🧠 Total methods loaded: {methods.Count}");
            return methods;
        }
    }
}
