namespace MergeIntervals_Q2;

class Program
{
    static void Main(string[] args)
    {
        int[][][] tests =
        [
            [[1,3],[2,6],[8,10],[15,18]],
            [[1,4],[4,5]],
            [[4,7],[1,4]]
        ];

        foreach (var intervals in tests)
        {
            var result = Merge(intervals);
            Console.WriteLine("[" + string.Join(", ", result.Select(r => $"[{r[0]},{r[1]}]")) + "]");
        }
    }
    
    private static int[][] Merge(int[][] intervals) 
    {
        // Sort intervals by start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();
        merged.Add(intervals[0]);

        for (int i = 1; i < intervals.Length; i++)
        {
            int[] current = intervals[i];
            int[] last = merged[merged.Count - 1];

            // If current interval overlaps with the last merged interval, extend it
            if (current[0] <= last[1])
            {
                last[1] = Math.Max(last[1], current[1]);
            }
            else
            {
                merged.Add(current);
            }
        }

        return merged.ToArray();
    }
}