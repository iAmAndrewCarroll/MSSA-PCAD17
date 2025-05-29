using System.Text.Json;
using System.Text.RegularExpressions;
using MSSA_Project.Models;
using MSSA_Project.Utility;

namespace MSSA_Project
{
    public partial class MainPage : ContentPage
    {
        private List<ICard> allCards = new();

        private int currentIndex = 0;

        public MainPage()
        {
            InitializeComponent();
            DebugLogger.OutputLabel = feedbackLabel;
        }

        private async Task LoadCardsAsync(string filename, string cardType)
        {
            DebugLogger.Log("LOADCARDSASYNC TRIGGERED");
            try
            {
                DebugLogger.Log($"Loading {cardType} cards from {filename}...");

                switch (cardType.ToLower())
                {
                    case "method review":
                        var methodCards = await JsonLoader.LoadJsonAsync<List<MethodCard>>("Resources/Raw/methods.json") ?? new();
                        allCards = methodCards.Cast<ICard>().ToList();
                        break;

                    case "method problems":
                        var methodProblemCards = await JsonLoader.LoadJsonAsync<List<ProblemCard>>("Resources/Raw/methodProblems.json") ?? new();
                        allCards = methodProblemCards.Cast<ICard>().ToList();
                        break;

                    case "syntax review":
                        var syntaxCards = await JsonLoader.LoadJsonAsync<List<SyntaxCard>>("Resources/Raw/syntax.json") ?? new();
                        allCards = syntaxCards.Cast<ICard>().ToList();
                        break;

                    case "syntax problems":
                        var syntaxProblemCards = await JsonLoader.LoadJsonAsync<List<ProblemCard>>("Resources/Raw/syntaxProblems.json") ?? new();
                        allCards = syntaxProblemCards.Cast<ICard>().ToList();
                        break;

                    case "whiteboard":
                        var whiteboardCards = await JsonLoader.LoadJsonAsync<List<WhiteboardCard>>("Resources/Raw/whiteboard.json") ?? new();
                        allCards = whiteboardCards.Cast<ICard>().ToList();
                        break;

                    default:
                        throw new ArgumentException("Unsupported card type");
                }

                DebugLogger.Log($"Loaded {allCards.Count} {cardType} cards.");

                if (allCards.Count > 0)
                {
                    DisplayCurrentCard();
                }
                else
                {
                    DisplayError("No Cards Loaded...");
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Log($"Exception during LoadCardsAsync: {ex.Message}");
                DisplayError($"Failed to load {cardType} cards: {ex.Message}");
            }
        }
        private void DisplayCurrentCard()
        {
            if (allCards.Count == 0)
            {
                DisplayError("No cards loaded.");
                return;
            }

            var card = allCards[currentIndex];

            Title = card.DisplayTitle;
            promptLabel.Text = card.DisplayBody();
            feedbackLabel.Text = $"Card {currentIndex + 1} of {allCards.Count}";

            inputStack.Children.Clear();

            bool isProblemCard = card is ProblemCard;
            inputArea.IsVisible = isProblemCard;
            submitButton.IsVisible = isProblemCard;

            if (card is ProblemCard problemCard)
            {
                PromptRenderer.RenderPrompt(problemCard, inputStack);
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

            string selected = cardTypePicker.SelectedItem.ToString();

            switch (selected.ToLower())
            {
                case "method review":
                    await LoadCardsAsync("methods.json", "method review");
                    break;
                case "method problems":
                    await LoadCardsAsync("methodProblems.json", "method problems");
                    break;
                case "syntax review":
                    await LoadCardsAsync("Resources/Raw/syntax.json", "syntax review");
                    break;
                case "syntax problems":
                    await LoadCardsAsync("Resources/Raw/syntaxProblems.json", "syntax problems");
                    break;
                case "whiteboard":
                    await LoadCardsAsync("whiteboard.json", "whiteboard");
                    break;
                default:
                    DisplayError("Unsupported card type.");
                    break;
            }
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            if (allCards.Count == 0)
                return;
            currentIndex = (currentIndex + 1) % allCards.Count;
            DisplayCurrentCard();
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            if (allCards.Count == 0)
                return;
            currentIndex = (currentIndex - 1 + allCards.Count) % allCards.Count;
            DisplayCurrentCard();
        } 

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            feedbackLabel.Text = "Submit clicked.";
        }
    }
}
