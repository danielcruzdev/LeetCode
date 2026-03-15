# 2352. Equal Row and Column Pairs

## Enunciado
Dada uma matriz quadrada `grid` de tamanho `n x n`, precisamos contar quantos pares `(ri, cj)` existem onde:

- `ri` e uma linha
- `cj` e uma coluna
- os valores da linha e da coluna sao exatamente iguais e na mesma ordem

## Exemplos

### Exemplo 1
```text
Input:  grid = [[3,2,1],[1,7,6],[2,7,7]]
Output: 1
```

### Exemplo 2
```text
Input:  grid = [[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]
Output: 3
```

## Solucao utilizada (Trie)
A implementacao em `Program.cs` usa uma **Trie** para representar todas as linhas:

1. Inserimos cada linha da matriz na Trie.
2. No fim de cada caminho, guardamos quantas vezes aquela linha aparece (`EndCount`).
3. Depois, para cada coluna, percorremos a Trie usando os valores dessa coluna.
4. Se o caminho existir ate o fim, somamos `EndCount` ao total de pares.

Isso evita comparar cada linha com cada coluna elemento por elemento (que seria mais custoso).

## Complexidade
- **Tempo:** `O(n^2)` (insercao das linhas + consulta das colunas)
- **Espaco:** `O(n^2)` no pior caso (armazenamento da Trie)

## Restricoes
- `n == grid.length == grid[i].length`
- `1 <= n <= 200`
- `1 <= grid[i][j] <= 10^5`
