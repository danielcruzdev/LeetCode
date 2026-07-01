using System.Text;

namespace ReverseOnlyLetters_917;

class Program
{
    static void Main(string[] args)
    {
        var s = "ab-cd";
        var result = ReverseOnlyLetters(s);
        Console.WriteLine(result); //Output: "dc-ba"

        s = "a-bC-dEf-ghIj";
        result = ReverseOnlyLetters(s);
        Console.WriteLine(result); //Output: "j-Ih-gfE-dCba"

        s = "Test1ng-Leet=code-Q!";
        result = ReverseOnlyLetters(s);
        Console.WriteLine(result); //Output: "Qedo1ct-eeLg=ntse-T!"
    }
    
    private static string ReverseOnlyLetters(string s)
    {
        var left = 0; 
        var right = s.Length-1;
        var builder = new StringBuilder(s);
        
        while(left<right){
            
            if(!char.IsLetter(s[left]))
            {
                left++;
                continue;
            }
            
            if(!char.IsLetter(s[right]))
            {
                right--;
                continue;
            }

            (builder[left], builder[right]) = (builder[right], builder[left]);
            left++;
            right--;
        }
        return builder.ToString();
    }
}