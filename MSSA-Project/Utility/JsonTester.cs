using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSA_Project.Models;

namespace MSSA_Project.Utility
{
    public static class JsonTester
    {
        public static async Task<AssignmentCard?> LoadFirstAssignmentCardAsync()
        {
            var cards = await JsonLoader.LoadJsonAsync<List<AssignmentCard>>("Resources/Raw/Assignments.json");
            return cards?.FirstOrDefault();
        }
    }
}
