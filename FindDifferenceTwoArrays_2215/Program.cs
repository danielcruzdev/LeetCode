namespace FindDifferenceTwoArrays_2215;

class Program
{
    static void Main(string[] args)
    {
        var nums1 = new int[] { 1, 2, 3 };
        var nums2 = new int[] { 2, 4, 6 };
        var result = FindDifference(nums1, nums2);
        Console.WriteLine(string.Join(", ", result.Select(x => $"[{string.Join(", ", x)}]")));
        
        var nums3 = new int[] { 1, 2, 3, 3 };
        var nums4 = new int[] { 1, 1, 2, 2 };
        var result2 = FindDifference(nums3, nums4);
        Console.WriteLine(string.Join(", ", result2.Select(x => $"[{string.Join(", ", x)}]")));
    }
    
    private static IList<IList<int>> FindDifference(int[] nums1, int[] nums2) 
    {
        var hash1 = new HashSet<int>();
        var hash2 = nums2.ToHashSet();

        for (var i = 0; i < nums1.Length; i++)
        {
            if (nums2.Contains(nums1[i]))
            {
                hash2.Remove(nums1[i]);
                continue;
            }
            
            hash1.Add(nums1[i]);
        }
        
        return new List<IList<int>>
        {
            hash1.ToList(),
            hash2.ToList()
        };
    }
}