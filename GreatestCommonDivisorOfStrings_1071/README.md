# 1071. Greatest Common Divisor of Strings

**Link do problema**: [https://leetcode.com/problems/greatest-common-divisor-of-strings/](https://leetcode.com/problems/greatest-common-divisor-of-strings/)

## Descrição do Problema

Para duas strings `s` e `t`, dizemos que "`t` divide `s`" se e somente se `s = t + t + t + ... + t + t` (ou seja, `t` é concatenada consigo mesma uma ou mais vezes).

Dadas duas strings `str1` e `str2`, retorne a maior string `x` tal que `x` divide tanto `str1` quanto `str2`.

## Exemplos

**Exemplo 1:**
- Input: `str1 = "ABCABC"`, `str2 = "ABC"`
- Output: `"ABC"`

**Exemplo 2:**
- Input: `str1 = "ABABAB"`, `str2 = "ABAB"`
- Output: `"AB"`

**Exemplo 3:**
- Input: `str1 = "LEET"`, `str2 = "CODE"`
- Output: `""`

## Abordagem Utilizada

### Algoritmo

1. **Verificação de Compatibilidade**: Primeiro verificamos se `str1 + str2 == str2 + str1`. Se não forem iguais, não existe um divisor comum, então retornamos string vazia.

2. **Cálculo do GCD**: Se as strings são compatíveis, o tamanho do maior divisor comum será o GCD (Greatest Common Divisor) dos comprimentos das duas strings.

3. **Extração do Resultado**: Retornamos a substring de `str1` do índice 0 até o tamanho do GCD calculado.

### Por que essa abordagem funciona?

- Se duas strings têm um divisor comum, então concatená-las em qualquer ordem deve resultar na mesma string
- O tamanho do maior divisor comum será sempre o GCD dos comprimentos das strings originais
- O algoritmo euclidiano para calcular GCD é eficiente e bem estabelecido

### Complexidade

- **Tempo**: O(n + m) onde n e m são os comprimentos das strings (para a concatenação e comparação)
- **Espaço**: O(n + m) para armazenar as strings concatenadas temporariamente

## Implementação

A solução utiliza:
- Verificação de compatibilidade através de concatenação
- Algoritmo euclidiano para calcular o GCD dos comprimentos
- Substring para extrair o resultado final

Esta abordagem é elegante e eficiente, evitando loops complexos e verificações desnecessárias.
