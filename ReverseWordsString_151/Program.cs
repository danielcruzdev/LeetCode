namespace ReverseWordsString_151;

class Program
{
    static void Main(string[] args)
    {
        var s = "the sky is blue";
        var result = ReverseWords(s);
        Console.WriteLine($"CASE 1: {result}");
        
        s = "  hello world  ";
        result = ReverseWords(s);
        Console.WriteLine($"CASE 2: {result}");
        
        s = "a good   example";
        result = ReverseWords(s);
        Console.WriteLine($"CASE 3: {result}");
    }
    
    private static string ReverseWords(string s) 
    {
        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);
        return string.Join(' ', words);
    }
}
