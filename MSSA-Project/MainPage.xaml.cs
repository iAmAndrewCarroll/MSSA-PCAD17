using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MSSA_Project.Models;
using MSSA_Project.Utility;
using static MSSA_Project.Utility.HintRender;

namespace MSSA_Project
{
    public partial class MainPage : ContentPage
    {

        private CardStateManager cardState = new();
        private Dictionary<string, int> lastIndexPerDeck = new();
        //private List<ICard> allCards = new();
        //private readonly List<string> reviewQueue = new();
        //private HashSet<string> completedCards = new();

        //private int currentIndex = 0;
        private bool isHintVisible = false;
        //private bool isReviewMode = false;
        //private string? lastReviewCardId = null;
        //private string? lastNonReviewCardId = null;

        public MainPage()
        {
            InitializeComponent();
            _ = AnswerUtility.LoadPerformanceLogAsync(); // Fire-and-forget async load
            //DebugLogger.OutputLabel = feedbackLabel;
        }

        private async Task LoadCards(string cardType)
        {
            try
            {
                var allCards = await CardLoader.LoadAsync(cardType);
                cardState.LoadDeck(cardType, allCards);

                if (allCards.Count > 0)
                {
                    DisplayCurrentCard();
                }
                else
                {
                    UIService.DisplayError(promptLabel, "No Cards Loaded...");

                }
            }
            catch (Exception ex)
            {
                DisplayError($"Failed to load {cardType} cards: {ex.Message}");
            }
        }


        //private async Task LoadCardsAsync(string filename, string cardType)
        //{
        //    DebugLogger.Log("LOADCARDSASYNC TRIGGERED");
        //    try
        //    {
        //        DebugLogger.Log($"Loading {cardType} cards from {filename}...");

        //        switch (cardType.ToLower())
        //        {
        //            case "assignment cards":
        //                var assignmentCards = await JsonLoader.LoadJsonAsync<List<AssignmentCard>>("Resources/Raw/Assignments.json") ?? new();
        //                allCards = assignmentCards.Cast<ICard>().ToList();
        //                break;

        //            case "method review":
        //                var methodCards = await JsonLoader.LoadJsonAsync<List<MethodCard>>("Resources/Raw/methods.json") ?? new();
        //                allCards = methodCards.Cast<ICard>().ToList();
        //                break;

        //            case "method problems":
        //                var methodProblemCards = await JsonLoader.LoadJsonAsync<List<ProblemCard>>("Resources/Raw/methodCards.json") ?? new();
        //                allCards = methodProblemCards.Cast<ICard>().ToList();
        //                break;

        //            case "syntax review":
        //                var syntaxCards = await JsonLoader.LoadJsonAsync<List<SyntaxCard>>("Resources/Raw/syntax.json") ?? new();
        //                allCards = syntaxCards.Cast<ICard>().ToList();
        //                break;

        //            case "syntax problems":
        //                var syntaxProblemCards = await JsonLoader.LoadJsonAsync<List<ProblemCard>>("Resources/Raw/syntaxCards.json") ?? new();
        //                allCards = syntaxProblemCards.Cast<ICard>().ToList();
        //                break;

        //            case "whiteboard":
        //                var whiteboardCards = await JsonLoader.LoadJsonAsync<List<WhiteboardCard>>("Resources/Raw/whiteboard.json") ?? new();
        //                allCards = whiteboardCards.Cast<ICard>().ToList();
        //                break;

        //            default:
        //                throw new ArgumentException("Unsupported card type");
        //        }

        //        DebugLogger.Log($"Loaded {allCards.Count} {cardType} cards.");

        //        reviewQueue.RemoveAll(id => !allCards.Any(c => c.Id == id));

        //        if (allCards.Count > 0)
        //        {
        //            DisplayCurrentCard();
        //        }
        //        else
        //        {
        //            DisplayError("No Cards Loaded...");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DebugLogger.Log($"Exception during LoadCardsAsync: {ex.Message}");
        //        DisplayError($"Failed to load {cardType} cards: {ex.Message}");
        //    }
        //}
        public void DisplayCurrentCard()
        {
            if (cardState == null || cardState.TotalCards == 0)
            {
                DisplayError("No cards loaded.");
                return;
            }

            var card = cardState.GetCurrentCard();

            // New: adjust grid for whiteboard full-width
            bool isWhiteboard = card is WhiteboardCard;

            promptGrid.ColumnDefinitions.Clear();

            if (isWhiteboard)
            {
                promptGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                Grid.SetColumn(promptArea, 0);
                Grid.SetColumnSpan(promptArea, 2);

                inputArea.IsVisible = false;
                submitButton.IsVisible = false;
            }
            else
            {
                promptGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) });
                promptGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(6, GridUnitType.Star) });

                Grid.SetColumn(promptArea, 0);
                Grid.SetColumnSpan(promptArea, 1);

                inputArea.IsVisible = true;
                submitButton.IsVisible = true;
            }

            // Reset input + hint UI
            modeSwitchContainer.IsVisible = card is AssignmentCard;
            inputStack.Children.Clear();
            feedbackLabel.Text = "";
            hintLabel.Text = "";
            hintLabel.IsVisible = false;
            isHintVisible = false;
            hintButton.Text = "Show Hint";

            // Set page title
            pageTitleLabel.Text = card.DisplayTitle;

            // Prompt display
            string mode = modeSwitch.IsToggled ? "syntax" : "method";
            if (card is AssignmentCard ac && (
                (mode == "syntax" && ac.SyntaxProblem != null) ||
                (mode == "method" && ac.MethodProblem != null)))
            {
                promptLabel.Text = CardRenderer.GetAssignmentDisplayBody(ac, mode);
            }
            else
            {
                promptLabel.Text = card.DisplayBody();
            }


            // Feedback label: position tracker
            feedbackLabel.Text = cardState.IsReviewMode
                ? $"Reviewing: {cardState.GetReviewQueuePosition()} of {cardState.ReviewQueueCount}"
                : $"Card {cardState.CurrentIndex + 1} of {cardState.TotalCards}";

            // Render input prompt
            bool isRenderableCard = card is ProblemCard || card is AssignmentCard || card is WhiteboardCard;
            if (isRenderableCard)
            {
                CardRenderer.Render(card, inputStack, mode);
            }
            else
            {
                inputStack.Children.Add(new Label
                {
                    Text = "No input required for this card.",
                    FontSize = 12,
                    TextColor = Colors.Gray
                });
            }

            // Review label
            ReviewService.UpdateReviewLabel(
                card.Id,
                cardState.GetReviewQueue(),
                cardState.IsReviewMode,
                reviewFeedbackLabel
            );

            cardState.RememberCurrentIndex();
        }

        private void DisplayError(string message)
        {
            promptLabel.Text = message;
            feedbackLabel.Text = "";
        }

        private async void OnCardTypeChanged(object sender, EventArgs e)
        {
            if (cardTypePicker.SelectedIndex == -1)
                return;

            string selected = cardTypePicker.SelectedItem.ToString().ToLower();

            switch (selected)
            {
                case "project overview":
                case "assignment cards":
                case "method problems":
                case "syntax problems":
                case "whiteboard":
                    await LoadCards(selected); 
                    break;

                default:
                    DisplayError("Unsupported card type.");
                    break;
            }
        }
        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (cardState == null || cardState.TotalCards == 0) return;

            var card = cardState.GetCurrentCard();
            var userAnswers = AnswerUtility.CollectAnswersFromLayout(inputStack);

            List<string> correctAnswers = new();

            string mode = modeSwitch.IsToggled ? "syntax" : "method";

            if (card is ProblemCard pc)
            {
                correctAnswers = pc.Answers;
            }
            else if (card is AssignmentCard ac)
            {
                correctAnswers = mode == "syntax"
                    ? ac.SyntaxProblem.Answers
                    : ac.MethodProblem.Answers;
            }

            var result = AnswerUtility.ValidateWithDetails(userAnswers, correctAnswers);
            AnswerUtility.TrackPerformance(card, result.AllCorrect, mode);
            await AnswerUtility.SavePerformanceLogAsync();

            var (allCorrect, cardId, shouldAdvance, shouldExitReview) =
                cardState.ProcessSubmission(userAnswers, correctAnswers);

            if (cardState.IsReviewMode && cardState.ReviewQueueCount == 0)
            {
                reviewSwitch.Toggled -= OnReviewToggled;
                reviewSwitch.IsToggled = false;
                reviewSwitch.Toggled += OnReviewToggled;
                return;
            }

            if (shouldAdvance)
            {
                DisplayCurrentCard();
                await Task.Delay(50);
                AnswerUtility.ApplyAnswersToLayout(inputStack, userAnswers);
                AnswerUtility.HighlightAnswerBoxes(inputStack, result);
            }
            else
            {
                AnswerUtility.HighlightAnswerBoxes(inputStack, result);
                AnswerUtility.ApplyAnswersToLayout(inputStack, userAnswers);
            }

            feedbackLabel.Text = result.Message;
            feedbackLabel.TextColor = result.Color;
            //AnswerUtility.HighlightAnswerBoxes(inputStack, result);
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            if (cardState == null || cardState.TotalCards == 0)
                return;

            cardState.Next();
            DisplayCurrentCard();
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            if (cardState == null || cardState.TotalCards == 0)
                return;

            cardState.Previous();
            DisplayCurrentCard();
        }

        private void OnHintClicked(object sender, EventArgs e)
        {
            if (cardState == null || cardState.TotalCards == 0) return;

            var card = cardState.GetCurrentCard();
            string? hintText = HintRender.GetHint(card, modeSwitch.IsToggled);

            if (!string.IsNullOrWhiteSpace(hintText))
            {
                isHintVisible = !isHintVisible;
                hintLabel.IsVisible = isHintVisible;
                hintLabel.Text = isHintVisible ? hintText : "";
                hintButton.Text = isHintVisible ? "Hide Hint" : "Show Hint";
            }
        }

        private void OnReviewToggled(object sender, ToggledEventArgs e)
        {
            bool success = cardState.OnReviewToggle(e.Value);

            if (!success)
            {
                reviewSwitch.Toggled -= OnReviewToggled;
                reviewSwitch.IsToggled = false;
                reviewSwitch.Toggled += OnReviewToggled;

                UIService.DisplayError(reviewFeedbackLabel, "No reviewable cards in the current deck.");
                UIService.FadeOut(reviewFeedbackLabel);
                return;
            }

            DisplayCurrentCard();
        }

        private void OnModeToggled(object sender, ToggledEventArgs e)
        {
            if (cardState == null || cardState.TotalCards == 0) return;

            hintLabel.Text = "";
            hintLabel.IsVisible = false;
            isHintVisible = false;
            hintButton.Text = "Show Hint";

            var card = cardState.GetCurrentCard();

            if (card is AssignmentCard ac)
            {
                string mode = ModeService.GetModeString(e.Value);
                modeLabel.Text = ModeService.GetModeLabel(e.Value);

                promptLabel.Text = CardRenderer.GetAssignmentDisplayBody(ac, mode);
                CardRenderer.Render(ac, inputStack, mode);
            }
        }

        private async void OnStatsClicked(object sender, EventArgs e)
        {
            var statsPage = new MSSA_Project.StatsPage(cardState);
            await Navigation.PushAsync(statsPage);
        }


        public async Task ResumeLastSession()
        {
            if (cardState == null) return;

            string lastDeck = cardState.GetCurrentDeck();
            await LoadCards(lastDeck);
            DisplayCurrentCard(); // This will use CurrentIndex already remembered
        }

        private void OnShowPathClicked(object sender, EventArgs e)
        {
            ShowPerformanceFilePath();
        }
        private async void ShowPerformanceFilePath()
        {
            string path = PerformanceStorage.GetFilePath();
            await DisplayAlert("Performance File Path", path, "OK");
        }

        private async void OnRunBotClicked(object sender, EventArgs e)
        {
            if (cardState == null || cardState.TotalCards == 0)
            {
                await DisplayAlert("StudyBot", "No cards are loaded. Load a deck first.", "OK");
                return;
            }

            var bot = new Simulation.StudyBot(cardState, this, modeSwitch.IsToggled ? "syntax" : "method", 0.85);
            await bot.RunAsync();

            await DisplayAlert("StudyBot", "Simulation complete. Performance data has been updated.", "OK");
        }


        private async void OnTestAssignmentClicked(object sender, EventArgs e)
        {
            var first = await JsonTester.LoadFirstAssignmentCardAsync();

            if (first == null)
            {
                await DisplayAlert("TEST FAIL", "No cards loaded or deserialization failed.", "OK");
                return;
            }

            var summary = $"ID: {first.Id}\nTitle: {first.Title}\nPrompt 1: {first.MethodProblem?.Prompt?[0] ?? "null"}";

            await DisplayAlert("AssignmentCard Loaded", summary, "OK");
        }




        //private void OnNextClicked(object sender, EventArgs e)
        //{
        //    if (allCards.Count == 0)
        //        return;

        //    if (isReviewMode)
        //    {
        //        if (reviewQueue.Count == 0)
        //        {
        //            DisplayError("Review queue is empty.");
        //            return;
        //        }

        //        var currentId = allCards[currentIndex].Id;
        //        int reviewPos = reviewQueue.IndexOf(currentId);

        //        if (reviewPos == -1)
        //        {
        //            currentIndex = allCards.FindIndex(c => c.Id == reviewQueue[0]);
        //            DisplayCurrentCard();
        //            return;
        //        }

        //        int nextPos = (reviewPos + 1) % reviewQueue.Count;
        //        string nextId = reviewQueue[nextPos];

        //        currentIndex = allCards.FindIndex(c => c.Id == nextId);
        //        DisplayCurrentCard();
        //    }
        //    else
        //    {
        //        currentIndex = (currentIndex + 1) % allCards.Count;
        //        DisplayCurrentCard();
        //    }
        //}





        //private void OnPreviousClicked(object sender, EventArgs e)
        //{
        //    if (allCards.Count == 0)
        //        return;

        //    if (isReviewMode)
        //    {
        //        var currentId = allCards[currentIndex].Id;

        //        if (reviewQueue.Count == 0)
        //        {
        //            DisplayError("Review queue is empty.");
        //            return;
        //        }

        //        var reviewPos = reviewQueue.IndexOf(currentId);

        //        if (reviewPos == -1)
        //        {
        //            currentIndex = allCards.FindIndex(c => c.Id == reviewQueue[0]);
        //        }
        //        else
        //        {
        //            int prevPos = (reviewPos - 1 + reviewQueue.Count) % reviewQueue.Count;
        //            string prevId = reviewQueue[prevPos];
        //            currentIndex = allCards.FindIndex(c => c.Id == prevId);
        //        }

        //        DisplayCurrentCard();
        //    }
        //    else
        //    {
        //        currentIndex = (currentIndex - 1 + allCards.Count) % allCards.Count;
        //        DisplayCurrentCard();
        //    }
        //} 

        //private void OnSubmitClicked(object sender, EventArgs e)
        //{
        //    if (allCards.Count == 0) return;

        //    var card = allCards[currentIndex];
        //    var userAnswers = AnswerUtility.CollectAnswersFromLayout(inputStack);

        //    List<string> correctAnswers = new();
        //    string cardId = card.Id;

        //    if (card is ProblemCard pc)
        //    {
        //        correctAnswers = pc.Answers;
        //    }
        //    else if (card is AssignmentCard ac)
        //    {
        //        string mode = modeSwitch.IsToggled ? "syntax" : "method";
        //        correctAnswers = mode == "syntax"
        //            ? ac.SyntaxProblem.Answers
        //            : ac.MethodProblem.Answers;
        //    }

        //    var result = AnswerUtility.ValidateWithDetails(userAnswers, correctAnswers);
        //    AnswerUtility.TrackPerformance(cardId, result.AllCorrect);

        //    if (!result.AllCorrect)
        //    {
        //        if (!reviewQueue.Contains(cardId))
        //            reviewQueue.Add(cardId);
        //    }
        //    else
        //    {
        //        reviewQueue.Remove(cardId);

        //        if (!isReviewMode)
        //        {
        //            completedCards.Add(cardId);
        //        }
        //        if (lastNonReviewCardId == cardId)
        //        {
        //            int lastIndex = allCards.FindIndex(c => c.Id == lastNonReviewCardId);
        //            if (lastIndex != -1)
        //            {
        //                int nextIndex = (lastIndex + 1) % allCards.Count;
        //                lastNonReviewCardId = allCards[nextIndex].Id;
        //            }
        //        }

        //        if (isReviewMode)
        //        {
        //            if (reviewQueue.Count == 0)
        //            {
        //                isReviewMode = false;
        //                reviewSwitch.IsToggled = false;
        //                return;
        //            }

        //            string nextId = reviewQueue[0];
        //            int nextIndex = allCards.FindIndex(c => c.Id == nextId);

        //            if (nextIndex != -1)
        //            {
        //                currentIndex = nextIndex;
        //                DisplayCurrentCard();
        //                return;
        //            }
        //        }
        //    }

        //    ReviewService.UpdateReviewLabel(allCards[currentIndex].Id, reviewQueue, isReviewMode, reviewFeedbackLabel);
        //    feedbackLabel.Text = result.Message;
        //    feedbackLabel.TextColor = result.Color;
        //    AnswerUtility.HighlightAnswerBoxes(inputStack, result);

        //}

        //private void UpdateReviewLabel(string cardId)
        //{
        //    if (isReviewMode)
        //    {
        //        if (reviewQueue.Count > 0)
        //        {
        //            int position = reviewQueue.IndexOf(cardId) + 1;
        //            reviewFeedbackLabel.Text = $"Reviewing: {position} of {reviewQueue.Count}";
        //            reviewFeedbackLabel.TextColor = Colors.Orange;
        //            reviewFeedbackLabel.IsVisible = true;
        //        }
        //        else
        //        {
        //            reviewFeedbackLabel.Text = "";
        //            reviewFeedbackLabel.IsVisible = false;
        //        }
        //    }
        //    else
        //    {
        //        if (reviewQueue.Count > 0)
        //        {
        //            reviewFeedbackLabel.Text = $"For Review: {reviewQueue.Count}";
        //            reviewFeedbackLabel.TextColor = Colors.Orange;
        //            reviewFeedbackLabel.IsVisible = true;
        //        }
        //        else
        //        {
        //            reviewFeedbackLabel.Text = "";
        //            reviewFeedbackLabel.IsVisible = false;
        //        }
        //    }
        //}


        //private void OnHintClicked(object sender, EventArgs e)
        //{
        //    if (allCards.Count == 0) return;

        //    var card = allCards[currentIndex];

        //    string hintText = "";

        //    if (card is ProblemCard pc)
        //    {
        //        hintText = pc.Hint; ;
        //    }
        //    else if (card is AssignmentCard ac)
        //    {
        //        var block = modeSwitch.IsToggled ? ac.SyntaxProblem : ac.MethodProblem;
        //        if (block != null)
        //            hintText = block.Hint;
        //    }

        //    if (!string.IsNullOrWhiteSpace(hintText))
        //    {
        //        isHintVisible = !isHintVisible;
        //        hintLabel.IsVisible = isHintVisible;
        //        hintLabel.Text = isHintVisible ? hintText : "";
        //        hintButton.Text = isHintVisible ? "Hide Hint" : "Show Hint";
        //    }
        //}







        //private async void FadeOutReviewLabelAsync()
        //{
        //    await Task.Delay(2500); // wait before fading out

        //    await MainThread.InvokeOnMainThreadAsync(async () =>
        //    {
        //        await reviewFeedbackLabel.FadeTo(0, 400);
        //        reviewFeedbackLabel.IsVisible = false;
        //        reviewFeedbackLabel.Opacity = 1; // Reset
        //    });
        //}


        //private string GetAssignmentDisplayBody(AssignmentCard card, string mode)
        //{
        //    var sb = new StringBuilder();

        //    sb.AppendLine($"Assignment: {card.Assignment}");
        //    sb.AppendLine($"Difficulty: {card.Difficulty}");
        //    sb.AppendLine($"Source: {card.Source}");
        //    sb.AppendLine($"Focus: {card.Focus}");
        //    sb.AppendLine($"Tags: {string.Join(", ", card.Tags ?? new())}");
        //    sb.AppendLine();

        //    var block = mode == "syntax" ? card.SyntaxProblem : card.MethodProblem;

        //    if (block != null)
        //    {
        //        sb.AppendLine($"--- {mode.ToUpper()} Problem ---");
        //        sb.AppendLine($"Description: {block.Description}");
        //        sb.AppendLine($"Variables: {block.Variables}");
        //        sb.AppendLine($"Example: {block.Example}");
        //        sb.AppendLine($"Hint: {block.Hint}");
        //    }

        //    return sb.ToString();
        //}


    }
}
