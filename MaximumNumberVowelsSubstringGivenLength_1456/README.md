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
