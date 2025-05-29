using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSA_Project.Models;

namespace MSSA_Project.Utility
{
    internal class HintRender
    {
        public static string? GetHint(ICard card, bool isSyntaxMode)
        {
            if (card is ProblemCard pc)
            {
                return pc.Hint;
            }

            if (card is AssignmentCard ac)
            {
                var block = isSyntaxMode ? ac.SyntaxProblem : ac.MethodProblem;
                return block?.Hint;
            }

            return null;
        }

        public static class ModeService
        {
            public static string GetModeString(bool toggle) => toggle ? "syntax" : "method";
            public static string GetModeLabel(bool toggle) => toggle ? "Syntax" : "Method";
        }
    }
}
