namespace IncreasingTripletSubsequence_334;

class Program
{
    static void Main(string[] args)
    {
        int[] case1 = [1, 2, 3, 4, 5];
        var result = IncreasingTriplet(case1);
        Console.WriteLine("case1: " + result);
        
        int[] case2 = [5, 4, 3, 2, 1];
        var result2 = IncreasingTriplet(case2);
        Console.WriteLine("case2: " + result2);
        
        int[] case3 = [2, 1, 5, 0, 4, 6];
        var result3 = IncreasingTriplet(case3);
        Console.WriteLine("case3: " + result3);

        int[] case4 = [20, 100, 10, 12, 5, 13];
        var result4 = IncreasingTriplet(case4);
        Console.WriteLine("case4: " + result4);
    }
    
    private static bool IncreasingTriplet(int[] nums)
    {
        var first = int.MaxValue;
        var second = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= first)
            {
                first = nums[i];
            }
            else if (nums[i] <= second)
            {
                 second = nums[i];
            }
            else
            {
                return true;
            }
        }
        
        return false;
    }
}