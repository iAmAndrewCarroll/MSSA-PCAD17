using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBank.FlashCards
{
    // Abstract base class for all flashcard types
    public abstract class FlashCard
    {
        // Display prompt to the user (fill-in-blank question)
        public string Prompt { get; set; }

        // Optional explanation, helpful wtih GPT
        public string Explanation { get; set; }

        // Label to indicate card category or type
        public string TypeLabel => this.GetType().Name;

        // Constructor
        protected FlashCard(string prompt)
        {
            Prompt = prompt;
        }

        // Abstract method to be implemented by each card type
        // Handles how the card is displayed and how the user interacts with it
        public abstract void Run();
    }
}
