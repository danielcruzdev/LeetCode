# Merge Strings Alternately (LeetCode 1768)

Link do problema no LeetCode: https://leetcode.com/problems/merge-strings-alternately/?envType=study-plan-v2&envId=leetcode-75

## Descrição do problema
Dadas duas strings `word1` e `word2`, mescle-as adicionando caracteres em ordem alternada, começando por `word1`. Se uma string for mais longa que a outra, anexe os caracteres restantes ao final da string mesclada.

Exemplos:
- Input: `word1 = "abc"`, `word2 = "pqr"` → Output: `"apbqcr"`
- Input: `word1 = "ab"`, `word2 = "pqrs"` → Output: `"apbqrs"`
- Input: `word1 = "abcd"`, `word2 = "pq"` → Output: `"apbqcd"`

### Restrições
- 1 <= `word1.length`, `word2.length` <= 100
- `word1` e `word2` consistem em letras minúsculas inglesas

## Abordagem utilizada
- Usar `StringBuilder` para construir a string resultado de forma eficiente (evita concatenações custo\-osas).
- Iterar até o comprimento máximo entre as duas strings e, em cada iteração:
    - Se o índice estiver dentro de `word1`, acrescentar `word1[i]`.
    - Se o índice estiver dentro de `word2`, acrescentar `word2[i]`.
- Isso garante que caracteres sejam intercalados e que os remanescentes (se houver) sejam adicionados ao final.

Pseudocódigo:
1. criar `merged = new StringBuilder()`
2. `maxLength = Math.Max(word1.Length, word2.Length)`
3. para `i` de 0 até `maxLength - 1`:
    - se `i < word1.Length` então `merged.Append(word1[i])`
    - se `i < word2.Length` então `merged.Append(word2[i])`
4. retornar `merged.ToString()`

## Complexidade
- Tempo: O(n + m), onde n = comprimento de `word1` e m = comprimento de `word2` (cada caractere é processado no máximo uma vez).
- Espaço: O(n + m) para armazenar a string mesclada.

## Implementação (C#)
Ver implementação em `MergeStringsAlternately_1768/Program.cs` — utiliza `StringBuilder` e um único loop até `maxLength`.

## Casos de borda
- Strings de tamanho igual.
- Uma string vazia não é permitida segundo as restrições, mas a solução funciona se uma das strings for vazia (retorna a outra string).
- Comprimentos máximos pequenos (<= 100) — abordagem é eficiente e simples.
