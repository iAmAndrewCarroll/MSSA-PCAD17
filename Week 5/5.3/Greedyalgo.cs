using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._3
{
    internal class Greedyalgo
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            // Sort both the arrays
            Array.Sort(g);
            Array.Sort(s);

            int childIndex = 0, cookieIndex = 0;
            while (childIndex < g.Length && cookieIndex < s.Length)
            {
                // if the current cookie can content the current child
                if (g[childIndex] <= s[cookieIndex])
                {
                    // Move to the next child and next cookie
                    childIndex++;
                    cookieIndex++;
                }
                else
                {
                    // Try the next larger cookie for the same child
                    cookieIndex++;
                }
            }

            return childIndex;
        }

        //    static void Main(string[] args)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
