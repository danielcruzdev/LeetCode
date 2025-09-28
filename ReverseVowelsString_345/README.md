# LeetCode 345 - Reverse Vowels of a String

## Descrição do Problema

Dado uma string `s`, reverta apenas todas as vogais na string e retorne-a.

As vogais são 'a', 'e', 'i', 'o' e 'u', e elas podem aparecer em maiúsculas e minúsculas, mais de uma vez.

## Exemplos

**Exemplo 1:**
- Input: `s = "IceCreAm"`
- Output: `"AceCreIm"`
- Explicação: As vogais em s são ['I', 'e', 'e', 'A']. Ao reverter as vogais, s torna-se "AceCreIm".

**Exemplo 2:**
- Input: `s = "leetcode"`
- Output: `"leotcede"`

## Restrições
- 1 <= s.length <= 3 * 10^5
- s consiste em caracteres ASCII imprimíveis.

## Como o Problema foi Resolvido

### Abordagem: Algoritmo de Dois Ponteiros

A solução utiliza a técnica de **dois ponteiros** para resolver o problema de forma eficiente:

1. **Inicialização**: 
   - Criamos um `HashSet` com todas as vogais (maiúsculas e minúsculas) para busca rápida O(1)
   - Convertemos a string em um array de caracteres para permitir modificações
   - Definimos dois ponteiros: `left` no início (índice 0) e `right` no fim (último índice)

2. **Algoritmo Principal**:
   - Enquanto `left < right`:
     - Movemos o ponteiro `left` para a direita até encontrar uma vogal
     - Movemos o ponteiro `right` para a esquerda até encontrar uma vogal
     - Se ambos encontraram vogais e ainda não se cruzaram, trocamos as posições
     - Avançamos ambos os ponteiros para continuar o processo

3. **Detalhes Importantes**:
   - A condição `left < right` nos loops internos evita que os ponteiros saiam dos limites
   - A troca é feita usando tuple deconstruction: `(chars[left], chars[right]) = (chars[right], chars[left])`
   - Funciona corretamente mesmo com strings sem vogais

### Complexidade

- **Tempo**: O(n) - cada caractere é visitado no máximo uma vez
- **Espaço**: O(1) - usando apenas variáveis auxiliares (o HashSet de vogais tem tamanho fixo)

### Por que essa Abordagem Funciona?

A técnica de dois ponteiros é ideal aqui porque:
- Precisamos trocar elementos em posições específicas (vogais)
- Não precisamos criar estruturas de dados adicionais para armazenar as vogais
- O algoritmo é naturalmente eficiente, processando a string em uma única passada
- Mantém a ordem relativa das consoantes inalterada

Link do problema: [LeetCode 345](https://leetcode.com/problems/reverse-vowels-of-a-string/)
