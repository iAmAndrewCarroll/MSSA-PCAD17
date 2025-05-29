using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using MSSA_Project.Utility;
using MSSA_Project.Models;

namespace MSSA_Project
{
    public partial class StatsPage : ContentPage
    {
        private readonly CardStateManager cardState;
        public class CardSummary
        {
            public string CardId { get; set; }
            public int Attempts { get; set; }
            public int CorrectAttempts { get; set; }
            public string LastAttempted { get; set; }
            public string CorrectRate => Attempts == 0 ? "Not attempted" : $"Accuracy: {CorrectAttempts * 100 / Attempts}%";
            public string FirstTryLabel => WasCorrectOnFirstTry ? "Yes" : "No";
            public bool WasCorrectOnFirstTry { get; set; }
            public string Mode { get; set; }
            public string CardType { get; set; }
            public List<string>? Tags { get; set; }
            public List<string>? Skills { get; set; }
            public string? Source { get; set; }
        }

        public StatsPage(CardStateManager cardState)
        {
            InitializeComponent();
            this.cardState = cardState;
            var allCards = cardState.GetAllCards() ?? new List<ICard>();

            var summaries = new List<CardSummary>();

            foreach (var kvp in AnswerUtility.PerformanceLog)
            {
                var parts = kvp.Key.Split("::");
                var id = parts[0];
                var mode = parts[1];
                var type = parts[2];

                var card = allCards.FirstOrDefault(c => c.Id == id);
                if (card == null) continue;

                List<string>? tags = null;
                List<string>? skills = null;
                string? source = null;

                if (card is AssignmentCard ac)
                {
                    var problem = mode == "syntax" ? ac.SyntaxProblem : ac.MethodProblem;
                    tags = ac?.Tags;
                    skills = !string.IsNullOrEmpty(ac.Focus) ? new List<string> { ac.Focus } : null;
                    source = ac.Source;
                }
                else if (card is ProblemCard pc)
                {
                    tags = pc.Tags;
                    skills = pc.Skills;
                }

                summaries.Add(new CardSummary
                {
                    CardId = id,
                    Mode = mode,
                    CardType = type,
                    Attempts = kvp.Value.Attempts,
                    CorrectAttempts = kvp.Value.CorrectAttempts,
                    WasCorrectOnFirstTry = kvp.Value.WasCorrectOnFirstTry,
                    LastAttempted = kvp.Value.LastAttempted.ToString("g"),
                    Tags = tags,
                    Skills = skills,
                    Source = source
                });
            }

            statsView.ItemsSource = summaries.OrderBy(c => c.CardId).ThenBy(c => c.Mode).ToList();

        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");

            // Delay is necessary because MainPage UI isn't loaded until this resolves
            await Task.Delay(200);

            if (Shell.Current.CurrentPage is MainPage mainPage)
            {
                await mainPage.ResumeLastSession();
            }
        }
    }
}
