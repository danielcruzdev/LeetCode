# 1657. Determinar se Duas Strings São Próximas

## Descrição do Problema

Duas strings são consideradas **próximas** se você conseguir obter uma a partir da outra usando as seguintes operações:

- **Operação 1:** Trocar quaisquer dois caracteres existentes.
  - Exemplo: `abcde` → `aecdb`
- **Operação 2:** Transformar todas as ocorrências de um caractere existente em outro caractere existente, e vice-versa.
  - Exemplo: `aacabb` → `bbcbaa` (todos os `a`s viram `b`s, e todos os `b`s viram `a`s)

Você pode usar as operações em qualquer uma das strings quantas vezes quiser.

Dadas duas strings `word1` e `word2`, retorne `true` se `word1` e `word2` forem próximas, e `false` caso contrário.

---

## Exemplos

**Exemplo 1:**
```
Entrada: word1 = "abc", word2 = "bca"
Saída: true
Explicação: É possível obter word2 a partir de word1 em 2 operações.
  Operação 1: "abc" -> "acb"
  Operação 1: "acb" -> "bca"
```

**Exemplo 2:**
```
Entrada: word1 = "a", word2 = "aa"
Saída: false
Explicação: É impossível obter word2 a partir de word1, ou vice-versa, com qualquer número de operações.
```

**Exemplo 3:**
```
Entrada: word1 = "cabbba", word2 = "abbccc"
Saída: true
Explicação: É possível obter word2 a partir de word1 em 3 operações.
  Operação 1: "cabbba" -> "caabbb"
  Operação 2: "caabbb" -> "baaccc"
  Operação 2: "baaccc" -> "abbccc"
```

---

## Restrições

- `1 <= word1.length, word2.length <= 10^5`
- `word1` e `word2` contêm apenas letras minúsculas do alfabeto inglês.

---

## Explicação da Solução

Para que duas strings sejam **próximas**, três condições devem ser satisfeitas:

1. **Mesmo tamanho:** As strings devem ter o mesmo comprimento, pois nenhuma operação adiciona ou remove caracteres.

2. **Mesmo conjunto de caracteres únicos:** Ambas as strings devem conter exatamente os mesmos caracteres distintos. A Operação 2 apenas troca frequências entre caracteres já existentes — ela não cria novos caracteres.

3. **Mesma multiconjunto de frequências:** As frequências dos caracteres de uma string, quando ordenadas, devem ser iguais às frequências da outra string ordenadas. A Operação 2 permite redistribuir as frequências entre os caracteres, mas o conjunto de valores de frequência em si não muda.

### Exemplo de raciocínio:

Para `word1 = "cabbba"` e `word2 = "abbccc"`:
- Frequências em `word1`: `a=2, b=3, c=1` → ordenado: `[1, 2, 3]`
- Frequências em `word2`: `a=1, b=2, c=3` → ordenado: `[1, 2, 3]`
- Conjunto de caracteres de ambas: `{a, b, c}`
- Todas as condições satisfeitas → `true`

---

## Como a Solução Foi Implementada

A solução usa **dois arrays de tamanho 26** (um para cada letra do alfabeto) para contar quantas vezes cada letra aparece em cada string. Depois, verifica as três condições na ordem.

### Passo a Passo

**1. Verificar o tamanho**

Se as strings têm tamanhos diferentes, já retorna `false` imediatamente. Simples e rápido.

**2. Contar as letras**

Para cada string, percorre todos os caracteres e incrementa a posição correspondente no array de contagem.

```
word1 = "cabbba" → counts1: a=2, b=3, c=1
word2 = "abbccc" → counts2: a=1, b=2, c=3
```

> **O que significa `c - 'a'`?**
>
> Em C#, cada caractere possui um valor numérico definido pela tabela ASCII. As letras minúsculas são sequenciais nessa tabela:
>
> | Letra | Valor ASCII |
> |-------|-------------|
> | `'a'` | 97          |
> | `'b'` | 98          |
> | `'c'` | 99          |
> | ...   | ...         |
> | `'z'` | 122         |
>
> Ao subtrair `'a'` (97) do caractere atual, obtemos um índice de **0 a 25**, que representa a posição da letra no array:
>
> ```
> 'a' - 'a' = 0  → posição 0
> 'b' - 'a' = 1  → posição 1
> 'c' - 'a' = 2  → posição 2
> 'z' - 'a' = 25 → posição 25
> ```
>
> Isso permite usar um array de tamanho fixo 26 como um mapa de frequências, sem precisar de um dicionário.

**3. Verificar se as duas strings usam as mesmas letras**

Percorre os 26 índices e verifica se, para cada letra, ela aparece nas **duas** strings ou em **nenhuma**. Se uma letra existe só em uma das strings, retorna `false`.

```csharp
var has1 = counts1[i] > 0;
var has2 = counts2[i] > 0;
if (has1 != has2) return false;
```

**4. Verificar se os conjuntos de frequências são iguais**

Aqui está o ponto mais inteligente da solução. Para cada letra que existe em `word1` com frequência `f`, tenta encontrar alguma letra em `word2` que também tenha frequência `f`. Se encontrar, "remove" essa frequência de `counts2` (trocando pelo valor atual), para que não seja usada duas vezes. Se não encontrar, retorna `false`.

```
counts1: a=2, b=3, c=1
counts2: a=1, b=2, c=3

- 'a' tem freq 2 em counts1. Tem algum j em counts2 com freq 2? Sim, 'b'=2. Troca: counts2[b] = counts2[a] = 1.
- 'b' tem freq 3 em counts1. Tem algum j em counts2 com freq 3? Sim, 'c'=3. Troca: counts2[c] = counts2[b] = 1.
- 'c' já está igual (counts1[c] == counts2[c] == 1). Pula.
→ true
```

> **Observação:** Esta abordagem evita ordenar os arrays, usando uma busca direta com troca de posições no próprio `counts2`. O resultado é o mesmo: verifica se os multiconjuntos de frequências são equivalentes.

### Complexidade

| | Complexidade |
|---|---|
| **Tempo** | O(n) — percorre cada string uma vez, mais dois loops fixos de 26 iterações |
| **Espaço** | O(1) — os arrays têm tamanho fixo de 26, alocados na stack com `stackalloc` |

