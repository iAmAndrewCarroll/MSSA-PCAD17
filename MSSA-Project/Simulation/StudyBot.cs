using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSA_Project.Utility;
using MSSA_Project.Models;

namespace MSSA_Project.Simulation
{
    public class StudyBot
    {
        private readonly CardStateManager cardState;
        private readonly MainPage mainPage;
        private readonly string mode;
        private readonly double accuracy; // e.g. 0.75 means 75% correct answers

        public StudyBot(CardStateManager state, MainPage page, string mode = "method", double accuracy = 0.8)
        {
            cardState = state;
            mainPage = page;
            this.mode = mode;
            this.accuracy = accuracy;
        }

        public async Task RunAsync()
        {
            DebugLogger.Log("StudyBot starting...");

            for (int i = 0; i < cardState.TotalCards; i++)
            {
                var card = cardState.GetCurrentCard();
                if (card == null) break;

                bool wasCorrect = Random.Shared.NextDouble() < accuracy;

                AnswerUtility.TrackPerformance(card, wasCorrect, mode);
                await AnswerUtility.SavePerformanceLogAsync();

                DebugLogger.Log($"StudyBot answered: {card.Id}, Correct: {wasCorrect}");

                cardState.Next();
                MainThread.BeginInvokeOnMainThread(() => mainPage.DisplayCurrentCard());
                await Task.Delay(1000); // simulate human delay
            }

            DebugLogger.Log("StudyBot finished.");
        }
    }
}
