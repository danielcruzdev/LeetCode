namespace FindHighestAltitude_1732;

class Program
{
    static void Main(string[] args)
    {
        var gain = new int[] { -5, 1, 5, 0, -7 };
        var result = LargestAltitude(gain);
        Console.WriteLine(result);
        
        var gain2 = new int[] { -4, -3, -2, -1, 4, 3, 2 };
        var result2 = LargestAltitude(gain2);
        Console.WriteLine(result2);
    }
    
    private static int LargestAltitude(int[] gain)
    {
        var highest = 0;
        var current = 0;
        for (var i = 0; i < gain.Length; i++)
        {
            current = gain[i] + current;
            
            if (current > highest)
                highest = current;
        }
        
        return highest;
    }
}