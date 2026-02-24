namespace FindPivotIndex_724;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 1, 7, 3, 6, 5, 6 };
        var result = PivotIndex(nums);
        Console.WriteLine(result);
        
        var nums2 = new int[] { 1, 2, 3 };
        var result2 = PivotIndex(nums2);
        Console.WriteLine(result2);
        
        var nums3 = new int[] { 2, 1, -1 };
        var result3 = PivotIndex(nums3);
        Console.WriteLine(result3);
    }
    
    private static int PivotIndex(int[] nums) 
    {
        var sum = 0;
        foreach (var num in nums) sum += num;
        
        var leftSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (leftSum == sum - leftSum - nums[i])
            {
                return i;
            }
            
            leftSum += nums[i];
        }
        
        return -1;
    }
}