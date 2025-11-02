namespace MoveZeroes_283;

class Program
{
    static void Main(string[] args)
    {
        int[] nums1 = [0, 1, 0, 3, 12];
        MoveZeroes(nums1);
        Console.WriteLine($"Example 1: [{string.Join(", ", nums1)}]");
        
        int[] nums2 = [0];
        MoveZeroes(nums2);
        Console.WriteLine($"Example 2: [{string.Join(", ", nums2)}]");
        
        int[] nums3 = [1, 2, 3, 4, 5];
        MoveZeroes(nums3);
        Console.WriteLine($"No zeros: [{string.Join(", ", nums3)}]");
        
        int[] nums4 = [0, 0, 0, 1];
        MoveZeroes(nums4);
        Console.WriteLine($"Multiple zeros: [{string.Join(", ", nums4)}]");
    }
    
    private static void MoveZeroes(int[] nums) 
    {
        var leftPointer = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[leftPointer] = nums[i];
                leftPointer++;
            }
        }
        
        for (var i = leftPointer; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }
}