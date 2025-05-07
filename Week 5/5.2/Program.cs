/*
 *  5.2.1
 *  
 *  Clarify the Problem:
 *  1. Given a string s consisting of words and spaces, return the length of 
 *  the last word in the string. A word is a maximal substring consisting of 
 *  non-space characters only.
 *  Example 1:
 *  Input: s = "Hello World"
 *  Output: 5
 *  Explanation: The last word is "World" with length 5.
 *  
 *  Example 2:
 *  Input: s = " fly me to the moon "
 *  Output: 4
 *  Explanation: The last word is "moon" with length 4.
 *  
 *  Step Through
 *  - Begin traversing from the end
 *  - If it begins with a space continue until it hits a character
 *  - Begin adding characters and incrementing the count
 *  - Stop when hit the next space or end
 *  
 *  Pseudo Code
 *  func getLastWord(s, index, counter, word):
 *      if index < 0: return reverse(word), counter
 *      
 *      currentChar = s[index]
 *      
 *      if currentChar == ' ' and counter == 0:
 *          // Trailing space, haven't started a word
 *          return getLastWord(s, index - 1, counter, word)
 *          
 *      else if currentChar != ' ':
     *      // build the word
     *      append currentChar to word
     *      increment counter
     *      return getLastWord(s, index - 1, counter, word)
 *      
 *      else if currentChar == ' ' and counter > 0:
 *          // finished the word
 *          return reverse(word), counter
 *          
 * func PrintLastWord(s):
 *      word, length = getLastWord(s, s.length - 1, 0, empty string)
 *      print "The last word is", word, "with length", length
 *      
 */

static (string, int) getLastWord(string s, int index, int counter, string word)
{
    if (index < 0)
    {
        char[] chars = word.ToCharArray();
        Array.Reverse(chars);
        return (new string(chars), counter);
    }

    char currentChar = s[index];

    if (currentChar == ' ' && counter == 0)
    {
        return getLastWord(s, index - 1, counter, word);
    }
    else if (currentChar != ' ')
    {
        word += currentChar;
        counter++;
        return getLastWord(s, index - 1, counter, word);
    }
    else
    {
        char[] chars = word.ToCharArray();
        Array.Reverse(chars);
        return (new string(chars), counter);
    }
}
static string PrintLastWord(string s)
{
    var result = getLastWord(s, s.Length - 1, 0, "");
    Console.WriteLine($"The last word is {result.Item1} and it is {result.Item2} letters long.");
    return s;
    //Console.WriteLine();
}
Console.WriteLine("What is the last word and how long is it?");
Console.WriteLine(" fly me to the moon ");
PrintLastWord(" fly me to the moon ");
Console.ReadKey();