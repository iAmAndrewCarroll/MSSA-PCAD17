using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using MSSA_Project.Utility;

namespace MSSA_Project.Performance
{
    public partial class PerformancePage : ContentPage
    {
        public PerformancePage()
        {
            InitializeComponent();

            var data = AnswerUtility.PerformanceLog.Select(kvp => new CardSummary
            {
                CardId = kvp.Key,
                Attempts = kvp.Value.Attempts,
                CorrectAttempts = kvp.Value.CorrectAttempts,
                LastAttempted = kvp.Value.LastAttempted.ToString("g"),
                WasCorrectOnFirstTry = kvp.Value.WasCorrectOnFirstTry
            }).ToList();

            performanceView.ItemsSource = data;
        }
    }

    public class CardSummary
    {
        public string CardId { get; set; }
        public int Attempts { get; set; }
        public int CorrectAttempts { get; set; }
        public string LastAttempted { get; set; }
        public string CorrectRate => Attempts == 0 ? "Not attempted" : $"Accuracy: {CorrectAttempts * 100 / Attempts}%";
        public string FirstTryLabel => WasCorrectOnFirstTry ? "Yes" : "No";
        public bool WasCorrectOnFirstTry { get; set; }
    }
}
