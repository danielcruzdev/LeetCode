# 1207. Número Único de Ocorrências

## Descrição

Dado um array de inteiros `arr`, retorne `true` se o número de ocorrências de cada valor no array for único, ou `false` caso contrário.

## Exemplos

**Exemplo 1:**
```
Input:  arr = [1, 2, 2, 1, 1, 3]
Output: true
```
> O valor `1` aparece `3` vezes, `2` aparece `2` vezes e `3` aparece `1` vez. Nenhum valor tem o mesmo número de ocorrências.

**Exemplo 2:**
```
Input:  arr = [1, 2]
Output: false
```

**Exemplo 3:**
```
Input:  arr = [-3, 0, 1, -3, 1, 1, 1, -3, 10, 0]
Output: true
```

## Restrições

- `1 <= arr.length <= 1000`
- `-1000 <= arr[i] <= 1000`

---

## Solução

### Estratégia: `Dictionary` + `HashSet`

A solução foi implementada em duas etapas:

**1. Contagem de ocorrências com `Dictionary`**

Percorremos o array e usamos um `Dictionary<int, int>` para mapear cada número à sua quantidade de ocorrências.

```
arr = [1, 2, 2, 1, 1, 3]

dict = {
  1 → 3,
  2 → 2,
  3 → 1
}
```

**2. Verificação de unicidade com `HashSet`**

Convertemos os **valores** do dicionário (as contagens) para um `HashSet`.
Como o `HashSet` não permite duplicatas, se o seu tamanho for igual ao número de chaves do dicionário, todas as ocorrências são únicas.

```
dict.Values = [3, 2, 1] → Count = 3
HashSet     = {3, 2, 1} → Count = 3

3 == 3 → true ✅
```

### Complexidade

| Tipo   | Complexidade |
|--------|--------------|
| Tempo  | O(n)         |
| Espaço | O(n)         |
