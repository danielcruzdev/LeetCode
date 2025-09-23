using System.Text;

namespace MergeStringsAlternately_1768;

class Program
{
    private static void Main(string[] args)
    {
        const string word1 = "abc";
        const string word2 = "pqr";

        var result = MergeAlternately(word1, word2);
        
        Console.WriteLine(result);
    }

    private static string MergeAlternately(string word1, string word2)
    {
        var merged = new StringBuilder();
        var maxLength = Math.Max(word1.Length, word2.Length);
    
        for (var i = 0; i < maxLength; i++)
        {
            if (i < word1.Length)
                merged.Append(word1[i]);
            if (i < word2.Length)
                merged.Append(word2[i]);
        }
    
        return merged.ToString();
    }
}