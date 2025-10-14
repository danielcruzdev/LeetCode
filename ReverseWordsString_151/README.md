# Reverse Words in a String - LeetCode 151

## Problem Description

Given an input string `s`, reverse the order of the **words**.

A **word** is defined as a sequence of non-space characters. The words in `s` will be separated by at least one space.

Return *a string of the words in reverse order concatenated by a single space*.

**Note** that `s` may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.

## Examples

### Example 1:
```
Input: s = "the sky is blue"
Output: "blue is sky the"
```

### Example 2:
```
Input: s = "  hello world  "
Output: "world hello"
Explanation: Your reversed string should not contain leading or trailing spaces.
```

### Example 3:
```
Input: s = "a good   example"
Output: "example good a"
Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
```

## Constraints

- `1 <= s.length <= 10⁴`
- `s` contains English letters (upper-case and lower-case), digits, and spaces `' '`.
- There is at least one word in `s`.

## Solution Explanation

### Approach: Split, Reverse, Join

A solução implementada utiliza uma abordagem direta e eficiente:

1. **Split**: Utiliza `s.Split(' ', StringSplitOptions.RemoveEmptyEntries)` para:
   - Dividir a string em palavras usando espaço como delimitador
   - Remover automaticamente entradas vazias (múltiplos espaços consecutivos)
   - Ignorar espaços no início e fim da string

2. **Reverse**: Aplica `Array.Reverse(words)` para inverter a ordem das palavras no array

3. **Join**: Usa `string.Join(' ', words)` para reunir as palavras com um único espaço entre elas

### Por que esta abordagem funciona?

- **StringSplitOptions.RemoveEmptyEntries**: Esta opção é crucial pois elimina automaticamente:
  - Espaços múltiplos entre palavras
  - Espaços no início da string
  - Espaços no final da string
  
- **Array.Reverse**: Inverte eficientemente a ordem dos elementos in-place

- **string.Join**: Garante que as palavras sejam conectadas com exatamente um espaço

### Código da Solução

```csharp
private static string ReverseWords(string s) 
{
    var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    Array.Reverse(words);
    return string.Join(' ', words);
}
```

## Análise de Complexidade

- **Complexidade de Tempo**: O(n)
  - Split: O(n) - percorre toda a string
  - Reverse: O(k) onde k é o número de palavras
  - Join: O(n) - reconstrói a string
  
- **Complexidade de Espaço**: O(n)
  - Array de palavras: O(k) onde k é o número de palavras
  - String resultado: O(n)

## Casos de Teste

O programa testa os três casos de exemplo:

1. **Caso Normal**: `"the sky is blue"` → `"blue is sky the"`
2. **Espaços Extras**: `"  hello world  "` → `"world hello"`
3. **Múltiplos Espaços**: `"a good   example"` → `"example good a"`

## Follow-up

**Pergunta**: Se o tipo de dados string for mutável em sua linguagem, você pode resolver isso in-place com O(1) de espaço extra?

**Resposta**: Em C#, strings são imutáveis, então não é possível resolver in-place com O(1) de espaço. Em linguagens com strings mutáveis, seria possível implementar uma solução que:
1. Remove espaços extras in-place
2. Reverte toda a string
3. Reverte cada palavra individualmente

## Como Executar

```bash
dotnet run
```

**Saída Esperada:**
```
CASE 1: blue is sky the
CASE 2: world hello
CASE 3: example good a
```
