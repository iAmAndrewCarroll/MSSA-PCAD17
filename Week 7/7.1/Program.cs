using System;

namespace _7._1
{
    class Program
    {
        class SelectionSortScores
        {
            // 23 2 11
            internal static void SelectionSort(int[] Scores)
            {
                /*
                 * Restate the problem : Use selection sort to sort exam scores in ascending order
                 * 
                 * pseudo code:
                 * procedure selection sort(list : array of items)
                 * 
                 * length : list size
                 * 
                 * for i = 1 to length - 1
                 *  minindex = i
                 *  for j = i + 1 to length
                 *      if list[j] < list[minindex] then
                 *          minindex = j;
                 *      end if
                 *  end for
                 *  
                 *  if minindex != i then
                 *      swap list[minindex] and list[i]
                 *  end if
                 * end for
                 * 
                 * end procedure to return the sorted list
                 */
                int minposition = 0;
                int temp = 0; // for the swap as needed

                // i is tracking the correct position to put the swapped element from beginning to end
                for (int i = 0; i < Scores.Length - 1; i++)
                {
                    // minposition tracks the index of the min number
                    minposition = i;

                    // get the remaining minimum number
                    for (int j = i + 1; j < Scores.Length; j++)
                    {
                        if (Scores[j] < Scores[minposition])  // logic to find min number
                        {
                            minposition = j; // update minposition with index of min number

                        }
                    }

                    if (minposition != i) // to avoid swapping with itself
                    {
                        temp = Scores[i];
                        Scores[i] = Scores[minposition];
                        Scores[minposition] = temp;
                    }
                }
            }

            /*
             * 7.1.2 - Word Merge
             * 
             * restate the problem:
             * createa a new string by merging two given input strings, word1 & word2, in alternating character order
             * 
             * first character of word1, first of word2, second of word1, second of word2, etc
             * if a string runs out of characters before the other, append remaining characters from the longer string at end
             * 
             * Example : word1 "abcd" word2 "efghijkl" --> mergedWord = "aebfcgdhijkl"
             * 
             * verbal logic step through:
             * input / output : word1 "abcd" word2 "efghijkl" --> mergedWord = "aebfcgdhijkl"
             * two pointers: word1[i] & word2[j]
             * 
             * alternate: 
             * word1[0] = 'a' then word2[0] = 'e' -> "ae"
             * word1[1] = 'b' then word2[1] = 'f' -> "aebf"
             * and so on until
             * --> word1[3] = 'd' then word2[3] = 'h' -> "aebfcgdhijkl" : because word1[i] = word1.Length-1 we append all remaining characters
             * 
             * pseudo code :
             * function MergeAlternatingChars(word1, word2):
             *  create empty result string
             *  set i = 0
             *  
             *  while i < length of word1 OR i < length of word2:
             *      if i < length of word1:
             *          append word1[i] to result
             *      if i < length of word2:
             *          append word2[i] to result
             *      increment i
             *      
             *  return result
             * 
             */
            internal static string WordMerge(string word1, string word2)
            {
                string result = "" ;
                int i = 0;

                while ((i < word1.Length) || (i < word2.Length))
                {
                    if (i < word1.Length)
                    {
                        result += word1[i];
                    }
                    if (i < word2.Length)
                    {
                        result += word2[i];
                    }
                    i++;
                }
                return result;

            }
            static void Main(string[] args)
            {
                int[] arr = { 103, 90, 78, 63, 83, 89, 93, 97, 100 };
                Console.WriteLine("-- Assignment 7.1.1 : Selection Sort Test Scores --");
                Console.WriteLine("Original Scores Array: " + string.Join(" ", arr));
                SelectionSortScores.SelectionSort(arr);
                Console.WriteLine("Selection Sorted Scores Array: " + string.Join(" ", arr));
                Console.WriteLine();
                //Console.ReadKey();

                string word1 = "abcde";
                string word2 = "efghijklmno";

                Console.WriteLine("-- Assignment 7.1.2 : Merge Words by Alternating Characters --");
                Console.WriteLine($"Input : \nword1: {word1}  \nword2: {word2}");
                string merged = WordMerge(word1, word2);
                Console.WriteLine("\nMerged word: " + merged);
                Console.WriteLine();
                Console.ReadKey();

            }
        }
    }
}