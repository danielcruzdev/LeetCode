# 56. Merge Intervals

**Difficulty:** Medium

## Problem

Given an array of intervals where `intervals[i] = [starti, endi]`, merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

## Examples

**Example 1:**
```
Input:  intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
```

**Example 2:**
```
Input:  intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.
```

**Example 3:**
```
Input:  intervals = [[4,7],[1,4]]
Output: [[1,7]]
Explanation: Intervals [1,4] and [4,7] are considered overlapping.
```

## Constraints

- `1 <= intervals.length <= 10⁴`
- `intervals[i].length == 2`
- `0 <= starti <= endi <= 10⁴`

---

## Solution

### Approach: Sort + Linear Scan

The key insight is that if we **sort the intervals by their start value**, overlapping intervals will always be adjacent. After sorting, we just need one pass to merge them.

#### Steps

1. **Sort** the intervals array by start value (`intervals[i][0]`).
2. Initialize a `merged` list with the first interval.
3. Iterate over the remaining intervals:
   - **Overlap** — if the current interval's start (`current[0]`) is ≤ the last merged interval's end (`last[1]`), extend the last interval's end to `Math.Max(last[1], current[1])`.
   - **No overlap** — otherwise, add the current interval to the `merged` list as a new entry.
4. Return the `merged` list as an array.

#### Visualization

```
Input (unsorted): [[4,7],[1,4]]
After sort:       [[1,4],[4,7]]

Step 1 → merged = [[1,4]]
Step 2 → current = [4,7], 4 <= 4 → overlap → extend → merged = [[1,7]]

Output: [[1,7]]
```

#### Code

```csharp
private static int[][] Merge(int[][] intervals)
{
    Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

    var merged = new List<int[]>();
    merged.Add(intervals[0]);

    for (int i = 1; i < intervals.Length; i++)
    {
        int[] current = intervals[i];
        int[] last = merged[merged.Count - 1];

        if (current[0] <= last[1])
            last[1] = Math.Max(last[1], current[1]);
        else
            merged.Add(current);
    }

    return merged.ToArray();
}
```

### Complexity

| | Complexity |
|---|---|
| **Time** | O(n log n) — dominated by the sort step |
| **Space** | O(n) — the merged list holds at most n intervals |
