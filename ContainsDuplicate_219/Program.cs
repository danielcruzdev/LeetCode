namespace ConstainsDuplicate_219;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 1, 2, 3, 1 };
        var k = 3;
        var result = ContainsNearbyDuplicate(nums, k);
        Console.WriteLine(result);

        nums = new int[] {1,2,3,1,2,3};
        k = 2;
        result = ContainsNearbyDuplicate(nums, k);
        Console.WriteLine(result);

        nums = new int[] {1,2,3,4,5,6,7,8,9,9};
        k = 3;
        result = ContainsNearbyDuplicate(nums, k);
        Console.WriteLine(result);
    }
    
    private static bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var set = new HashSet<int>(k + 1);
        for (int i = 0; i < nums.Length; ++i)
        {
            if (set.Count > k)
                set.Remove(nums[i - k - 1]);
            if (!set.Add(nums[i]))
                return true;
        }
        return false;
    }
}