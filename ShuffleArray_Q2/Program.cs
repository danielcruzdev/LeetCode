namespace ShuffleArray_Q2;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 2, 5, 1, 3, 4, 7 };
        var n = 3;
        var result = Shuffle(nums, n);
        Console.WriteLine(string.Join(", ", result));
    }
    
    private static int[] Shuffle(int[] nums, int n)
    {
        var result = new int[2 * n];
        for (int i = 0; i < n; i++)
        {
            result[2 * i] = nums[i];
        }
        
        return result;
    }
}