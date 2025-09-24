using System.Text;

namespace GeatestCommonDivisorOfStrings_1071;

class Program
{
    static void Main(string[] args)
    {
        var str1 = "ABCABC";
        var str2 = "ABC";
        
        var case1 = GcdOfStrings(str1, str2);
        
        Console.WriteLine($"CASE 1: {case1}");
        
        str1 = "ABABAB";
        str2 = "ABAB";
        
        var case2 = GcdOfStrings(str1, str2);
        
        Console.WriteLine($"CASE 2: {case2}");
        
        str1 = "LEET";
        str2 = "CODE";
        
        var case3 = GcdOfStrings(str1, str2);
        
        Console.WriteLine($"CASE 3: {case3}");
    }
    
    private static string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
            return "";
        
        int gcdLength;
        
        var a = str1.Length;
        var b = str2.Length;
        
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        gcdLength = a;
        
        return str1[..gcdLength];
    }
}