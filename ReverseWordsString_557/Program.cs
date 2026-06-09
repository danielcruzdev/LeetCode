using System.Text;

namespace ReverseWordsString_557;

class Program
{
    static void Main(string[] args)
    {
        var s = "Let's take LeetCode contest";
        var result = ReverseWords(s);
        Console.WriteLine(result);
    }
    
    private static string ReverseWords(string s)
    {
        var answer = new StringBuilder();
        var right = 0; 
        var left = 0;
        
        while (right < s.Length)
        {
            if (s[right] == ' ')
            {
                answer.Append(s.Substring(left, right - left + 1).Reverse().ToArray());
                left = right + 1;
            }
            right++;
        }
        
        answer.Append(s.Substring(left, right - left).Reverse().ToArray());
        return answer.Remove(0, 1).ToString();
    }
}