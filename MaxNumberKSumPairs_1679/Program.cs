namespace MaxNumberKSumPairs_1679;

class Program
{
    static void Main(string[] args)
    {
        //Example 1:
        int[] nums1 = { 1, 2, 3, 4 };
        int k1 = 5;
        Console.WriteLine(MaxOperations(nums1, k1)); // Output: 2
        
        //Example 2:
        int[] nums2 = { 3, 1, 3, 4, 3 };
        int k2 = 6;
        Console.WriteLine(MaxOperations(nums2, k2)); // Output: 1
    }
    
    private static int MaxOperations(int[] nums, int k)
    {
        var numCounts = new Dictionary<int, int>();
        var operations = 0;
        
        foreach (var num in nums)
        {
            var complement = k - num;
            if (numCounts.ContainsKey(complement) && numCounts[complement] > 0)
            {
                operations++;
                numCounts[complement]--;
            }
            else
            {
                if (!numCounts.ContainsKey(num))
                {
                    numCounts[num] = 0;
                }
                numCounts[num]++;
            }
        }

        return operations;
    }
}