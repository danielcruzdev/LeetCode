# 2215. Encontre a Diferença de Dois Arrays

## Dificuldade: Fácil

## Descrição do Problema

Dado dois arrays de inteiros `nums1` e `nums2`, retorne uma lista com 2 elementos onde:

- O primeiro elemento contém todos os números distintos de `nums1` que **não estão** em `nums2`
- O segundo elemento contém todos os números distintos de `nums2` que **não estão** em `nums1`

**Observação:** Os números podem ser retornados em qualquer ordem e valores duplicados devem aparecer apenas uma vez.

## Exemplos

### Exemplo 1:
```
Entrada: nums1 = [1,2,3], nums2 = [2,4,6]
Saída: [[1,3],[4,6]]
Explicação:
- Em nums1: 1 e 3 não estão em nums2
- Em nums2: 4 e 6 não estão em nums1
```

### Exemplo 2:
```
Entrada: nums1 = [1,2,3,3], nums2 = [1,1,2,2]
Saída: [[3],[]]
Explicação:
- Em nums1: apenas o 3 não está em nums2 (valores duplicados contam apenas uma vez)
- Em nums2: todos os números existem em nums1
```

## Solução Implementada

A solução utiliza **HashSets** para otimizar a busca e garantir valores únicos:

### Passos da Solução:

1. **Criar HashSets**:
   - `hash1`: HashSet vazio para armazenar números únicos de `nums1` que não estão em `nums2`
   - `hash2`: HashSet contendo todos os números de `nums2`

2. **Iterar sobre nums1**:
   - Para cada número em `nums1`:
     - Se o número existe em `nums2`: remove ele de `hash2` (pois está presente em ambos)
     - Se não existe: adiciona em `hash1`

3. **Retornar resultado**:
   - `hash1` contém os números exclusivos de `nums1`
   - `hash2` contém os números exclusivos de `nums2` (após remoções)

### Complexidade:
- **Tempo**: O(n + m) - onde n é o tamanho de nums1 e m é o tamanho de nums2
- **Espaço**: O(n + m) - para armazenar os HashSets

### Vantagens da Solução:
- Uso de HashSet garante valores únicos automaticamente
- Busca em HashSet é O(1), tornando a solução eficiente
- Código simples e fácil de entender
