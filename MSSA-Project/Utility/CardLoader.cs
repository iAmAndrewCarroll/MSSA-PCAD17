using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSSA_Project.Models; // Or whatever namespace holds ICard, AssignmentCard, etc.

namespace MSSA_Project.Utility
{
    public static class CardLoader
    {
        public static async Task<List<ICard>> LoadAsync(string cardType)
        {
            switch (cardType.ToLower())
            {
                case "project overview":
                    var projectCards = await JsonLoader.LoadJsonAsync<List<WhiteboardCard>>("Resources/Raw/project.json") ?? new();
                    return projectCards.Cast<ICard>().ToList();

                case "assignment cards":
                    var assignmentCards = await JsonLoader.LoadJsonAsync<List<AssignmentCard>>("Resources/Raw/Assignments.json") ?? new();
                    return assignmentCards.Cast<ICard>().ToList();

                case "method problems":
                    var methodProblems = await JsonLoader.LoadJsonAsync<List<ProblemCard>>("Resources/Raw/methodCards.json") ?? new();
                    return methodProblems.Cast<ICard>().ToList();

                case "syntax problems":
                    var syntaxProblems = await JsonLoader.LoadJsonAsync<List<ProblemCard>>("Resources/Raw/syntaxCards.json") ?? new();
                    return syntaxProblems.Cast<ICard>().ToList();

                case "whiteboard":
                    var whiteboardCards = await JsonLoader.LoadJsonAsync<List<WhiteboardCard>>("Resources/Raw/whiteboard.json") ?? new();
                    return whiteboardCards.Cast<ICard>().ToList();

                default:
                    throw new ArgumentException("Unsupported card type");
            }
        }
    }
}
