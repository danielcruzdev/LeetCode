# Produto do Array Exceto o Próprio Elemento - LeetCode 238

## Descrição do Problema

Dado um array de inteiros `nums`, retorne um array `answer` tal que `answer[i]` seja igual ao produto de todos os elementos de `nums` exceto `nums[i]`.

O produto de qualquer prefixo ou sufixo de `nums` é garantido caber em um inteiro de 32 bits.

Você deve escrever um algoritmo que execute em tempo O(n) e sem usar a operação de divisão.

### Exemplo 1:

**Entrada:** nums = [1,2,3,4]  
**Saída:** [24,12,8,6]

### Exemplo 2:

**Entrada:** nums = [-1,1,0,-3,3]  
**Saída:** [0,0,9,0,0]

## Restrições:

- 2 <= nums.length <= 10⁵
- -30 <= nums[i] <= 30
- A entrada é gerada de forma que answer[i] seja garantido caber em um inteiro de 32 bits.

## Desafio Adicional: 
Você consegue resolver o problema com complexidade de espaço O(1)? (O array de saída não conta como espaço extra para análise de complexidade de espaço.)

---

## Explicação da Solução

A solução implementada resolve o problema em **O(n)** tempo e **O(1)** espaço extra (não contando o array de saída).

### Estratégia:

A ideia é calcular, para cada posição `i`, o produto de todos os elementos à esquerda e à direita de `i`, sem incluir o próprio `nums[i]`.

### Como funciona:

1. **Primeira Passagem (Produtos à Esquerda):**
   - Percorremos o array da esquerda para a direita
   - Para cada posição `i`, armazenamos em `answer[i]` o produto de todos os elementos à esquerda de `i`
   - Inicializamos `answer[0] = 1` (não há elementos à esquerda)
   - Para cada `i` de 1 até n-1: `answer[i] = nums[i-1] * answer[i-1]`

   **Exemplo com [1,2,3,4]:**
   ```
   answer[0] = 1           (sem elementos à esquerda)
   answer[1] = 1           (produto: 1)
   answer[2] = 1 * 2 = 2   (produto: 1 * 2)
   answer[3] = 2 * 3 = 6   (produto: 1 * 2 * 3)
   ```

2. **Segunda Passagem (Produtos à Direita):**
   - Percorremos o array da direita para a esquerda
   - Mantemos uma variável `rightProduct` que acumula o produto dos elementos à direita
   - Para cada posição `i`, multiplicamos `answer[i]` por `rightProduct`
   - Depois atualizamos `rightProduct` multiplicando por `nums[i]`

   **Continuando o exemplo:**
   ```
   rightProduct = 1
   i = 3: answer[3] = 6 * 1 = 6,     rightProduct = 1 * 4 = 4
   i = 2: answer[2] = 2 * 4 = 8,     rightProduct = 4 * 3 = 12
   i = 1: answer[1] = 1 * 12 = 12,   rightProduct = 12 * 2 = 24
   i = 0: answer[0] = 1 * 24 = 24,   rightProduct = 24 * 1 = 24
   ```

   **Resultado final:** [24, 12, 8, 6] ✓

### Complexidade:

- **Tempo:** O(n) - Fazemos duas passagens pelo array
- **Espaço:** O(1) - Usamos apenas variáveis auxiliares (o array de saída não conta)

### Por que funciona:

Para cada posição `i`, o resultado final é:
```
answer[i] = (produto à esquerda) × (produto à direita)
```

Isso nos dá exatamente o produto de todos os elementos exceto `nums[i]`, sem precisar usar divisão ou arrays auxiliares extras!
