namespace DetermineStringsAreClose_1657;

class Program
{
    static void Main(string[] args)
    {
        var word1 = "abc";
        var word2 = "bca";
        var result = CloseStrings(word1, word2);
        Console.WriteLine(result);
        
        var word3 = "a";
        var word4 = "aa";
        var result2 = CloseStrings(word3, word4);
        Console.WriteLine(result2);
        
        var word5 = "cabbba";
        var word6 = "abbccc";
        var result3 = CloseStrings(word5, word6);
        Console.WriteLine(result3);
    }
    
    private static bool CloseStrings(string word1, string word2) 
    {
        if (word1.Length != word2.Length)
        {
            return false;
        }
        Span<int> counts1 = stackalloc int[26];
        Span<int> counts2 = stackalloc int[26];
        
        foreach (var c in word1)
        {
            counts1[c - 'a']++;
        }
        
        foreach (var c in word2)
        {
            counts2[c - 'a']++;
        }
        
        for (var i = 0; i < 26; i++)
        {
            var has1 = counts1[i] > 0;
            var has2 = counts2[i] > 0;
            if (has1 != has2)
            {
                return false;
            }
        }
        
        for (var i = 0; i < 26; i++)
        {
            if (counts1[i] == 0 || counts1[i] == counts2[i])
            {
                continue;
            }
            var found = false;
            for (var j = i + 1; j < 26; j++)
            {
                if (counts2[j] == counts1[i])
                {
                    found = true;
                    counts2[j] = counts2[i];
                    break;
                }
            }
            if (!found)
            {
                return false;
            }
        }
        
        return true;
    }
}