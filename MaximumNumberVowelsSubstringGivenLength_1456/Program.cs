namespace MaximumNumberVowelsSubstringGivenLength_1456;

public class Solution
{
    public int MaxVowels(string s, int k)
    {
        var currentCount = 0;
        
        for (var i = 0; i < k; i++)
        {
            if (IsVowel(s[i]))
                currentCount++;
        }

        var maxCount = currentCount;
        
        if (maxCount == k)
            return k;
        
        for (var i = k; i < s.Length; i++)
        {
            if (IsVowel(s[i]))
                currentCount++;

            if (IsVowel(s[i - k]))
                currentCount--;

            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                
                if (maxCount == k)
                    return k;
            }
        }

        return maxCount;
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    private static bool IsVowel(char c)
    {
        return c is 'a' or 'e' or 'i' or 'o' or 'u';
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        // Exemplo 1
        string s1 = "abciiidef";
        int k1 = 3;
        int result1 = solution.MaxVowels(s1, k1);
        Console.WriteLine($"Exemplo 1: s = \"{s1}\", k = {k1}");
        Console.WriteLine($"Resultado: {result1}"); // Esperado: 3

        // Exemplo 2
        string s2 = "aeiou";
        int k2 = 2;
        int result2 = solution.MaxVowels(s2, k2);
        Console.WriteLine($"\nExemplo 2: s = \"{s2}\", k = {k2}");
        Console.WriteLine($"Resultado: {result2}"); // Esperado: 2

        // Exemplo 3
        string s3 = "leetcode";
        int k3 = 3;
        int result3 = solution.MaxVowels(s3, k3);
        Console.WriteLine($"\nExemplo 3: s = \"{s3}\", k = {k3}");
        Console.WriteLine($"Resultado: {result3}"); // Esperado: 2
        
        // Exemplo 4
        string s4 = "tryhard";
        int k4 = 4;
        int result4 = solution.MaxVowels(s4, k4);
        Console.WriteLine($"\nExemplo 4: s = \"{s4}\", k = {k4}");
        Console.WriteLine($"Resultado: {result4}"); // Esperado: 1
    }
}

