# Types of Class Design

- Abstraction: create a template for something; abstract an idea / real life
- Encapsulation: private / public; group the attributes + behavior 
  - think of it like a container (literally a capsule) and only public things can 
	be exposed
- Inheritance: Person --> Employee --> Parttime Employee (making the thing more and 
more specific; from BASE Class to DERIVED class) 
- Polymorphism: 
  - beverage --> Coffee
  - setBaseTemp --> override setBaseTemp for DERIVED Class
	- virtual -> override
	- abstract method --> must override

```
namespace Mod1Demo1
{
	internal class Program
	{	
		static void Main (string[] args)
		{
			FileStream obj=new Filestream()
		}
		// static polymorphism (overloading)
		static int Add (int num1, num2)
		{
			return numb1 + num2;
		}
```

# Object

- Must have certain attributes or features
  - color or shape
- Inherits certain features from its class
  - class is a blueprint or template used to create objects
- Is created dynamically as an instance of a class
  - more than one object can be created using a class

| Class | Object |
| car | toyota , Subaru |

# Data Immutability


# Creation of Parameterized Constructors

# Modifying Immutable Data Objects
- Immutable data types cannot 


# C Sharp is an Imperative Programming language
- tells the machine "how to do it"
- Employs statements to modify the state of the program
- Divides 

| Declarative Programming | Imperative Programming |
| focus on the problem | focus on how to solve the problem |
| Works on logic of computation | Follows a step-by-step procedure to describe the control flow of computation |
| Describes the result | Describes the process of accomplishing a task |
| To add repetition, add scripts | Full control to devs.  Users make decisions |
| Sub-types include logic programming and functional programming | Sub-types include procedural programming, object-oriented programming, and parallel processing approach |
| Examples: HTML, SQL, etc | Examples - C#, C, etc. |

# Method
- create a method
  - defined by the methods name followed by the prenthesis ()
  - start each word in the methods name with an uppercase letter (referred to as PascalCase)
- Call a method
  - means executing the method
  - Requires writing the method's name followed by () in which you can pass in specific args
  - can invoke static methods by using ClassName.MethodName();
  - Can invoke instance methods by using "objname.MethodName();"
- Call Method multiple times
  - can be called more than once

# Loops
- Initialize --> Condition --> True --> Statment(s) --> Increment --> Condition --> False (exit)

- While Loop: Do while true
  - initialization happens within the loop

- For Loop: for each condition do the loop

- Do-while Loop
  - executes code block loop then checks the condition


# Jump Statements
- Break
  - terminates a loop or switch statement prematurely
  - does not have a condition evaluated to determine when to terminate the loop or switch statement


# Whiteboarding

## Example 5.1.1 - Palindrome Integer:

psuedo code : english like statements + syntax

problem: input 121 ; reverse 121

What we will use:
temp = 0
using / %

code outline:
```
bool IsIntPalindrome(int target)
{
	int reverse = 0  // initialization of reverse
	int temp = target  // temp will initialize as 121

	while (temp > 0)
		reverse = reverse*10 + temp % 10 // this gives the last number in the input: 121 % 10 = 12 remainder 1 --> 1
		temp = temp / 10 // this drops the the last number: 121 --> 12
	end while

	return reverse == target
}
```

In class code example:
```
static void Main(string[] args)
{
	HashSet<int> set = new HashSet<int>();  // returns when an element is added, false if element is present (duplicate)
	set.Add(1);

	IsIntPalindrome(122); // evaluates to false (not palindrome)
}

// 5.1.3
// { 1, 2, 2, 3, 3, 4 }
// Dictionary: 1-1, 2-2, 3-2, 4-1 ; this is a Key and Value Pair
static bool ContainsDuplicates(int[] nums)
{
	Dictionary<int,int> numset = new Dictionary<int,int>(); // Not the right data structure b/c would not use the 'value'
	HashSet<int>set = new HashSet<int>(); // use the HashSet b/c we don't need the (TKey, value) used by a Dictionary
	foreach(int num in nums)
	{
		if(set.Contains(num))return true; // is the number there?
		else set.Add(num);
	}
	return false; // no duplicates found
}

static bool IsIntPalindrome(int target)
{
	int reverse = 0;
	int tempt = target;
	while(temp>0)
	{
		reverse = reverse*10 + temp % 10;
		temp /= 10;
	}
	return reverse == target;

	// 5.1.2
	int sum = 0;
	while(target<0)
	{
		sum = sum + target % 10;
		target /= 10;
	}
}
```

## Example 5.1.2
Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.
Test Data :
Enter a number: 1234
Expected Output :
The sum of the digits of the number 1234 is : 10

## Example 5.1.3
3. Given an integer array nums, return true if any value appears at least 
   twice in the array, and return false if every element is distinct.
Example 1:
Input: nums = [1,2,3,1]
Output: true
Example 2:
Input: nums = [1,2,3,4]
Output: false
Example 3:
Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true

# Begin Assignment 5.2 Notes - Basic Concepts of Data Structures

Stack is value
Heap is reference

CRUD Operation: 
Create
Read
Update
Delete

Data: is any information

Data Structure: is a way / method to store the information
- linear list, stack, Q, tree, graph

Algorithm: process to solve problems

Classification of Data Structures
| Primitive Data Structures | Non-Primitive Data Structures |
| Integer | Linear Data: Arrays (static), {Linked List, Stacks, Queues} (dynamic) |
| Real | Non-Linear Data Structures: Trees & Hash tables (maybe hash tables) |

# Topic - Recursion

Recursion: a technique to solve repetition logic by calling the function itself

Direct Recursion

Indirect Recursion
- Func A is calling B --> B is calling A : there is some exit criteria to come out of the loop

Iteration:
- Can terminate when the iterative condition becomes false
- Works on loop
- Memory requirement is less
- Iterative problem may or may not be solved using recursion
- The code complexity is high (more lines of code)

Recursion
- Terminates when the base condition is true
- Works on function
- Memory requirement is more
- Every Recursive problem can be solved iteratively
- The code complexity is less (less lines of code)

Func A()
{
	A(); // function calls itself infinitely
}

memory use of recursion
| stack |  |
| Func A() |  | <-- continues to stack until mem is full; Recursion calls the function itself; We must END the loop intentionally



Thinking about it:
Main()
{
	Add()
	Product()
}

memory use of a normal function
| stack | heap |
| Main() |  |  <-- Main remains on the stack
| local variables |  | <-- 
| Add() |  |  <-- Add() pops out of the stack 
| Product() |  | <-- Product() pops in

# 5.2 Example - Pseudo Code
func PrintSquares(n)
	if(n > 0)  // base condition / exit condition
		print(n*n)
		PrintSquares(n-1)
	end if

PrintSquare(4)
1. n=4 : fun(4) --> print 16, fun(3) --> on STACK memory `fun(4)`
2. n=3 : fun(3) --> print 9, fun(2) --> on STACK memory `fun(3)`
3. n=2 : fun(2) --> print 4, fun(1) --> on STACK memory `fun(2)`
4. n=1 : fun(1) --> print 1, fun(0) --> on STACK memory `fun(1)`
1. n=0 : fun(0) --> condition becomes false, func returns

# Note: Practice factorials (common interview question topic)


# Array
Stores uinform data type elements
Is a linear data structure
Can be used when storing several values in a single variable
Stores elements in contiguous memory locations
Has a fixed size, which means that once an array is created or initilialized

Example: int[] arr = { 1, 22, 3, 4, 52, 6, 7 }

Array Elements begin at 0

Key Operations on an Array:
Traversal
Insertion
Deletion
Searchin
Update
Copying
Reversing
Sorting

Applications of Arrays:
Storing & Accessing Data
Sorting
Searching
Matrices
Stacks & Queues


Types of Arrays:
One Dimensional
Two Dimensional
Multi Dimensional
Jagged (rows do not have same number of columns; can be called an Array of Arrays)

Array Advantages:
- 1D array elements can easily be accessed by using the index number, so if you know the index number,
  the retrieval time of the array is O(1).
- Searching can be applied to arrays ver easily.
- 2-D arrays are used ot represent matrices.
- Arrays allocate memory in contiguous memory locations for all its elements

Array Disadvantages:
- You need to know the number of elements at the time of the creation of the array
- An array stores the elements in a contiguous memory location

# List / Linked List
- uses nodes, not elements
- Must traverse the entire list: 
  - Node 1 [data type : some value] --> Node 2 [data type : some value] --> Node 3 [data type : null]

Single Linked List --> Traverse one way
Double Linked List --> Traverse both directions

Queues --> Simple or Linear, Circular, Priority & Double Ended Queue (or Dequeu)


# String and StringBuilder

String
- a built-in data type that represents a sequence of characters
- mutable
- has various string manipulation methods
  - Substring()
  - Concat()
  - missed the last one

StringBuilder Class
- more efficient memory use


# Characteristics and Properties of Algorithms
- Clear and Unambiguous
- Well-Defined Input
- Well-Defined Output
- Finiteness
- Feasible
- Language Independent

Abstract data type ADT: abstract idea

Stack: LIFO, push, pop, peek

Implement Stack (ADT): data structure

Algorithms:
1. Set of instructions
2. blue print
3. finite amount
4. computational procedure
5. predict performance
6. Time and space

Analysis:
1. How much time?
2. How much memory?

1. Experimental analysis
   - Timer function is used to actually measure time
   - Varied input
   - Easy

2. Theoretical analysis (based on Math)
   - performed on description
	- independent of s/w and h/w

Primitive Operations:
- Declarations : int n
- Assignment : n=4
- Arithmetic
- Comparison
- Accessing element
- Calling function
- Returning function

Example1 :
int total = 0;
int i = 1;
while(i<=n)
{
	total = total + i;
	i++;
}

Calculate Time Complexity: 
Declarations (int total & int i): 2 +
Assignment (=0 & = 1): 2 +
Arithmetic : n + 1 +
Comparison: n +
Accessing Element: n +
Calling Function: 
Returning Function: 
What's the math: 2 + 2 + (n+1) + n + n == 5 + 3n ==> n --> linear change

Example2:
int total = 0;
for(int i=0; i<n; i++)
{
	for(int j=0; j<m; j++)
	{
		total=total+A[i,j];
	}
}

Calculate Time Complexity:
Declarations: 1 + 1 + n
Assignments: 1 + 1 + n
Comparison: (n+1) + n*(m+1) --> n+1 + nsq + n
Accessing: n * m --> nsq
Incrememnt: (n+1) + n*(m+1) --> n+1 + nsq + n
Arithmetic: n*m --> nsq
What's the math: 6 + 6n + 4nsq -->6 + 60 + 4*nsq --> nsq --> Big O Notation: O(n)

Time Complexity:

Space Complexity:

Algorithms --> Design:
- Brute-force : 
  - simplest algo ; uses exhaustion method to find solution
  - keeps using the input until the correct solution is found
- Recursive
- Backtracking
- Searching & Sorting
- Greedy Method
- Hashing Method
- Dynamic Programming Method

Sorting Algo:
- Rearrange arrays of elements in a particular order

Hashing Algo:
- Uses a hash function to map arbitrary data to tabular indexes
- data in hash table is stored using the key-value pairs

Divide & Conquer (DAC) Algorithm:
- is a strategy for solving a large problem.  It has three steps:
- Divide: Breaking up a large problem into smaller, solvable subproblems
- Conquer: Solving, or "conquering" each subproblem

# More Recursion

# LEET CODE Problems
- 455 : Greedy Algorithm; Assign a cookie
  - the goal of a Greedy Algo is maximizing "profit", or cookies, or satisfaction