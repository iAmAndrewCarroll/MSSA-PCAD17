using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MSSA_Project.Utility
{
    public static class ReviewService
    {
        /// <summary>
        /// Updates the review feedback label with either "Reviewing: X of Y" or "For Review: Y"
        /// depending on whether review mode is currently enabled.
        /// </summary>
        /// <param name="cardId">The ID of the current card.</param>
        /// <param name="reviewQueue">The list of card IDs marked for review.</param>
        /// <param name="isReviewMode">Whether review mode is currently active.</param>
        /// <param name="feedbackLabel">The label to update for review status.</param>
        public static void UpdateReviewLabel(string cardId, List<string> reviewQueue, bool isReviewMode, Label feedbackLabel)
        {
            if (isReviewMode)
            {
                if (reviewQueue.Count > 0)
                {
                    int index = reviewQueue.IndexOf(cardId);
                    int position = (index >= 0) ? index + 1 : 1;

                    feedbackLabel.Text = $"Reviewing: {position} of {reviewQueue.Count}";
                    feedbackLabel.TextColor = Colors.Orange;
                    feedbackLabel.IsVisible = true;
                }
                else
                {
                    feedbackLabel.Text = "";
                    feedbackLabel.IsVisible = false;
                }
            }
            else
            {
                if (reviewQueue.Count > 0)
                {
                    feedbackLabel.Text = $"For Review: {reviewQueue.Count}";
                    feedbackLabel.TextColor = Colors.Orange;
                    feedbackLabel.IsVisible = true;
                }
                else
                {
                    feedbackLabel.Text = "";
                    feedbackLabel.IsVisible = false;
                }
            }
        }
    }
}
