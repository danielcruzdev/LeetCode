namespace BinarySearch;

class Program
{
    static void Main(string[] args)
    {
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var target = 7;
        var result =  BinarySearch(array, target);
        Console.WriteLine("Steps: " + result.steps + " | " + "Index: " + result.index);

        array = new int[] { 3, 8, 12, 17, 23, 29, 34, 41, 47, 52, 58, 63, 69, 74, 81, 87, 93, 99, 105, 112, 118, 124, 130, 137, 143, 149, 156, 162, 168, 175 };
        target = 99;
        result =  BinarySearch(array, target);
        Console.WriteLine("Steps: " + result.steps + " | " + "Index: " + result.index);

        array = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
        target = 30;
        result =  BinarySearch(array, target);
        Console.WriteLine("Steps: " + result.steps + " | " + "Index: " + result.index);

        array = new int[] { -50, -20, -10, -5, 0, 5, 10, 20, 50 };
        target = 12;
        result =  BinarySearch(array, target);
        Console.WriteLine("Steps: " + result.steps + " | " + "Index: " + result.index);
    }

    private static (int steps, int index) BinarySearch(int[] array, int target)
    {
        var lo = 0;
        var hi = array.Length;
        var steps = 0;
        
        while(lo <= hi)
        {
            steps++;
            var mid = (lo + hi) / 2;
            if (array[mid] == target)
                return (steps, mid);
            else if (array[mid] < target)
                lo = mid + 1;
            else
                hi = mid - 1;
        }
        
        return (steps, -1);
    }
}