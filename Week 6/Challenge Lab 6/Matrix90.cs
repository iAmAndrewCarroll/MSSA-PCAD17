using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Lab_6
{
    /*
    * restate the problem:
    * given an n x n 2D matrix representing an image : rotate the image 90 degrees clockwise
    * [
    *    [1, 2, 3],
    *    [4, 5, 6],
    *    [7, 8, 9]
    * ]
    *
    * rotate the image in-place
    * 
    * you have to modify the input 2D matrix directly. 
    * 
    * DO NOT allocate another 2D matrix and do the rotation.
    * 
    * input : matrix = [[1,2,3],[4,5,6],[7,8,9]]
    * output : [[7,4,1],[8,5,2],[9,6,3]]
    * 
    * Desired for a 3 x 3 Matrix
    * Input:                 Output:
    * [1, 2, 3]              [7, 4, 1]
    * [4, 5, 6]    →         [8, 5, 2]
    * [7, 8, 9]              [9, 6, 3]
    * 
    * 
    * input : matrix = [[5,1,9,11],[2,4,8,10],[1,4,5,3],[12,9,7,1]
    * output :
    * 
    * Original Grid Cooridinates visual logic:
    * (0,0) (0,1) (0,2)
    * (1,0) (1,1) (1,2)
    * (2,0) (2,1) (2,2)
    * 
    * Rotation visual logic by column:
    * (2,0) → (0,0)
    * (1,0) → (0,1)
    * (0,0) → (0,2)
    * 
    * (2,1) → (1,0)
    * (1,1) → (1,1)
    * (0,1) → (1,2)
    * 
    * (2,2) → (2,0)
    * (1,2) → (2,1)
    * (0,2) → (2,2)
    * 
    * Two Step Strategy
    * Transpose the matrix : flip rows and columns : matrix[i][j] = matrix[j][i]
    * - flips the matrix across its top-left to bottom-right diagonal
    * - Elements on the diagonal stay in place : everything else mirrors across it
    * Only need to swap the element above the diagonal to avoid undoing swaps or double work
    * Simply : columns become rows
    * 
    * Reverse each row : clockwise rotation : flip across diagonal + horizontally
    * - each row of the matrix contains the correct rotated values : but the are in reverse order
    * - reversing each row shifts those values into their correct, rotated positions
    * - this completes the 90 degree clockwise transformation
    * Simply : resersing each row ensures those columns are now in the correct clockwise order
    * 
    * To Rotate Counter Clockwise : Reverse each column
    * 
    * The total number of swaps is unique pairs (i,j) where j > i : n(n - 1)/2
    * n = size of square matrix
    * 
    * Time Complexity : O(n squared)
    * - algorithm touches every element in the matrix exactly once during the transpose step,
    *   and once again during the row reversal
    * 
    * Space Complexity : O(1) : no additional matrix is allocated ; only in place swaps and reversals used
    * 
    * 
    * pseudo code:
    * function Rotate(matrix) : n = size of matrix : n = matrix.length
    * for i from 0 to n - 1 : for j from i + 1 to n - 1 : swap matrix[i][j] with matrix[j][i]
    * reverse each row from left to right : for i from 0 to n - 1 : reverse(matrix[i])
    * 
    * what reverse(matrix[i]) means logically:
    * Swap matrix[i][0] with matrix[i][n - 1]
    * Swap matrix[i][1] with matrix[i][n - 2]
    * continue until you reach the middle row
    * 
    * 
    */
    internal class Matrix90
    {
        public static void Transpose(int[][] matrix)
        {
            int n = matrix.Length;

            // transpose the matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

            // reverse each row
        public static void ReverseRows(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                int left = 0;
                int right = n - 1;

                while (left < right)
                {
                    int temp = matrix[i][left];
                    matrix[i][left] = matrix[i][right];
                    matrix[i][right] = temp;

                    left++;
                    right--;
                }
            }
        }
        public static void Rotate(int[][] matrix)
        {
            Transpose(matrix);
            ReverseRows(matrix);
        }
    }
}
