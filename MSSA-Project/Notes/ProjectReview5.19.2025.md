## 1. State Reset Between Flashcards

### Goal:

Ensure each flashcard displays with a clean slate.

### Implementation:

* Clear all user inputs and visual styles (borders, feedback) in `DisplayCurrentCard()`.
* `PromptRenderer.Render*()` already clears `syncGroups`, but verify that:

  * All `Entry` boxes are empty.
  * Borders revert to neutral (gray).
  * `feedbackLabel.Text` is cleared.

This prevents leftover values or validation colors from a previous card.

---

## 2. "Show Hint" Toggle

### Goal:

Allow users to reveal the `hint` field from each `ProblemBlock`.

### Behavior:

* A toggle button labeled "Show Hint".
* When clicked:

  * If hidden, reveals a Label below the prompt with the hint.
  * If shown, hides the hint again.
  * Optional: Change button label between "Show Hint" and "Hide Hint".

### Context:

* For `AssignmentCard`, use the hint from either `MethodProblem` or `SyntaxProblem` based on `modeSwitch.IsToggled`.

### Placement:

* Directly below the Submit button and input stack.
* Style should be muted (e.g., small italic gray text, consistent width).

---

## 3. Flashcard Review Mode (Incorrect Only)

### Goal:

Let users revisit cards they got wrong.

### Behavior:

* Maintain a list called `reviewQueue` of card IDs that failed validation.
* Add a toggle or button labeled "Review Incorrect Only".
* When toggled on:

  * Navigation (Next/Previous) cycles through only the cards in `reviewQueue`.
  * If a card is answered correctly in review mode, remove it from the list.

### Design Considerations:

* Prevent duplicate entries in the queue.
* Need a fallback when the review queue is empty (message or auto-toggle off).
* Consider adding an "Enter Review Mode" button after a full session is completed.

---

## 4. Progress Display

### Goal:

Provide clear feedback on user progress through the current card deck.

### Two Display Elements:

1. Text label, e.g., "Card 3 of 25"
2. Visual `ProgressBar`, calculated as:

   ```csharp
   progressBar.Progress = (double)(currentIndex + 1) / allCards.Count;
   ```

### Placement Options:

* Top center under the `Picker`, or
* Bottom above the navigation buttons.

This reinforces a sense of completion and encourages full deck practice.

---

## Interaction Summary

| Action              | Result                                                             |
| ------------------- | ------------------------------------------------------------------ |
| Load new card       | Inputs cleared, validation colors reset, hint hidden               |
| Submit              | Validates input, shows feedback, colors borders                    |
| Show Hint toggle    | Displays or hides the card’s built-in hint text                    |
| Missed card         | Automatically added to `reviewQueue` for later revisit             |
| Review mode enabled | Navigation limited to incorrect cards until they are all corrected |
| Progress            | Displays text count and visual bar indicating how far through deck |

---

## Questions Before Implementation

1. Phased rollout to ensure modular functionality
2. Review mode is a persistent switch.
3. Reviewing answer check and reveal logic.
4. After all of the above are implemented, time permitting, create a local performance tracking file and user profile creation / login, performance badges, etc.






## Phase 1: State Reset and Hint Toggle

**Objectives**

* Clear all previous interaction state when moving between cards
* Enable on-demand hint visibility from the JSON content

**Tasks**
[x] Clear all `Entry` fields when navigating to a new card

[x] Reset border styles to default (gray)

[x] Clear `feedbackLabel.Text`

[x] Add a "Show Hint" button beneath the Submit button

[x] When clicked, display the hint from the current card

[x] Toggle label between "Show Hint" and "Hide Hint"

[x] For `AssignmentCard`, check `modeSwitch.IsToggled` to determine which hint to show

---

## Phase 2: Review Mode (Incorrect Only)

**Objectives**

* Give users a structured way to revisit only the cards they answered incorrectly

**Tasks**

[ ] Add a persistent `Switch` labeled "Review Incorrect Only"

[ ] Maintain a list `List<string> reviewQueue` to track failed cards

[ ] On incorrect submission, add card ID to the queue (prevent duplicates)

[ ] If a previously missed card is answered correctly, remove it from the queue

[ ] When review mode is enabled, navigate only through `reviewQueue`

[ ] Display a message if review queue is empty

[ ] Ensure that progress tracking and card display logic adjust to this state

---

## Phase 3: Progress Bar

**Objectives**

* Provide a visual and textual indicator of user progress

**Tasks**
[ ] Add a `Label` showing "Card X of Y"

[ ] Add a `ProgressBar` to visually represent completion percentage

[ ] Update both elements within `DisplayCurrentCard()`

[ ] When review mode is active, count progress based on the length of `reviewQueue`

---

## Phase 4: (Pending) Answer Reveal

**Objectives**

* Allow users to verify correct answers after submission

**Tasks (Design to be confirmed)**

[ ] Add a toggle or button labeled "Reveal Answer"

[ ] When activated, display correct answers in the corresponding input fields or labels

[ ] Prevent auto-reveal; should only show after submission

[ ] Style answer display to distinguish from user input

This phase will remain on hold until a final decision is made.

---

## Phase 5: Local Performance Tracking and User Profiles (Optional, Time Permitting)

**Objectives**

* Persist progress, accuracy, and engagement metrics across sessions
* Enable user identity selection or login

**Tasks**

[ ] Create a local file (e.g., `userstats.json`) to store performance data

[ ] Track per-card metrics: attempts, accuracy, last attempted date

[ ] Add simple user profile management (e.g., profile selection on launch)

[ ] Display performance summaries or badges based on progress

