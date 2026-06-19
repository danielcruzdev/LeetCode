namespace ExponentialSearch;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        var target = 15;
        var result = ExponentialSearch(nums, target);
        Console.WriteLine(result);
    }
    
    private static int ExponentialSearch(int[] nums, int target)
    {
        if (nums[0] == target)
            return 0;

        int bound = 1;

        while (bound < nums.Length && nums[bound] < target)
        {
            bound *= 2;
        }

        int left = bound / 2;
        int right = Math.Min(bound, nums.Length - 1);

        return BinarySearch(nums, target, left, right);
    }

    private static int BinarySearch(
        int[] nums,
        int target,
        int left,
        int right)
    {
        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}