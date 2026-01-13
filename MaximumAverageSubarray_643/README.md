Você recebe um array de inteiros `nums` consistindo de `n` elementos, e um inteiro `k`.

Encontre um subarray contíguo cujo comprimento seja igual a `k` que tenha o valor médio máximo e retorne esse valor. Qualquer resposta com um erro de cálculo menor que 10-5 será aceita.

**Exemplo 1:**

**Entrada:** nums = [1,12,-5,-6,50,3], k = 4
**Saída:** 12.75000
**Explicação:** A média máxima é (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

**Exemplo 2:**

**Entrada:** nums = [5], k = 1
**Saída:** 5.00000

## Solução

O problema foi resolvido utilizando a técnica da **Janela Deslizante (Sliding Window)**. Esta abordagem é eficiente para processar subarrays ou substrings de um tamanho fixo.

A lógica implementada é a seguinte:

1.  **Inicialização da Janela:** Primeiro, calculamos a soma dos `k` elementos iniciais do array. Essa será a soma da nossa primeira "janela" e a definimos como a soma máxima encontrada até o momento.

2.  **Deslizar a Janela:** Em seguida, percorremos o restante do array, do índice `k` até o final. Em cada passo, "deslizamos" a janela para a direita:
    *   Adicionamos o novo elemento que entra na janela.
    *   Subtraímos o elemento que ficou para trás (o primeiro elemento da janela anterior).

3.  **Atualização da Soma Máxima:** Após cada deslize, comparamos a nova soma da janela com a soma máxima registrada até então e a atualizamos se a nova soma for maior.

4.  **Cálculo da Média:** Ao final do processo, a soma máxima encontrada é dividida por `k` para obter a média máxima, que é o resultado final.

Esta técnica evita o recálculo da soma de cada subarray do zero, resultando em uma solução com complexidade de tempo O(n), muito mais eficiente do que uma abordagem de força bruta O(n*k).
