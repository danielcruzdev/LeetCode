using System.Text;

namespace RemovingStarsFromString_2390;

class Program
{
    static void Main(string[] args)
    {
        var s = "leet**cod*e";
        var output1 = RemoveStars(s);
        Console.WriteLine(output1);

        s = "erase*****";
        var output2 = RemoveStars(s);
        Console.WriteLine(output2);
    }
    
    private static string RemoveStars(string s)
    {
        var output = new Stack<char>();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != '*')
            {
                output.Push(s[i]);
                continue;
            }
            
            output.Pop();
        }

        return new string(output.Reverse().ToArray());
    }
}