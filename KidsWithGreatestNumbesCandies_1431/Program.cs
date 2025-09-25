namespace KidsWithGreatestNumbesCandies_1431
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var candies = new int[] { 2, 3, 5, 1, 3 };
            var extraCandies = 3;

            var case1 = KidsWithCandies(candies, extraCandies);
            Console.WriteLine(string.Join(", ", case1));

            candies = [4, 2, 1, 1, 2];
            extraCandies = 1;

            var case2 = KidsWithCandies(candies, extraCandies);
            Console.WriteLine(string.Join(", ", case2));

            candies = [12, 1, 12];
            extraCandies = 10;

            var case3 = KidsWithCandies(candies, extraCandies);
            Console.WriteLine(string.Join(", ", case3));
        }

        private static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var result = new bool[candies.Length];
            var maxValue = candies.Max();

            for (int i = 0; i < candies.Length; i++)
            {
                candies[i] += extraCandies;
            }

            for (int i = 0; i < candies.Length; i++)
            {
                var hasGreatest = true;

                if (candies[i] < maxValue)
                    hasGreatest = false;       

                result[i] = hasGreatest;
            }

            return result;
        }
    }
}
