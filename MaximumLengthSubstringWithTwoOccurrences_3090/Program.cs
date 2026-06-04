using Microsoft.VisualBasic.CompilerServices;

namespace MaximumLengthSubstringWithTwoOccurrences_3090;

class Program
{
    static void Main(string[] args)
    {
        var s = "bcbbbcba";
        var result = MaximumLengthSubstring(s);
        Console.WriteLine(result);
    }
    
    private static int MaximumLengthSubstring(string s)
    {
        var right = 0;
        var left = 0;
        var max = 1;
        
        var counter = new Dictionary<char, int>
        {
            [s[0]] = 1
        };

        while (right < s.Length - 1)
        {
            right++;
            if(counter.ContainsKey(s[right]))
                counter[s[right]]++;
            else
                counter[s[right]] = 1;
            
            while (counter[s[right]] == 3)
            {
                counter[s[left]]--;
                left++;
            }
            
            max = Math.Max(max, right - left + 1);
        }
        
        return max;
    }
}