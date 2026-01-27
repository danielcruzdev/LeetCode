namespace LongestSubarrayDeletingOneElement_1493;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine("--- Cenários de Teste: Maior Subarray de 1's Após Deletar Um Elemento ---");
        Console.WriteLine();

        // Teste 1: Exemplo do problema
        int[] nums1 = { 1, 1, 0, 1 };
        int expected1 = 3;
        int result1 = solution.LongestSubarray(nums1);
        Console.WriteLine($"Teste 1: Entrada = [{string.Join(", ", nums1)}]");
        Console.WriteLine($"Resultado: {result1}, Esperado: {expected1}");
        Console.WriteLine($"Passou: {result1 == expected1}");
        Console.WriteLine("--------------------------------------------------");

        // Teste 2: Exemplo do problema com mais elementos
        int[] nums2 = { 0, 1, 1, 1, 0, 1, 1, 0, 1 };
        int expected2 = 5;
        int result2 = solution.LongestSubarray(nums2);
        Console.WriteLine($"Teste 2: Entrada = [{string.Join(", ", nums2)}]");
        Console.WriteLine($"Resultado: {result2}, Esperado: {expected2}");
        Console.WriteLine($"Passou: {result2 == expected2}");
        Console.WriteLine("--------------------------------------------------");

        // Teste 3: Apenas 1s, obrigatório deletar um
        int[] nums3 = { 1, 1, 1 };
        int expected3 = 2;
        int result3 = solution.LongestSubarray(nums3);
        Console.WriteLine($"Teste 3: Entrada = [{string.Join(", ", nums3)}]");
        Console.WriteLine($"Resultado: {result3}, Esperado: {expected3}");
        Console.WriteLine($"Passou: {result3 == expected3}");
        Console.WriteLine("--------------------------------------------------");

        // Teste 4: Apenas 0s
        int[] nums4 = { 0, 0, 0 };
        int expected4 = 0;
        int result4 = solution.LongestSubarray(nums4);
        Console.WriteLine($"Teste 4: Entrada = [{string.Join(", ", nums4)}]");
        Console.WriteLine($"Resultado: {result4}, Esperado: {expected4}");
        Console.WriteLine($"Passou: {result4 == expected4}");
        Console.WriteLine("--------------------------------------------------");
        
        // Teste 5: Array vazio (caso de borda, embora as restrições digam >= 1)
        int[] nums5 = { };
        int expected5 = 0;
        int result5 = solution.LongestSubarray(nums5);
        Console.WriteLine($"Teste 5: Entrada = []");
        Console.WriteLine($"Resultado: {result5}, Esperado: {expected5}");
        Console.WriteLine($"Passou: {result5 == expected5}");
        Console.WriteLine("--------------------------------------------------");

        // Teste 6: Um único 1
        int[] nums6 = { 1 };
        int expected6 = 0;
        int result6 = solution.LongestSubarray(nums6);
        Console.WriteLine($"Teste 6: Entrada = [{string.Join(", ", nums6)}]");
        Console.WriteLine($"Resultado: {result6}, Esperado: {expected6}");
        Console.WriteLine($"Passou: {result6 == expected6}");
        Console.WriteLine("--------------------------------------------------");
        
        // Teste 7: Um único 0
        int[] nums7 = { 0 };
        int expected7 = 0;
        int result7 = solution.LongestSubarray(nums7);
        Console.WriteLine($"Teste 7: Entrada = [{string.Join(", ", nums7)}]");
        Console.WriteLine($"Resultado: {result7}, Esperado: {expected7}");
        Console.WriteLine($"Passou: {result7 == expected7}");
        Console.WriteLine("--------------------------------------------------");
    }
}

public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int left = 0;
        int zeroCount = 0;
        int maxLength = 0;
        bool allOnes = true;

        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                zeroCount++;
                allOnes = false;
            }

            while (zeroCount > 1)
            {
                if (nums[left] == 0)
                {
                    zeroCount--;
                }
                left++;
            }
            
            // O tamanho da janela atual é (right - left + 1).
            // Como precisamos deletar um elemento (o zero), o tamanho do subarray de 1s é (tamanho da janela - 1).
            maxLength = Math.Max(maxLength, right - left);
        }

        // Se todos os números forem 1, somos obrigados a deletar um, então o resultado é o tamanho total - 1.
        return allOnes ? nums.Length - 1 : maxLength;
    }
}
