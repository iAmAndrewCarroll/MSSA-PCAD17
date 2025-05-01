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
    public static class RoslynCardSession
    {
        private static readonly string[] ExcludedFileNames =
        {
            "Program.cs", "GPTTutor.cs", "Secrets", "RoslynCardSession", ".env"
        };

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("🧠 Roslyn Flashcard Session\n");

            string projectRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..");
            var methods = LoadAllMethods(projectRoot);

            if (methods.Count == 0)
            {
                Console.WriteLine("❌ No usable methods found.");
                Utilities.Pause();
                return;
            }

            var cards = new List<DynamicFillInCard>();

            foreach (var (_, methodCode) in methods)
            {
                try
                {
                    var card = RoslynBlanker.GenerateDynamicCardFromMethod(methodCode);
                    cards.Add(card);
                }
                catch
                {
                    // Silently skip malformed or unparseable methods
                }
            }

            if (cards.Count == 0)
            {
                Console.WriteLine("❌ No flashcards could be generated.");
                Utilities.Pause();
                return;
            }

            Console.WriteLine($"✅ {cards.Count} flashcards generated.\n");

            int index = 0;
            while (index < cards.Count)
            {
                cards[index++].Run().Wait();

                if (!Utilities.Confirm("🔁 Try another flashcard?: "))
                    break;

                Console.Clear();
            }
        }

        private static List<(string Name, string Code)> LoadAllMethods(string rootPath)
        {
            var methods = new List<(string, string)>();

            foreach (var file in Directory.EnumerateFiles(rootPath, "*.cs", SearchOption.AllDirectories))
            {
                string fullPath = Path.GetFullPath(file).Replace("\\", "/").ToLower();

                if (fullPath.Contains("/bin/") || fullPath.Contains("/obj/"))
                    continue;

                if (ExcludedFileNames.Any(exclude => fullPath.EndsWith(exclude.ToLower())))
                    continue;

                string code = File.ReadAllText(file);
                var tree = CSharpSyntaxTree.ParseText(code);
                var root = tree.GetRoot();

                var classNodes = root.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();

                foreach (var classNode in classNodes)
                {
                    var methodNodes = classNode.DescendantNodes().OfType<MethodDeclarationSyntax>().ToList();

                    foreach (var method in methodNodes)
                    {
                        if (method.Identifier.Text == classNode.Identifier.Text)
                            continue; // skip constructors

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
