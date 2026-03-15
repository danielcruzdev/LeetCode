namespace EqualRowColumnPairs_2352;

class Program
{
    static void Main(string[] args)
    {
        int[][] grid1 =
        [
            [3, 2, 1],
            [1, 7, 6],
            [2, 7, 7]
        ];

        int[][] grid2 =
        [
            [3, 1, 2, 2],
            [1, 4, 4, 5],
            [2, 4, 2, 2],
            [2, 4, 2, 2]
        ];

        RunSample(grid1, expected: 1);
        RunSample(grid2, expected: 3);
    }

    private static void RunSample(int[][] grid, int expected)
    {
        int result = EqualPairs(grid);
        Console.WriteLine($"Resultado: {result} | Esperado: {expected}");
    }

    private static int EqualPairs(int[][] grid)
    {
        int n = grid.Length;
        var root = new TrieNode();

        // Insere cada linha na Trie e conta duplicatas no fim do caminho.
        for (int r = 0; r < n; r++)
        {
            TrieNode node = root;
            for (int c = 0; c < n; c++)
            {
                int value = grid[r][c];
                if (!node.Children.TryGetValue(value, out TrieNode? next))
                {
                    next = new TrieNode();
                    node.Children[value] = next;
                }

                node = next;
            }

            node.EndCount++;
        }

        int pairs = 0;

        // Para cada coluna, percorre a Trie como se fosse uma linha.
        for (int c = 0; c < n; c++)
        {
            TrieNode node = root;
            bool found = true;

            for (int r = 0; r < n; r++)
            {
                int value = grid[r][c];
                if (!node.Children.TryGetValue(value, out TrieNode? next))
                {
                    found = false;
                    break;
                }

                node = next;
            }

            if (found)
            {
                pairs += node.EndCount;
            }
        }

        return pairs;
    }

    private sealed class TrieNode
    {
        public Dictionary<int, TrieNode> Children { get; } = new();
        public int EndCount { get; set; }
    }
}