# 2390. Removing Stars From a String

## Dificuldade
Medium

## Enunciado
Dada uma string `s` contendo letras minusculas e `*`, para cada `*` voce deve:

1. remover o `*`
2. remover tambem o caractere nao-`*` mais proximo a esquerda

No final, retorne a string resultante.

O problema garante que essa operacao sempre e possivel.

## Exemplos

### Exemplo 1
Input: `s = "leet**cod*e"`  
Output: `"lecoe"`

### Exemplo 2
Input: `s = "erase*****"`  
Output: `""`

## Como o problema foi resolvido

A solucao em `Program.cs` usa uma **pilha** (`Stack<char>`):

- Se o caractere atual **nao** for `*`, ele e empilhado.
- Se o caractere atual for `*`, removemos o topo da pilha com `Pop()`.

### Intuicao
A pilha guarda exatamente os caracteres que ainda permanecem no resultado parcial.

- letra normal -> entra no resultado (push)
- `*` -> apaga a letra valida mais recente (pop)

Isso casa perfeitamente com a regra do enunciado: remover o caractere nao-`*` mais proximo a esquerda.

### Passo a passo rapido
Para `"leet**cod*e"`:

1. empilha `l e e t`
2. `*` remove `t`
3. `*` remove `e`
4. empilha `c o d`
5. `*` remove `d`
6. empilha `e`

Pilha final: `l e c o e` -> resultado: `"lecoe"`.

## Complexidade

- Tempo: `O(n)`, onde `n` e o tamanho da string.
- Espaco: `O(n)` no pior caso (quando quase nao ha `*`).

## Implementacao (resumo)

```csharp
private static string RemoveStars(string s)
{
    var output = new Stack<char>();
    for (var i = 0; i < s.Length; i++)
    {
        if (s[i] != '*')
        {
            output.Push(s[i]);
            continue;
        }

        output.Pop();
    }

    return new string(output.Reverse().ToArray());
}
```

## Restricoes

- `1 <= s.length <= 10^5`
- `s` contem letras minusculas e `*`
- sempre existe caractere valido para remover quando aparece `*`
