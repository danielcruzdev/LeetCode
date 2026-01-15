# 1456. Número Máximo de Vogais em uma Substring de Tamanho Fixo

## Descrição do Problema

Dado uma string `s` e um inteiro `k`, o objetivo é encontrar o número máximo de vogais em qualquer substring de `s` que tenha o comprimento `k`.

As vogais no alfabeto inglês são 'a', 'e', 'i', 'o', 'u'.

### O que é uma substring?
Uma substring é uma parte contínua de uma string. Por exemplo, para a string "leetcode", "leet" e "code" são substrings, mas "ltcd" não é.

### Exemplos

**Exemplo 1:**

- **Input:** `s = "abciiidef"`, `k = 3`
- **Output:** `3`
- **Explicação:** A substring "iii" contém 3 vogais, que é o máximo possível em uma substring de tamanho 3.

**Exemplo 2:**

- **Input:** `s = "aeiou"`, `k = 2`
- **Output:** `2`
- **Explicação:** Qualquer substring de tamanho 2 ("ae", "ei", "io", "ou") contém 2 vogais.

**Exemplo 3:**

- **Input:** `s = "leetcode"`, `k = 3`
- **Output:** `2`
- **Explicação:** As substrings "lee", "eet" e "ode" contêm 2 vogais. Nenhuma substring de tamanho 3 tem mais do que 2 vogais.

## Restrições

- `1 <= s.length <= 10^5`
- `s` consiste em letras minúsculas do alfabeto inglês.
- `1 <= k <= s.length`

## Solução com Janela Deslizante (Sliding Window)

Para resolver este problema de forma eficiente, podemos usar a técnica de **janela deslizante**. A ideia é manter uma "janela" de tamanho `k` que desliza pela string, e contamos as vogais dentro dessa janela.

1.  **Inicialização:**
    *   Começamos com uma janela inicial cobrindo os primeiros `k` caracteres da string.
    *   Contamos o número de vogais nessa primeira janela. Esse valor é nossa contagem máxima inicial.

2.  **Deslizando a Janela:**
    *   Movemos a janela um caractere para a direita. Para fazer isso:
        *   **Removemos o caractere da esquerda:** Verificamos se o caractere que está saindo da janela (à esquerda) é uma vogal. Se for, diminuímos nossa contagem de vogais.
        *   **Adicionamos o caractere da direita:** Verificamos se o novo caractere que está entrando na janela (à direita) é uma vogal. Se for, aumentamos nossa contagem.
    *   A cada passo, comparamos a contagem de vogais da janela atual com a contagem máxima global que encontramos até agora e a atualizamos se necessário.

3.  **Finalização:**
    *   Repetimos o processo de deslizar a janela até chegarmos ao final da string.
    *   O valor máximo que armazenamos durante o processo é a resposta final.

Essa abordagem é muito eficiente porque só percorremos a string uma vez, e para cada caractere, fazemos um número constante de operações. Isso nos dá uma complexidade de tempo de O(n), onde n é o comprimento da string.

## Otimizações de Performance

Embora a solução com Janela Deslizante já seja O(n) - a melhor complexidade possível -, podemos aplicar otimizações práticas para melhorar a performance real:

### 1. **Método IsVowel Inline (Mais Rápido)**
Em vez de usar um `HashSet` para verificar vogais, usamos comparações diretas:
```csharp
private static bool IsVowel(char c)
{
    return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
}
```
**Por quê é mais rápido?**
- HashSet tem overhead de busca e hash calculation
- Comparações diretas são operações de CPU extremamente rápidas
- Com apenas 5 vogais, comparações são mais eficientes que estrutura de dados

### 2. **Early Termination (Retorno Antecipado)**
Se encontrarmos uma janela com `k` vogais, já sabemos que esse é o máximo possível:
```csharp
if (maxCount == k)
    return k;
```
**Benefício:** Em casos favoráveis, evitamos processar o resto da string.

### 3. **HashSet Estático (Se Preferir HashSet)**
Se você prefere usar HashSet, declare-o como `static readonly`:
```csharp
private static readonly HashSet<char> Vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u'};
```
**Benefício:** Evita criar um novo HashSet a cada chamada do método, economizando memória e tempo de alocação.

### 4. **Substituir Math.Max por Comparação Direta**
```csharp
if (currentCount > maxCount)
    maxCount = currentCount;
```
**Benefício:** Evita a chamada de método Math.Max, reduzindo overhead.

### Comparação de Performance

| Abordagem | Complexidade | Performance Prática |
|-----------|--------------|---------------------|
| Força Bruta (todas substrings) | O(n × k) | Muito lenta para strings grandes |
| Sliding Window + HashSet | O(n) | Boa |
| Sliding Window + HashSet estático | O(n) | Melhor (evita alocação) |
| Sliding Window + IsVowel inline | O(n) | **Melhor** (menos overhead) |
| Sliding Window + IsVowel + Early termination | O(n) no pior caso, O(k) no melhor | **Ótima** |

### Conclusão
A solução otimizada mantém a complexidade O(n), mas com constantes menores, resultando em melhor performance prática, especialmente para:
- Strings muito grandes (até 10⁵ caracteres)
- Múltiplas chamadas do método
- Ambientes com restrições de memória


