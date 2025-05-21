using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._4_LeetCode_566
{
    public class MatrixReshape
    {
        public static int[][] Reshape(int[][] mat, int r, int c)
        {
            int m = mat.Length; // number of rows
            int n = mat[0].Length; // mat[0] : first row; .Length : number of columns in first row

            if (m * n != r * c)
            {
                return mat;
            }

            // creates an array of arrays with r rows (just the outer shell).
            int[][] result = new int[r][]; // each row is currently null b/c inner arrays are not created yet

            for (int i = 0; i < r; i++) // loop creates a new array of c integers for each row in result
            {
                result[i] = new int[c]; // each result[i] is now a valid array of length c : initially filled with 0s (default for int)
            }

            // iterates over every element in the original matrix using a single flat index i
            for (int i = 0; i < m * n; i++) // m / n is number rows / col in mat : m * n = total elements
            {
                int originalRow = i / n; // row index original matrix
                int originalCol = i % n; // col index original matrix
                int newRow = i / c; // row index reshaped matrix
                int newCol = i % c; // col index reshaped matrix

                // copies element from original mat to correct new position in reshaped mat
                // preserving row major order
                result[newRow][newCol] = mat[originalRow][originalCol];
            }

            return result;
        }
    }
}
