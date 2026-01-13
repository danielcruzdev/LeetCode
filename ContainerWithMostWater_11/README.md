# 11. Container With Most Water

You are given an integer array `height` of length `n`. There are `n` vertical lines drawn such that the two endpoints of the `i`th line are `(i, 0)` and `(i, height[i])`.

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

**Notice that you may not slant the container.**

### Example 1:
**Input:** `height = [1,8,6,2,5,4,8,3,7]`
**Output:** `49`
**Explanation:** The above vertical lines are represented by array `[1,8,6,2,5,4,8,3,7]`. In this case, the max area of water (blue section) the container can contain is 49.

### Example 2:
**Input:** `height = [1,1]`
**Output:** `1`

---

## Solução

A abordagem utilizada para resolver este problema é a técnica de **dois ponteiros**.

1.  **Inicialização:**
    *   Inicializamos dois ponteiros, `left` no início do array (`índice 0`) e `right` no final do array (`índice n-1`).
    *   Uma variável `maxArea` é inicializada com `0` para armazenar a área máxima encontrada.

2.  **Iteração:**
    *   O algoritmo itera enquanto o ponteiro `left` for menor que o ponteiro `right`.
    *   Em cada iteração, a área é calculada da seguinte forma:
        *   A largura (`width`) é a distância entre os dois ponteiros: `right - left`.
        *   A altura (`minHeight`) é o mínimo entre as alturas das duas linhas: `Math.Min(height[left], height[right])`. A altura do contêiner é limitada pela linha mais baixa.
        *   A área (`area`) é `width * minHeight`.
    *   A `maxArea` é atualizada com o valor máximo entre a `maxArea` atual e a `area` recém-calculada.

3.  **Movendo os Ponteiros:**
    *   Para maximizar a área, precisamos mover o ponteiro que aponta para a linha de menor altura. A lógica é que, ao mover o ponteiro da linha mais alta, a largura diminuirá e a altura do contêiner (limitada pela linha mais baixa) não aumentará, resultando em uma área menor ou igual.
    *   Se `height[left]` for menor que `height[right]`, incrementamos `left`.
    *   Caso contrário, decrementamos `right`.

4.  **Término:**
    *   O loop continua até que os ponteiros se cruzem (`left >= right`).
    *   Ao final, a variável `maxArea` conterá a maior área de água que o contêiner pode armazenar, e esse valor é retornado.
