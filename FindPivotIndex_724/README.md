# 724. Encontrar o Índice Pivô

## Descrição

Dado um array de inteiros `nums`, calcule o **índice pivô** do array.

O índice pivô é aquele onde a soma de todos os números estritamente à **esquerda** é igual à soma de todos os números estritamente à **direita**.

Se o índice estiver na borda esquerda do array, a soma à esquerda é `0` (não há elementos à esquerda). O mesmo vale para a borda direita.

Retorne o índice pivô **mais à esquerda**. Se não existir, retorne `-1`.

## Exemplos

**Exemplo 1:**
```
Input:  nums = [1, 7, 3, 6, 5, 6]
Output: 3
```
> Soma esquerda = 1 + 7 + 3 = 11  
> Soma direita  = 5 + 6 = 11 ✅

**Exemplo 2:**
```
Input:  nums = [1, 2, 3]
Output: -1
```
> Nenhum índice satisfaz a condição.

**Exemplo 3:**
```
Input:  nums = [2, 1, -1]
Output: 0
```
> Soma esquerda = 0 (nenhum elemento à esquerda do índice 0)  
> Soma direita  = 1 + (-1) = 0 ✅

## Restrições

- `1 <= nums.length <= 10⁴`
- `-1000 <= nums[i] <= 1000`

---

## Solução

### Estratégia: Soma Total + Soma Acumulada à Esquerda

A solução evita calcular a soma direita a cada iteração, usando a relação matemática entre as somas.

**1. Calcular a soma total do array**

```
nums = [1, 7, 3, 6, 5, 6]
sum  = 28
```

**2. Iterar verificando a condição do pivô**

Para cada índice `i`, a condição de pivô é:

```
leftSum == sum - leftSum - nums[i]
```

Onde `sum - leftSum - nums[i]` é exatamente a **soma à direita** de `i`, sem precisar recalculá-la.

```
i = 0 → leftSum = 0  | rightSum = 28 - 0 - 1  = 27 ❌
i = 1 → leftSum = 1  | rightSum = 28 - 1 - 7  = 20 ❌
i = 2 → leftSum = 8  | rightSum = 28 - 8 - 3  = 17 ❌
i = 3 → leftSum = 11 | rightSum = 28 - 11 - 6 = 11 ✅ → retorna 3
```

### Complexidade

| Tipo   | Complexidade |
|--------|--------------|
| Tempo  | O(n)         |
| Espaço | O(1)         |
