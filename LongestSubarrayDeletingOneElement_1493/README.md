# 1493. Maior Subarray de 1's Após Deletar Um Elemento

## Descrição do Problema

Imagine que você tem uma fileira de números que só podem ser `0` ou `1`. Você precisa **deletar exatamente um número** dessa fileira.

Depois de deletar um número, seu objetivo é encontrar o maior grupo (subarray) contínuo que contenha apenas números `1`. O resultado que você deve retornar é o tamanho desse maior grupo.

Se não houver nenhum grupo de `1`s após a exclusão, retorne `0`.

### Exemplos Para Entender Melhor

**Exemplo 1:**

*   **Entrada:** `nums = [1, 1, 0, 1]`
*   **Explicação:** Se deletarmos o `0` na terceira posição, a fileira se torna `[1, 1, 1]`. O maior grupo de `1`s tem tamanho **3**.
*   **Saída:** `3`

**Exemplo 2:**

*   **Entrada:** `nums = [0, 1, 1, 1, 0, 1, 1, 0, 1]`
*   **Explicação:** Se deletarmos o `0` na quinta posição, a fileira se torna `[0, 1, 1, 1, 1, 1, 0, 1]`. O maior grupo contínuo de `1`s é `[1, 1, 1, 1, 1]`, que tem tamanho **5**.
*   **Saída:** `5`

**Exemplo 3:**

*   **Entrada:** `nums = [1, 1, 1]`
*   **Explicação:** Lembre-se, você **precisa** deletar um elemento. Se deletarmos qualquer um dos `1`s, teremos `[1, 1]`. O maior grupo de `1`s tem tamanho **2**.
*   **Saída:** `2`

### Restrições

*   O tamanho da fileira de números (`nums.length`) estará entre `1` e `100.000`.
*   Cada número na fileira (`nums[i]`) será sempre `0` ou `1`.

---

## Como Resolvemos Isso? A Estratégia da "Janela Deslizante"

Para resolver este problema de forma eficiente, usamos uma técnica chamada **"Janela Deslizante"**. Pense nela como uma moldura que você desliza sobre a sua fileira de números.

### A Ideia Principal

A nossa "janela" vai expandir e encolher enquanto percorre a fileira. O objetivo é manter dentro da janela, no máximo, **um único zero**. Por quê? Porque o problema nos permite deletar **um** elemento. Se tivermos um zero dentro da nossa janela, podemos "fingir" que o deletamos para criar uma sequência contínua de `1`s.

### Passo a Passo (Como se fosse um jogo)

1.  **Comece com uma janela vazia:** Pegue sua moldura (nossa janela) e posicione-a no início da fileira. A janela começa com tamanho zero.

2.  **Expanda a janela para a direita:** Vá deslizando a borda direita da janela, um número de cada vez.
    *   Se o número for `1`, ótimo! Apenas aumente sua janela.
    *   Se o número for `0`, você pode incluí-lo, mas com uma condição: você só pode ter **um** `0` dentro da sua janela a qualquer momento.

3.  **E se aparecer um segundo zero?** Aqui está o truque! Se um segundo `0` entrar na janela, você precisa **encolher a janela pela esquerda**. Vá movendo a borda esquerda da janela para a direita até que o primeiro `0` que você encontrou saia da janela. Dessa forma, você garante que sempre terá no máximo um `0` dentro dela.

4.  **Anote o melhor resultado:** A cada passo, depois de expandir ou encolher a janela, você calcula o tamanho dela. Como a gente "deleta" o zero que está dentro, o tamanho do grupo de `1`s é `(tamanho da janela - 1)`. Nós guardamos o maior tamanho que encontrarmos durante todo o processo.

5.  **Continue até o fim:** Repita esse processo de expandir e encolher até que a borda direita da sua janela chegue ao final da fileira de números.

### Exemplo Prático com a Janela

Vamos usar `nums = [0, 1, 1, 1, 0, 1, 1, 0, 1]`.

*   `Janela: [0]` (1 zero) -> Tamanho do grupo de 1s: 0
*   `Janela: [0, 1]` (1 zero) -> Tamanho: 1
*   `Janela: [0, 1, 1]` (1 zero) -> Tamanho: 2
*   `Janela: [0, 1, 1, 1]` (1 zero) -> Tamanho: 3
*   `Janela: [0, 1, 1, 1, 0]` (Opa! 2 zeros!)
    *   **Encolha pela esquerda:** `[1, 1, 1, 0]` (Agora só 1 zero de novo).
    *   O tamanho da janela é 4. O grupo de `1`s tem tamanho `4 - 1 = 3`.
*   `Janela: [1, 1, 1, 0, 1]` (1 zero) -> Tamanho: 4
*   `Janela: [1, 1, 1, 0, 1, 1]` (1 zero) -> Tamanho: 5. **Este é o nosso recorde até agora!**
*   `Janela: [1, 1, 1, 0, 1, 1, 0]` (Opa! 2 zeros!)
    *   **Encolha pela esquerda:** `[1, 1, 0, 1, 1, 0]` -> `[1, 0, 1, 1, 0]` -> `[0, 1, 1, 0]` -> `[1, 1, 0]`
    *   A janela encolhe até o `0` antigo sair. A nova janela é `[1, 1, 0, 1, 1, 0]`. Opa, ainda tem dois zeros. Encolhe mais: `[1, 0, 1, 1, 0]` -> `[0, 1, 1, 0]` -> `[1, 1, 0]`.
    *   Na verdade, o ponteiro esquerdo vai até passar o primeiro zero: a janela se torna `[1, 1, 1, 0, 1, 1, 0]` -> encolhe para `[1, 1, 0, 1, 1]` (depois que o `0` da posição 4 sai). O tamanho é 5.
*   ...e assim por diante.

No final, o maior tamanho que encontramos foi **5**.

### E se a fileira só tiver `1`s?

Se a entrada for `[1, 1, 1]`, nossa janela vai crescer até o final. O tamanho será 3. Mas o problema diz que **precisamos** deletar um elemento. Então, o resultado será `3 - 1 = 2`. Nossa solução trata esse caso especial.

Essa abordagem é muito rápida porque só passamos pela fileira de números uma vez com cada "borda" da janela, tornando-a muito eficiente!
