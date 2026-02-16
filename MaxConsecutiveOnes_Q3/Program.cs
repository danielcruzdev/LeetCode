namespace MaxConsecutiveOnes_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums1 = new int[] { 1, 1, 0, 1, 1, 1 };
            var output1 = FindMaxConsecutiveOnes(nums1);
            Console.WriteLine(output1);

            var num2 = new int[] { 1, 0, 1, 1, 0, 1 };
            var output2 = FindMaxConsecutiveOnes(num2);
            Console.WriteLine(output2);
        }

        private static int FindMaxConsecutiveOnes(int[] nums)
        {
            var maxCount = 0;
            var count = 0; 

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                    continue;
                }

                maxCount = Math.Max(maxCount, count);
                count = 0;
            }

            return maxCount;
        }
    }
}
