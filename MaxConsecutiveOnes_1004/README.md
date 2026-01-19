# 1004. Máximo de Uns Consecutivos III

## Problema

Você tem um array de números binários (só 0 e 1) e pode transformar **até k zeros em uns**.

**Objetivo:** Encontrar o maior número de uns consecutivos possível após fazer essas transformações.

## Explicação Simples

Imagine que você tem uma fileira de caixas, algumas com bolas (1) e outras vazias (0):

```
[1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0]
```

Você pode colocar bolas em **até 2 caixas vazias (k=2)**. Qual é a maior sequência de caixas com bolas que você consegue criar?

A resposta é **6 caixas seguidas**:
```
[1, 1, 1, 0, 0, ⭐1⭐, 1, 1, 1, 1, ⭐1⭐]
        └─────────────────┘
         6 uns consecutivos
```

## Exemplos

### Exemplo 1:
**Entrada:** nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2  
**Saída:** 6  
**Explicação:** Transformamos os zeros nas posições 5 e 10, criando uma sequência de 6 uns consecutivos.

### Exemplo 2:
**Entrada:** nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3  
**Saída:** 10  
**Explicação:** Transformamos 3 zeros, criando uma sequência de 10 uns consecutivos.

## Solução: Janela Deslizante (Sliding Window)

A melhor solução usa **dois ponteiros** que formam uma "janela" que desliza pelo array:

### Como funciona:
1. **Expande** a janela movendo o ponteiro direito
2. **Conta** quantos zeros existem dentro da janela
3. Se tiver **mais de k zeros**, **encolhe** a janela movendo o ponteiro esquerdo
4. **Registra** o tamanho máximo da janela encontrada

### Exemplo Visual (Passo a Passo):

Array: `[1,1,1,0,0,0,1,1,1,1,0]`, k = 2

```
Passo 1: [1,1,1,0,0,0,1,1,1,1,0]
          L→R
          └┘ Tamanho: 1, Zeros: 0 ✓

Passo 2: [1,1,1,0,0,0,1,1,1,1,0]
          L───→R
          └───┘ Tamanho: 3, Zeros: 0 ✓

Passo 3: [1,1,1,0,0,0,1,1,1,1,0]
          L─────→R
          └─────┘ Tamanho: 4, Zeros: 1 ✓

Passo 4: [1,1,1,0,0,0,1,1,1,1,0]
          L───────→R
          └───────┘ Tamanho: 5, Zeros: 2 ✓

Passo 5: [1,1,1,0,0,0,1,1,1,1,0]
          L─────────→R
          └─────────┘ Tamanho: 6, Zeros: 3 ✗ (encolhe!)

         [1,1,1,0,0,0,1,1,1,1,0]
            L───────→R
            └───────┘ Tamanho: 5, Zeros: 2 ✓

Passo 6: [1,1,1,0,0,0,1,1,1,1,0]
            L─────────→R
            └─────────┘ Tamanho: 6, Zeros: 2 ✓ (máximo!)
```

### Por que é eficiente?
- **Cada elemento é visitado no máximo 2 vezes** (uma pelo ponteiro direito, uma pelo esquerdo)
- **Não precisa testar todas as combinações** possíveis de subarray
- **Usa apenas variáveis simples** (não precisa de estruturas de dados extras)

### Complexidade:
- **Tempo:** O(n) - percorre o array apenas uma vez
- **Espaço:** O(1) - usa apenas variáveis auxiliares

## Restrições

- 1 ≤ nums.length ≤ 10⁵
- nums[i] é 0 ou 1
- 0 ≤ k ≤ nums.length
