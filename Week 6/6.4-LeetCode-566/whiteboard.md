# Leetcode 566 : Matrix Reshape

## Restate the problem :

In MATLAB, there’s a function called `reshape` that converts an `m × n` matrix into a new one with dimensions `r × c`, preserving the original row-traversing order of elements.

### Given :
	- 2D array `mat` of size `m x n`
	- Two integers `r` and `c`

### Task :
- Reshape `mat` into a `r × c` matrix **without changing the order of elements**
- If it's not possible (i.e., the total element count doesn't match), **return the original `mat`**

## Restate the Problem (simplified again)

### Input:
- Original matrix `mat` of size `m × n`
- Two integers `r` and `c` representing desired row/column count

### Output:
- A new `r × c` matrix with the same elements in row-major order
- If reshape is **not legal**, return `mat` as-is

### Legal condition:
A reshape is **legal** only if `m * n == r * c`

## Step Through

Count total number of elements
```
m = mat.Length
n = mat[0].Length
totalElements = m * n
```

Validate reshape possibility
```
if r * c != m * n --> mat
```

Traverse row by row and remap elements
- single index `i` (from `0` to `m * n - 1`)
- `i / n` and `i % n` to access elements in `mat`
- `i / c` and `i % c` to place them in the new matrix

Fill the new matrix
```
result[i / c][i % c] = mat[i / n][i % n]
```

Why `i / c` and `i % c`?
- `i / c` give row index in reshaped matrix 
- `i % c` gives colum index
- map each element from 1D to 2D row/col coordinates

## Pseudocode
```
function matrixReshape(mat, r, c):
	m = number of rows in mat
	n = number of columns in mat

	if m * n != r * c:
		return mat

	result = new 2D array with r rows and c columns

	for i from 0 to m * n - 1:
		originalRow = i / n
		originalCol = i % n
		newRow = i / c
		newCol = i % c

		result[newRow][newCol] = mat[originalRow][originalCol]

	return result
```

### Note
- row traversal means left to right, top to bottom
- never allocate or discard data - only reshape
- do not flatten or re-sort elements

### example
```
Input:
mat = [[1,2],
       [3,4]], r = 1, c = 4

Output:
[[1,2,3,4]]
```