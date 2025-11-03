namespace IsSubsequence_392;

class Program
{
    static void Main(string[] args)
    {
        var s1 = "abc";
        var t1 = "ahbgdc";
        var result1 = IsSubsequence(s1, t1);
        Console.WriteLine($"Case 1: {result1}");
        
        var s2 = "axc";
        var t2 = "ahbgdc";
        var result2 = IsSubsequence(s2, t2);
        Console.WriteLine($"Case 2: {result2}");
    }
    
    private static bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
            return true;
        
        if (s.Length > t.Length)
            return false;
        
        var j = 0;
        for (var i = 0; i < t.Length; i++)
        {
            if (t[i] == s[j])
            {
                j++;
                
                if (j == s.Length)
                    return true;
            }
        }
        
        return j == s.Length;
    }
}