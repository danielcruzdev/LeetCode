# Can Place Flowers (LeetCode 605)

## Problema
Você tem um canteiro de flores representado por um array de inteiros, onde:
- `0` significa que o local está vazio.
- `1` significa que já existe uma flor plantada.

Não é permitido plantar flores em locais adjacentes (ou seja, não pode haver dois `1` seguidos).

Dado o array `flowerbed` e um inteiro `n`, o desafio é determinar se é possível plantar `n` novas flores sem violar a regra de não-adjacência.

[Link para o problema no LeetCode](https://leetcode.com/problems/can-place-flowers/)

## Exemplo

```
Input: flowerbed = [1,0,0,0,1], n = 1
Output: true

Input: flowerbed = [1,0,0,0,1], n = 2
Output: false
```

## Abordagem da Solução
1. Percorremos o array verificando cada posição vazia (`0`).
2. Para cada posição vazia, checamos se as posições anterior e posterior também estão vazias (ou se está nas extremidades do array).
3. Se for possível plantar, marcamos a posição como ocupada (`1`) e incrementamos o contador de flores plantadas.
4. No final, verificamos se conseguimos plantar pelo menos `n` flores.

Essa abordagem garante que nunca haverá flores em locais adjacentes e respeita todas as restrições do problema.

## Restrições
- 1 <= flowerbed.length <= 2 * 10⁴
- flowerbed[i] é 0 ou 1.
- Não há dois `1` adjacentes no array inicial.
- 0 <= n <= flowerbed.length
