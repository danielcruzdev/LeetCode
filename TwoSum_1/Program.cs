namespace TwoSum_1;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = [2,7,11,15];
        var result = TwoSum(nums, 9);
        Console.WriteLine($"[{result[0]}, {result[1]}]");
    }
    
    private static int[] TwoSum(int[] nums, int target) 
    {
        var numDict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];

            if(numDict.ContainsKey(complement))
            {
                return new int[] { numDict[complement], i };
            }

            numDict[nums[i]] = i;
        }
        return Array.Empty<int>();
    }
}