/*
### 1. **Problem Restatement**

Sort an array of integers using the **QuickSort algorithm**, which recursively partitions the array around a pivot and reorders values **in-place** so all smaller elements are to the left and all greater elements to the right.

### 2. **Verbal Logic Walkthrough (Step-by-Step)**

1. **Choose Pivot**: Start with the leftmost value as the pivot (`pivot = A[low]`).
2. **Initialize Pointers**:

   * `i` moves from left to right
   * `j` moves from right to left
3. **Partitioning Loop**:

   * While `A[i] <= pivot`, move `i` right.
   * While `A[j] > pivot`, move `j` left.
   * If `i <= j`, swap `A[i]` and `A[j]`.
4. **When `i > j`**, `j` is now at the correct position for the pivot.
5. **Swap pivot (A\[low]) with A\[j]**.
6. **Return `j`** as the partition index.
7. **Recursively quicksort** the left and right partitions:

   * `low to p_index - 1`
   * `p_index to high`

### 3. **Pseudocode**
function QuickSort(array, low, high):
    if low < high:
        p_index = Partition(array, low, high)
        QuickSort(array, low, p_index - 1)
        QuickSort(array, p_index, high)

function Partition(array, low, high):
    pivot = array[low]
    i = low
    j = high

    do:
        while array[i] <= pivot and i <= j:
            i++
        while array[j] > pivot and i <= j:
            j--
        if i <= j:
            swap(array[i], array[j])
    while i < j

    if low != j:
        swap(array[low], array[j])

    return j

---

### 4. **Key Concepts to Know**

| Concept                | Explanation                                                                    |
| ---------------------- | ------------------------------------------------------------------------------ |
| **Pivot Selection**    | Here, it's always the first element in the subarray. This affects performance. |
| **In-place Sorting**   | No extra arrays. Swapping is done inside the input array.                      |
| **Divide and Conquer** | Problem is recursively split at the pivot index.                               |
| **Time Complexity**    | Best/Average: O(n log n), Worst: O(n²) if poorly partitioned.                  |
| **Stability**          | Not stable by default. Doesn’t preserve original order of equal elements.      |

---

### 5. **Minimal Example (Driver)**

static void Main(string[] args)
{
    int[] A = { 23, 11, 45, 6, 89, 4 };
    Console.WriteLine("Before: " + string.Join(", ", A));

    QuickSort(A, 0, A.Length - 1);

    Console.WriteLine("After: " + string.Join(", ", A));
}

Input / Output of below code:

Unsorted Array:
54 78 63 92 45 86 15 28 37

Quick Sorted Array:
15 28 37 45 54 63 78 86 92

 */

using System.Collections.Concurrent;

namespace QuickSortDemo
{
    internal class Program
    {
        // in this logic we are considering the low (left most index) as pivot and placing the pivot on its correct position
        // there can be diff implementations when the pivot changes (maybe it become right most element)
        static void QuickSort(int []A, int low, int high)
        {
            if (low < high)
            {
                int p_index = Partition(A, low, high);
                QuickSort(A, low, p_index - 1); //left
                QuickSort(A, p_index + 1, high); //right

            }
        }

        // returns the pivot index / partition index p_index which is the correct position for the first number in the list
        static int Partition(int[] A, int low, int high)
        {
            int pivot = A[low]; //start on left
            int i = low;
            int j = high;
            do
            {
                while (i <= j && A[i] <= pivot)
                {
                    i++; // i moves right if the num at i is <= pivot
                }
                while (i <= j && A[j] > pivot)
                {
                    j--; // j moves towards left if the num at j is > pivot
                }
                // if i and j both stop then swap
                if (i <= j)
                {
                    // intermediate swap
                    Swap(A, i, j); // greater num moves right and lesser num moves left of pivot
                }
            }
            while (i < j);
            // j crossed i and we foudn pivot position
            if (low != j) // not swapo with itself
            {
                Swap(A, low, j);
            }
            return j;
        }

        static void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        static void Main(string[] args)
        {
            int[] A = { 54, 78, 63, 92, 45, 86, 15, 28, 37 };
            Console.WriteLine("Unsorted Array:");
            foreach (int i in A)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Quick Sorted Array:");
            QuickSort(A, 0, A.Length-1);
            foreach (int i in A)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
    }
}