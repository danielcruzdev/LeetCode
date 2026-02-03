namespace ConcatenationArray_Q1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Concatenação de Array - Cenários de Teste ===\n");
        
        // Teste 1: Exemplo 1 do problema
        Console.WriteLine("Teste 1:");
        int[] test1 = { 1, 2, 1 };
        Console.WriteLine($"Input: [{string.Join(",", test1)}]");
        int[] result1 = GetConcatenation(test1);
        Console.WriteLine($"Output: [{string.Join(",", result1)}]");
        Console.WriteLine($"Esperado: [1,2,1,1,2,1]");
        Console.WriteLine($"Status: {(string.Join(",", result1) == "1,2,1,1,2,1" ? "✓ PASSOU" : "✗ FALHOU")}\n");
        
        // Teste 2: Exemplo 2 do problema
        Console.WriteLine("Teste 2:");
        int[] test2 = { 1, 3, 2, 1 };
        Console.WriteLine($"Input: [{string.Join(",", test2)}]");
        int[] result2 = GetConcatenation(test2);
        Console.WriteLine($"Output: [{string.Join(",", result2)}]");
        Console.WriteLine($"Esperado: [1,3,2,1,1,3,2,1]");
        Console.WriteLine($"Status: {(string.Join(",", result2) == "1,3,2,1,1,3,2,1" ? "✓ PASSOU" : "✗ FALHOU")}\n");
        
        // Teste 3: Array com um único elemento
        Console.WriteLine("Teste 3: Array unitário");
        int[] test3 = { 5 };
        Console.WriteLine($"Input: [{string.Join(",", test3)}]");
        int[] result3 = GetConcatenation(test3);
        Console.WriteLine($"Output: [{string.Join(",", result3)}]");
        Console.WriteLine($"Esperado: [5,5]");
        Console.WriteLine($"Status: {(string.Join(",", result3) == "5,5" ? "✓ PASSOU" : "✗ FALHOU")}\n");
        
        // Teste 4: Array com valores iguais
        Console.WriteLine("Teste 4: Valores iguais");
        int[] test4 = { 7, 7, 7 };
        Console.WriteLine($"Input: [{string.Join(",", test4)}]");
        int[] result4 = GetConcatenation(test4);
        Console.WriteLine($"Output: [{string.Join(",", result4)}]");
        Console.WriteLine($"Esperado: [7,7,7,7,7,7]");
        Console.WriteLine($"Status: {(string.Join(",", result4) == "7,7,7,7,7,7" ? "✓ PASSOU" : "✗ FALHOU")}\n");
        
        // Teste 5: Array maior
        Console.WriteLine("Teste 5: Array maior");
        int[] test5 = { 10, 20, 30, 40, 50 };
        Console.WriteLine($"Input: [{string.Join(",", test5)}]");
        int[] result5 = GetConcatenation(test5);
        Console.WriteLine($"Output: [{string.Join(",", result5)}]");
        Console.WriteLine($"Esperado: [10,20,30,40,50,10,20,30,40,50]");
        Console.WriteLine($"Status: {(string.Join(",", result5) == "10,20,30,40,50,10,20,30,40,50" ? "✓ PASSOU" : "✗ FALHOU")}\n");
        
        Console.WriteLine("=== Todos os testes foram executados ===");
    }
    
    private static int[] GetConcatenation(int[] nums) 
    {
        var n = nums.Length;
        var result = new int[2 * n];
        
        for (var i = 0; i < n; i++) 
        {
            result[i] = nums[i];
            result[i + n] = nums[i];
        }
        
        return result;
    }
}