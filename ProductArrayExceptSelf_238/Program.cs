namespace ProductArrayExceptSelf_238;

class Program
{
    static void Main(string[] args)
    {
        var case1 = new[] {1, 2, 3, 4};
        var result1 = ProductExceptSelf(case1);
        Console.WriteLine("CASE 1: " + string.Join(", ", result1));
        
        var case2 = new[] {-1, 1, 0, -3, 3};
        var result2 = ProductExceptSelf(case2);
        Console.WriteLine("CASE 2: " + string.Join(", ", result2));
    }
    
    private static int[] ProductExceptSelf(int[] nums) 
    {
        var length = nums.Length;
        var answer = new int[length];
        
        answer[0] = 1;
        for (var i = 1; i < length; i++)
        {
            answer[i] = nums[i - 1] * answer[i - 1];
        }
        
        var rightProduct = 1;
        for (var i = length - 1; i >= 0; i--)
        {
            answer[i] *= rightProduct;
            rightProduct *= nums[i];
        }
        
        return answer;
    }
}