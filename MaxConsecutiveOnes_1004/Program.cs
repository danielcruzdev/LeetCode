namespace MaxConsecutiveOnes_1004;

class Program
{
    static void Main(string[] args)
    {
        // Teste 1
        int[] nums1 = [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0];
        int k1 = 2;
        Console.WriteLine($"Teste 1: {LongestOnes(nums1, k1)}"); // Esperado: 6
        
        // Teste 2
        int[] nums2 = [0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1];
        int k2 = 3;
        Console.WriteLine($"Teste 2: {LongestOnes(nums2, k2)}"); // Esperado: 10
        
        // Teste 3 - caso extremo: todos zeros
        int[] nums3 = [0, 0, 0, 0];
        int k3 = 2;
        Console.WriteLine($"Teste 3: {LongestOnes(nums3, k3)}"); // Esperado: 2
        
        // Teste 4 - caso extremo: todos uns
        int[] nums4 = [1, 1, 1, 1];
        int k4 = 0;
        Console.WriteLine($"Teste 4: {LongestOnes(nums4, k4)}"); // Esperado: 4
    }
    
    /// <summary>
    /// Solução usando Janela Deslizante (Sliding Window) com Dois Ponteiros
    /// Complexidade de Tempo: O(n) - cada elemento é visitado no máximo 2 vezes
    /// Complexidade de Espaço: O(1) - apenas variáveis auxiliares
    /// </summary>
    public static int LongestOnes(int[] nums, int k)
    {
        int left = 0;           // Ponteiro esquerdo da janela
        int zerosCount = 0;     // Contador de zeros na janela atual
        int maxLength = 0;      // Maior sequência encontrada
        
        // Ponteiro direito percorre o array expandindo a janela
        for (int right = 0; right < nums.Length; right++)
        {
            // Se encontrar um zero, incrementa o contador
            if (nums[right] == 0)
            {
                zerosCount++;
            }
            
            // Se temos mais zeros que o permitido (k),
            // encolhemos a janela movendo o ponteiro esquerdo
            while (zerosCount > k)
            {
                if (nums[left] == 0)
                {
                    zerosCount--;
                }
                left++;
            }
            
            // Calcula o tamanho da janela atual e atualiza o máximo
            int currentLength = right - left + 1;
            maxLength = Math.Max(maxLength, currentLength);
        }
        
        return maxLength;
    }
}