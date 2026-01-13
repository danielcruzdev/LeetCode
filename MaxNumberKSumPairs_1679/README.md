# 1679. Número Máximo de Pares com Soma K

Você recebe um array de números inteiros `nums` e um número inteiro `k`.

Em uma operação, você pode escolher dois números do array cuja soma seja igual a `k` e removê-los do array.

Retorne o número máximo de operações que você pode realizar no array.

---

### Explicação em Português 🇧🇷

**Problema**

Dado um array de números (`nums`) e um número alvo (`k`), você precisa encontrar o número máximo de pares de números nesse array que somam exatamente `k`. Cada vez que você encontra um par, ele é "removido" e não pode ser usado novamente.

**Exemplos Práticos**

*   **Exemplo 1:**
    *   `nums = [1, 2, 3, 4]`
    *   `k = 5`
    *   **Operações:**
        1.  Pegamos o `1` e o `4` (1 + 4 = 5). Removemos eles. O array fica `[2, 3]`. (1 operação)
        2.  Pegamos o `2` e o `3` (2 + 3 = 5). Removemos eles. O array fica `[]`. (2 operações)
    *   **Resultado:** 2 operações no total.

*   **Exemplo 2:**
    *   `nums = [3, 1, 3, 4, 3]`
    *   `k = 6`
    *   **Operações:**
        1.  Pegamos um `3` e outro `3` (3 + 3 = 6). Removemos eles. O array fica `[1, 4, 3]`. (1 operação)
        2.  Não há mais pares que somem 6.
    *   **Resultado:** 1 operação no total.

---

### Exemplos Originais

**Example 1:**

Input: nums = [1,2,3,4], k = 5
Output: 2
Explanation: Starting with nums = [1,2,3,4]:
- Remove numbers 1 and 4, then nums = [2,3]
- Remove numbers 2 and 3, then nums = []
There are no more pairs that sum up to 5, hence a total of 2 operations.

**Example 2:**

Input: nums = [3,1,3,4,3], k = 6
Output: 1
Explanation: Starting with nums = [3,1,3,4,3]:
- Remove the first two 3's, then nums = [1,4,3]
There are no more pairs that sum up to 6, hence a total of 1 operation.

### Constraints:

*   `1 <= nums.length <= 10^5`
*   `1 <= nums[i] <= 10^9`
*   `1 <= k <= 10^9`

