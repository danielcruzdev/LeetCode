namespace MaximumAverageSubarray_643;

class Program
{
    static void Main(string[] args)
    {
        // Exemplo 1
        int[] nums1 = { 1, 12, -5, -6, 50, 3 };
        int k1 = 4;
        double result1 = FindMaxAverage(nums1, k1);
        Console.WriteLine($"Exemplo 1: nums = [{string.Join(", ", nums1)}], k = {k1}");
        Console.WriteLine($"Saída: {result1}"); // Esperado: 12.75
        Console.WriteLine();

        // Exemplo 2
        int[] nums2 = { 5 };
        int k2 = 1;
        double result2 = FindMaxAverage(nums2, k2);
        Console.WriteLine($"Exemplo 2: nums = [{string.Join(", ", nums2)}], k = {k2}");
        Console.WriteLine($"Saída: {result2}"); // Esperado: 5.0
    }
    
    private static double FindMaxAverage(int[] nums, int k) {
        // 1. Calcular a soma da primeira janela (primeiros k elementos)
        // Usamos 'double' para evitar problemas com divisão inteira depois
        double currentSum = 0;
        
        for (int i = 0; i < k; i++) {
            currentSum += nums[i];
        }

        // Definimos a soma máxima inicial como a soma da primeira janela
        double maxSum = currentSum;

        // 2. Deslizar a janela pelo array (começando do índice k)
        for (int i = k; i < nums.Length; i++) {
            // Adiciona o novo elemento (nums[i])
            // Remove o elemento que saiu da janela (nums[i - k])
            currentSum = currentSum + nums[i] - nums[i - k];

            // Atualiza o máximo usando Math.Max
            maxSum = Math.Max(maxSum, currentSum);
        }

        // 3. Retorna a média final
        return maxSum / k;
    }
}