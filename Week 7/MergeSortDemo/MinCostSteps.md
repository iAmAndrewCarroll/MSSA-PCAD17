
You are given an integer array cost where cost[i] is the cost of ith step on a staircase. Once you pay the cost, you can either climb one or two steps.

You can either start from the step with index 0, or the step with index 1.

Return the minimum cost to reach the top of the floor.

Example 1:

Input: cost = [10,15,20]
Output: 15
Explanation: You will start at index 1.
- Pay 15 and climb two steps to reach the top.
The total cost is 15.

Example 2:

Input: cost = [1,100,1,1,1,100,1,1,100,1]
Output: 6
Explanation: You will start at index 0.
- Pay 1 and climb two steps to reach index 2.
- Pay 1 and climb two steps to reach index 4.
- Pay 1 and climb two steps to reach index 6.
- Pay 1 and climb one step to reach index 7.
- Pay 1 and climb two steps to reach index 9.
- Pay 1 and climb one step to reach the top.
The total cost is 6.


**restate the problem:**

You're standing at the base of a staircase. Each step has a cost to land on it.

You can start on step 0 or 1, and on each move, you can jump 1 or 2 steps forward.

Your goal is to reach the top of the floor (i.e., one step past the last index) with the minimum total cost paid.

You pay cost[i] when you land on step i, and your choices at each step are:

    jump to i + 1

    jump to i + 2
```
**verbal logic step-through:**
Tracing wtih cost = [10, 15, 20]

start at step 0 or 1
   if at 0 : pay 10 --> ; pay 15 --> 2 ; pay 20 --> done --> total = 10 + 15 = 25
could also jump from 0 --> 2
if we do this
  Start at 1 : pay 15 --> jump to 3 (past end) --> total = 15
compute cheapest way to climb, combining smaller solutions into a minimal path

let dp[i] be the minimum cost to reach the i-th step
  recurrence : dp[i] = cost[i] + min(dp[i -1], dp[i - 2])
    to reach i we could have taken Setp i - 1 (1 step) OR step i - 2 (2 steps)
    we want the cheapest one


Tracing with `cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]`

Start at step 0 or 1.

* If at step 0:
  pay 1 → step 1 → pay 100 → step 2 → pay 1 → step 3 → pay 1 → step 4 → pay 1 → step 5 → pay 100 → step 6 → pay 1 → step 7 → pay 1 → step 8 → pay 100 → step 9 → pay 1
  \= bad idea → too expensive

* But if we make smart jumps — skipping expensive 100s — we can lower the cost
  We need to **compute the cheapest way to climb**, combining previous results into a **minimum total**

**define dp\[i] as the minimum cost to reach step i**

We use:

dp[i] = cost[i] + min(dp[i - 1], dp[i - 2])

This means:

* To reach step `i`, we could have:

  * Paid to get to `i-1` then stepped 1
  * Paid to get to `i-2` then jumped 2
* We take the **cheaper of those two paths**, and then pay `cost[i]`

**table trace:**

dp[0] = cost[0] = 1
dp[1] = cost[1] = 100

dp[2] = 1 + min(100, 1) = 2
dp[3] = 1 + min(2, 100) = 3
dp[4] = 1 + min(3, 2) = 3
dp[5] = 100 + min(3, 3) = 103
dp[6] = 1 + min(103, 3) = 4
dp[7] = 1 + min(4, 103) = 5
dp[8] = 100 + min(5, 4) = 104
dp[9] = 1 + min(104, 5) = 6

**final step:**

We can exit from either `dp[8]` or `dp[9]`
return min(dp[8], dp[9]) = min(104, 6) = 6


### Final Answer:

**Minimum total cost to reach the top is `6`**
```

pseudo code
```
function MinCostClimb(cost)
    let int n be cost.length
    create array of direct paths (dp) of size n

    dp[0] = cost[0]
    dp[1] = cost[1]

    for i from 2 to n - 1:
        dp[i] = cost[i] + min(dp[i - 1], dp[i - 2])

    return min(dp[n - 1], dp[n - 2])
```

// Carter's Code
output = find the min cost to reach the top

cost = [ 5 2 3 12 20 3 1 ] // index 0 to 2 = 8...... 1 to 3 = 14 ....... index 1 to 2 = 5
minC = [ 5 2 5 14 25 17 18]

int i;
for(i = 2; i < cost.Length; i++) {
	cost[i] += Math.Min(cost[i-1], cost[i-2]);
}

return Math.Min(cost[i-1], cost[i-2]);