namespace ContainerWithMostWater_11;

class Program
{
    static void Main(string[] args)
    {
        // Example 1
        int[] height1 = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        int maxArea1 = MaxArea(height1);
        Console.WriteLine($"Example 1: Input: [{string.Join(", ", height1)}], Output: {maxArea1}");

        // Example 2
        int[] height2 = { 1, 1 };
        int maxArea2 = MaxArea(height2);
        Console.WriteLine($"Example 2: Input: [{string.Join(", ", height2)}], Output: {maxArea2}");
    }
    
    public static int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int width = right - left;
            int minHeight = Math.Min(height[left], height[right]);
            int area = width * minHeight;

            maxArea = Math.Max(maxArea, area);

            // Move o ponteiro com menor altura
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}