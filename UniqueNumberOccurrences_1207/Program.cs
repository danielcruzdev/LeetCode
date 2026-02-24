namespace UniqueNumberOccurrences_1207;

class Program
{
    static void Main(string[] args)
    {
        var arr = new int[] { 1, 2, 2, 1, 1, 3 };
        var result = UniqueOccurrences(arr);
        Console.WriteLine(result);
        
        var arr2 = new int[] { 1, 2 };
        var result2 = UniqueOccurrences(arr2);
        Console.WriteLine(result2);
        
        var arr3 = new int[] { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 };
        var result3 = UniqueOccurrences(arr3);
        Console.WriteLine(result3);
    }
    
    private static bool UniqueOccurrences(int[] arr) 
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            var num = arr[i];
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict.Add(num, 1);
            }
        }
        
        var occurrences = dict.Values.ToHashSet();
        return occurrences.Count == dict.Count;
    }
}