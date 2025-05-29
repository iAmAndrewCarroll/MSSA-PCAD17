### Breakdown: JSON Cards Are Not Fully Loading Into GUI — Analysis & Trace Summary

---

## Problem You Described

You traced and confirmed:

> "Null is being passed to card methods and returning ONLY hardcoded card data in the GUI."

This means:

* The card *objects* are being created from the JSON files 
* But *properties like `Skills`, `Common_Errors`, and `Title`* are staying `null` 
* Only `DisplayBody()` hardcoded formats are returning — and with null values substituted in.

---

## What You Traced (Step-by-Step)

You walked through the following:

### Step 1: Dropdown Flow Trace

* You selected `Method Review` from a `<Picker>`
* This triggered `OnCardTypeChanged`
* which called `LoadCardsAsync("methods.json", "method review")`

### Step 2: JSON File Access

* `LoadCardsAsync` attempted to load `methods.json` using:

  ```csharp
  var methodCards = await JsonLoader.LoadJsonAsync<List<MethodCard>>(...);
  ```
* JSON string was successfully read.
* `methodCards.Count` was 13 — so the deserialization did succeed on the surface ✅

### Step 3: Card Properties Were Null

* Despite `.Count == 13`, every `MethodCard` inside the list had `null` for:

  * `Title`
  * `Skills`
  * `Common_Errors`
* Except for `Leetcode_Tags`, which sometimes populated

### Step 4: Display Rendered Anyway

* `DisplayCurrentCard()` sets UI with:

  ```csharp
  Title = card.DisplayTitle;
  promptLabel.Text = card.DisplayBody();
  ```
* `DisplayBody()` was showing default text like:

  ```
  Skills:
  • 
  • 
  • 
  Common Errors:
  • 
  Tags:
  Array, Prefix Sum, Medium
  ```

---

## 🧪 What Solutions Have Already Been Tried

1. **Switched to using `JsonPropertyName` on `Leetcode_Tags`**:

   ```csharp
   [JsonPropertyName("leetcode_tags")]
   public List<string> Leetcode_Tags { get; set; }
   ```

   This is why *only* that property was working correctly.

2. **Interface Used (`ICard`) and DisplayBody() calls verified**

   * You confirmed that all cards inherit `ICard` and implement `DisplayBody()` correctly

3. **Deserialization confirmed working (methodCards.Count == 13)**

4. **Multiple `methods.json` files confirmed valid in `Raw/` folder**

   * Used `JsonValidator.cs` to verify that JSON loads

---

## Root Cause

Your `MethodCard.cs` looks like this:

```csharp
public class MethodCard : ICard
{
    public string Id { get; set; }
    public string Title { get; set; }
    public List<string> Skills { get; set; }
    public List<string> Common_Errors { get; set; }

    [JsonPropertyName("leetcode_tags")]
    public List<string> Leetcode_Tags { get; set; }
    ...
}
```

Your **methods.json** file looks like this:

```json
{
  "id": "matrix-transpose-and-rotate",
  "title": "Matrix Transpose and Rotate",
  "skills": [ "2D array indexing", "In-place transformation" ],
  "common_errors": [ "Not handling non-square matrices" ],
  "leetcode_tags": [ "Matrix", "In-place", "Medium" ]
}
```

The field names **match exactly** — so the deserialization *should work*.
**BUT** you're using `PropertyNameCaseInsensitive = true` and yet it's not working for non-annotated fields.

### You added `[JsonPropertyName("leetcode_tags")]`, but NOT for `title`, `skills`, or `common_errors`.

When using `.NET 9`, it's often necessary to **explicitly annotate every JSON-mapped property** if your casing doesn't match exactly, even with `CaseInsensitive = true`.

---

## What Needs to Be Done

### Solution:

Annotate **all public properties** in `MethodCard`, `SyntaxCard`, etc. with `[JsonPropertyName(...)]`

Example:

```csharp
public class MethodCard : ICard
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("skills")]
    public List<string> Skills { get; set; }

    [JsonPropertyName("common_errors")]
    public List<string> Common_Errors { get; set; }

    [JsonPropertyName("leetcode_tags")]
    public List<string> Leetcode_Tags { get; set; }
}
```

---

## What You Already Provided to Support This

You gave:

* A full debug trace with breakpoint-to-breakpoint logic following selection → JSON load → deserialization → UI display
* Console output showing card count = 13 but body = null
* The entire `MainPage.xaml.cs`, `MethodCard.cs`, `methods.json`, and even the validator
* Clear evidence that only `[JsonPropertyName("...")]` fields were being deserialized correctly

---

## Final Step

1. Add `[JsonPropertyName(...)]` to **every** public property used in JSON-mapped models.
2. Rebuild the project.
3. Rerun and observe — values should now appear in GUI via `DisplayBody()`.

Would you like me to update your `MethodCard.cs`, `ProblemCard`, and `SyntaxCard` with those attributes?


Tracing:
Title get; set set title value but as soon as it stepped into DisplayBody() the Title changed back to null
		selected	"Method Review"	string
		filename	"methods.json"	string
		cardType	"method review"	string
+		LoadCardsAsync	{Method = {System.Threading.Tasks.Task LoadCardsAsync(System.String, System.String)}}	object {System.Func<string, string, System.Threading.Tasks.Task>}
		cardType	"method review"	string
+		methodCards	Count = 13	System.Collections.Generic.List<MSSA_Project.Models.MethodCard>
		LoadJsonAsync	error CS8917: The delegate type could not be inferred.	
		filename	"methods.json"	string
+		stream	{System.IO.FileStream}	System.IO.Stream {System.IO.FileStream}
+		reader	{System.IO.StreamReader}	System.IO.StreamReader
		json	"[\r\n    {\r\n        \"id\": \"array-product-without-division\",\r\n        \"title\": \"Array Product Without Division\",\r\n        \"skills\": [ \"Prefix/Suffix arrays\", \"O(n) time\", \"No division\", \"Array manipulation\" ],\r\n        \"common_errors\": [ \"Index misalignment\", \"Wrong initial values\", \"Improper suffix construction\" ],\r\n        \"leetcode_tags\": [ \"Array\", \"Prefix Sum\", \"Medium\" ]\r\n    },\r\n    {\r\n        \"id\": \"matrix-transpose-and-rotate\",\r\n        \"title\": \"Matrix Transpose and Rotate\",\r\n        \"skills\": [ \"2D array indexing\", \"In-place transformation\", \"Transpose\", \"Row reversal\" ],\r\n        \"common_errors\": [ \"Not handling non-square matrices\", \"Index confusion between i/j\" ],\r\n        \"leetcode_tags\": [ \"Matrix\", \"In-place\", \"Medium\" ]\r\n    },\r\n    {\r\n        \"id\": \"string-parsing-and-last-word-extraction\",\r\n        \"title\": \"String Parsing and Last Word Extraction\",\r\n        \"skills\": [ \".Trim()\", \".Split()\", \"IndexOf/LastIndexOf\", \"Length calculation\" ],\r\n        \"common_errors\": [ \"Trailing spaces\", \"Empty ..."	string
		string	error CS1525: Invalid expression term 'string'	
		filename	"methods.json"	string
+		methodCards	Count = 13	System.Collections.Generic.List<MSSA_Project.Models.MethodCard>
+		DisplayCurrentCard	{Method = {Void DisplayCurrentCard()}}	object {System.Action}
+		card	{MSSA_Project.Models.MethodCard}	MSSA_Project.Models.ICard {MSSA_Project.Models.MethodCard}
		DisplayTitle	null	string
		Title	null	string // Title get; set set title value but as soon as it stepped into DisplayBody() the Title changed back to null
		Skills null 	null	string
		Common Errors	null	string
