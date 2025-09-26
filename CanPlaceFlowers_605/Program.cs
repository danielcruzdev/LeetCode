namespace CanPlaceFlowers_605;

class Program
{
    static void Main(string[] args)
    {
        int[] flowerbed = [1, 0, 0, 0, 1];
        var n = 1;
        var result = CanPlaceFlowers(flowerbed, n);
        Console.WriteLine($"CASE 1: {result}");

        n = 2;
        result = CanPlaceFlowers(flowerbed, n);
        Console.WriteLine($"CASE 2: {result}");
        
        int[] flowerbed2 = [1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1];
        n = 3;
        
        result = CanPlaceFlowers(flowerbed2, n);
        Console.WriteLine($"CASE 3: {result}");
    }

    private static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        var count = 0;
        for (var i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] != 0) continue;
            
            var prevEmpty = flowerbed[0] == 0;
            if (i > 0)
            {
                var prev = flowerbed[i - 1];
                prevEmpty = prev == 0;
                if(!prevEmpty) continue;
            }
            
            var nextEmpty = true;
            if (i < flowerbed.Length - 1)
            {
                var next = flowerbed[i + 1];
                nextEmpty = next == 0;
                if(!nextEmpty) continue;
            }
            
            var canPlace = prevEmpty && nextEmpty;
            if (!canPlace) continue;
            
            flowerbed[i] = 1;
            count++;
        }

        return count >= n;
    }
}