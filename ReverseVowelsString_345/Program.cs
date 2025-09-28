namespace ReverseVowelsString_345;

class Program
{
    static void Main(string[] args)
    {
        var s = "IceCreAm";
        var result = ReverseVowels(s);
        
        Console.WriteLine("Case 1 Result: " + result);
        
        s = "leetcode";
        result = ReverseVowels(s);
        
        Console.WriteLine("Case 2 Result: " + result);
        
        s = ".,";
        result = ReverseVowels(s);
        
        Console.WriteLine("Case 3 Result: " + result);
    }
    
    private static string ReverseVowels(string s) 
    {
        var vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
        var chars = s.ToCharArray();
        
        var left = 0;
        var right = s.Length - 1;
        
        while (left < right)
        {
            while (left < right && !vowels.Contains(chars[left]))
            {
                left++;
            }
            
            while (left < right && !vowels.Contains(chars[right]))
            {
                right--;
            }
            
            if (left < right)
            {
                (chars[left], chars[right]) = (chars[right], chars[left]);
                left++;
                right--;
            }
        }

        return new string(chars);
    }
}