using System;
using System.Collections.Generic;
using System.Linq;

namespace DecodeString_394;

class Program
{
    static void Main(string[] args)
    {
        var string1 = "3[a]2[bc]";
        var result = DecodeString(string1);
        Console.WriteLine(result);

        var string2 = "3[a2[c]]";
        var result2 = DecodeString(string2);
        Console.WriteLine(result2);
        
        var string3 = "2[abc]3[cd]ef";
        var result3 = DecodeString(string3);
        Console.WriteLine(result3);
    }
    
    private static string DecodeString(string s)
    {
        var countStack = new Stack<int>();
        var stringStack = new Stack<string>();
        var current = "";
        var k = 0;

        foreach (var ch in s)
        {
            if (char.IsDigit(ch))
            {
                k = k * 10 + (ch - '0');
            }
            else if (ch == '[')
            {
                countStack.Push(k);
                stringStack.Push(current);
                k = 0;
                current = "";
            }
            else if (ch == ']')
            {
                var repeat = countStack.Pop();
                var previous = stringStack.Pop();
                current = previous + string.Concat(Enumerable.Repeat(current, repeat));
            }
            else
            {
                current += ch;
            }
        }

        return current;
    }
}