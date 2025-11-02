# Move Zeroes - LeetCode 283

## Descrição do Problema

Dado um array de inteiros `nums`, mova todos os `0`'s para o final dele, mantendo a ordem relativa dos elementos não-zero.

**Nota:** Você deve fazer isso **in-place** (no próprio array) sem fazer uma cópia do array.

## Exemplos

### Exemplo 1:
**Input:** `nums = [0,1,0,3,12]`  
**Output:** `[1,3,12,0,0]`

### Exemplo 2:
**Input:** `nums = [0]`  
**Output:** `[0]`

## Restrições

- `1 <= nums.length <= 10⁴`
- `-2³¹ <= nums[i] <= 2³¹ - 1`

**Follow up:** Você consegue minimizar o número total de operações feitas?

---

## Abordagem de Solução

### Estratégia: Técnica do Ponteiro Esquerdo (Left Pointer)

A solução utiliza um **ponteiro esquerdo** que marca a posição onde o próximo elemento não-zero deve ser colocado. A ideia é simples e eficiente:

### Como Funciona (Passo a Passo):

#### 1️⃣ **Primeira Passagem - Mover elementos não-zero para a esquerda**
- Criamos um ponteiro `leftPointer` que começa em 0
- Percorremos o array inteiro com um loop
- Sempre que encontramos um número **diferente de zero**:
  - Colocamos esse número na posição `leftPointer`
  - Incrementamos o `leftPointer`

**Resultado:** Todos os números não-zero ficam agrupados no início do array, na ordem correta.

#### 2️⃣ **Segunda Passagem - Preencher o resto com zeros**
- A partir da posição `leftPointer` até o final do array
- Preenchemos todas as posições com `0`

### Exemplo Visual:

```
Input: [0, 1, 0, 3, 12]

🔄 Primeira Passagem (mover não-zeros):
leftPointer = 0

i=0: nums[0]=0 → é zero, pula
i=1: nums[1]=1 → não é zero!
     nums[0] = 1, leftPointer = 1
     Array: [1, 1, 0, 3, 12]
     
i=2: nums[2]=0 → é zero, pula

i=3: nums[3]=3 → não é zero!
     nums[1] = 3, leftPointer = 2
     Array: [1, 3, 0, 3, 12]
     
i=4: nums[4]=12 → não é zero!
     nums[2] = 12, leftPointer = 3
     Array: [1, 3, 12, 3, 12]

🔄 Segunda Passagem (preencher com zeros):
leftPointer = 3

i=3: nums[3] = 0 → Array: [1, 3, 12, 0, 12]
i=4: nums[4] = 0 → Array: [1, 3, 12, 0, 0]

✅ Output: [1, 3, 12, 0, 0]
```

### Outro Exemplo:

```
Input: [0, 0, 0, 1]

🔄 Primeira Passagem:
- Pula os três zeros
- Quando encontra o 1 (i=3), coloca na posição 0
- Array fica: [1, 0, 0, 1]
- leftPointer = 1

🔄 Segunda Passagem:
- Preenche posições 1, 2, 3 com zero
- Array fica: [1, 0, 0, 0]

✅ Output: [1, 0, 0, 0]
```

### Por Que Esta Abordagem É Eficiente?

✅ **Espaço constante O(1)**: Modifica o array original, sem usar arrays auxiliares  
✅ **Tempo linear O(n)**: Passa pelo array apenas duas vezes (2n ≈ n)  
✅ **In-place**: Não cria cópias do array  
✅ **Mantém a ordem**: Os elementos não-zero preservam sua ordem relativa  
✅ **Minimiza operações**: Apenas sobrescreve posições necessárias

### Complexidade:

- **Tempo:** O(n) - onde n é o tamanho do array
- **Espaço:** O(1) - usa apenas variáveis auxiliares (leftPointer, i)

### Vantagens da Solução:

1. **Simples de entender**: Dois loops separados com responsabilidades claras
2. **Não precisa trocar elementos**: Apenas sobrescreve valores
3. **Funciona para todos os casos**: Arrays sem zeros, só zeros, ou mistos
4. **Eficiente**: Número mínimo de operações necessárias

