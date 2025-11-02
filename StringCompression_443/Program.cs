namespace StringCompression_443;

class Program
{
    static void Main(string[] args)
    {
        var case1 = new[] {'a','a','b','b','c','c','c'};
        var result1 = Compress(case1);
        Console.WriteLine($"Case1: {result1}");
        
        var case2 = new[] {'a'};
        var result2 = Compress(case2);
        Console.WriteLine($"Case2: {result2}");
        
        var case3 = new[] {'a','b','b','b','b','b','b','b','b','b','b','b','b'};
        var result3 = Compress(case3);
        Console.WriteLine($"Case3: {result3}");
    }
    
    private static int Compress(char[] chars) 
    {
        var write = 0;
        var read = 0;
        
        while (read < chars.Length) {
            var currentChar = chars[read];
            var count = 0;
            
            while (read < chars.Length && chars[read] == currentChar) {
                read++;
                count++;
            }
            
            chars[write++] = currentChar;

            if (count <= 1) continue;
            
            var countStr = count.ToString();
            foreach (var c in countStr) {
                chars[write++] = c;
            }
        }
        
        return write;
    }
}