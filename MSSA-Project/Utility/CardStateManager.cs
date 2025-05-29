using System;
using System.Collections.Generic;
using System.Linq;
using MSSA_Project.Models;

namespace MSSA_Project.Utility
{
    public class CardStateManager
    {
        private List<ICard> allCards = new();
        private readonly Dictionary<string, List<string>> reviewQueues = new();
        private readonly HashSet<string> completedCards = new();
        private readonly Dictionary<string, int> lastSeenIndexPerDeck = new();
        private string currentDeck = "";
        public List<string> GetReviewQueue() => CurrentReviewQueue;
        private List<string> CurrentReviewQueue => reviewQueues.TryGetValue(currentDeck, out var queue) ? queue : new List<string>();
        public List<ICard> GetAllCards() => allCards;
        public int ReviewQueueCount => CurrentReviewQueue.Count;
        public int TotalCards => allCards.Count;
        public int GetReviewQueuePosition() => IsReviewMode
            ? CurrentReviewQueue.IndexOf(GetCurrentCard().Id) + 1
            : 0;
        public string GetCurrentDeck() => currentDeck;

        public int CurrentIndex { get; private set; } = 0;
        public bool IsReviewMode { get; private set; } = false;
        public string? LastReviewCardId { get; set; }
        public string? LastNonReviewCardId { get; set; }

        public CardStateManager() { }

        public void LoadDeck(string deckName, List<ICard> cards)
        {
            currentDeck = deckName.ToLower();
            allCards = cards;

            if (!reviewQueues.ContainsKey(currentDeck))
            {
                reviewQueues[currentDeck] = new List<string>();
            }

            if (lastSeenIndexPerDeck.TryGetValue(currentDeck, out int savedIndex) && savedIndex < allCards.Count)
            {
                CurrentIndex = savedIndex;
            }
            else
            {
                CurrentIndex = 0;
            }
        }

        public void RememberCurrentIndex()
        {
            if (!string.IsNullOrEmpty(currentDeck))
                lastSeenIndexPerDeck[currentDeck] = CurrentIndex;
        }

        public ICard GetCurrentCard() => allCards[CurrentIndex];

        public void Next()
        {
            if (IsReviewMode && CurrentReviewQueue.Count > 0)
            {
                string currentId = allCards[CurrentIndex].Id;
                int pos = CurrentReviewQueue.IndexOf(currentId);

                if (pos == -1)
                {
                    CurrentIndex = allCards.FindIndex(c => c.Id == CurrentReviewQueue[0]);
                    return;
                }

                int nextPos = (pos + 1) % CurrentReviewQueue.Count;
                CurrentIndex = allCards.FindIndex(c => c.Id == CurrentReviewQueue[nextPos]);
            }
            else
            {
                CurrentIndex = (CurrentIndex + 1) % allCards.Count;
            }
        }

        public void Previous()
        {
            if (IsReviewMode && CurrentReviewQueue.Count > 0)
            {
                string currentId = allCards[CurrentIndex].Id;
                int pos = CurrentReviewQueue.IndexOf(currentId);

                if (pos == -1)
                {
                    CurrentIndex = allCards.FindIndex(c => c.Id == CurrentReviewQueue[0]);
                    return;
                }

                int prevPos = (pos - 1 + CurrentReviewQueue.Count) % CurrentReviewQueue.Count;
                CurrentIndex = allCards.FindIndex(c => c.Id == CurrentReviewQueue[prevPos]);
            }
            else
            {
                CurrentIndex = (CurrentIndex - 1 + allCards.Count) % allCards.Count;
            }
        }

        public bool OnReviewToggle(bool enable)
        {
            IsReviewMode = enable;

            if (IsReviewMode)
            {
                if (CurrentReviewQueue.Count == 0)
                    return false;

                LastNonReviewCardId = allCards[CurrentIndex].Id;

                string targetId = CurrentReviewQueue.Contains(LastReviewCardId)
                    ? LastReviewCardId
                    : CurrentReviewQueue.First();

                CurrentIndex = allCards.FindIndex(c => c.Id == targetId);
                return true;
            }
            else
            {
                if (!string.IsNullOrEmpty(LastNonReviewCardId))
                {
                    int lastIndex = allCards.FindIndex(c => c.Id == LastNonReviewCardId);

                    if (lastIndex != -1)
                    {
                        if (completedCards.Contains(LastNonReviewCardId) || LastReviewCardId == LastNonReviewCardId)
                        {
                            int nextIndex = (lastIndex + 1) % allCards.Count;
                            CurrentIndex = nextIndex;
                            LastNonReviewCardId = allCards[nextIndex].Id;
                        }
                        else
                        {
                            CurrentIndex = lastIndex;
                        }
                        LastNonReviewCardId = null;
                        return true;
                    }
                }

                CurrentIndex = 0;
                LastNonReviewCardId = null;
                return true;
            }
        }

        public (bool AllCorrect, string CardId, bool ShouldAdvance, bool ShouldExitReview) ProcessSubmission(List<string> userAnswers, List<string> correctAnswers)
        {
            var card = GetCurrentCard();
            string cardId = card.Id;
            bool allCorrect = userAnswers.SequenceEqual(correctAnswers);
            bool cardChanged = false;

            if (!allCorrect)
            {
                if (!CurrentReviewQueue.Contains(cardId))
                    CurrentReviewQueue.Add(cardId);
            }
            else
            {
                CurrentReviewQueue.Remove(cardId);

                if (!IsReviewMode)
                    completedCards.Add(cardId);

                if (!IsReviewMode && LastNonReviewCardId == cardId && completedCards.Contains(cardId))
                {
                    int lastIndex = allCards.FindIndex(c => c.Id == LastNonReviewCardId);
                    if (lastIndex != -1)
                    {
                        int nextIndex = (lastIndex + 1) % allCards.Count;
                        CurrentIndex = nextIndex;
                        LastNonReviewCardId = allCards[nextIndex].Id;
                        cardChanged = true;
                    }
                }

                if (IsReviewMode && CurrentReviewQueue.Count > 0)
                {
                    string nextId = CurrentReviewQueue[0];
                    int newIndex = allCards.FindIndex(c => c.Id == nextId);

                    if (newIndex != CurrentIndex)
                    {
                        CurrentIndex = newIndex;
                        cardChanged = true;
                    }
                }
            }

            if (IsReviewMode && CurrentReviewQueue.Count > 0)
            {
                LastReviewCardId = cardId;
            }

            bool shouldExitReview = IsReviewMode && CurrentReviewQueue.Count == 0;
            return (allCorrect, cardId, cardChanged, shouldExitReview);
        } 
    }
}


