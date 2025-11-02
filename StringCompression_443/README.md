# String Compression - LeetCode 443

## Descrição do Problema

Dado um array de caracteres `chars`, comprima-o usando o seguinte algoritmo:

Comece com uma string vazia `s`. Para cada grupo de caracteres consecutivos repetidos em `chars`:

- Se o comprimento do grupo for 1, adicione o caractere a `s`.
- Caso contrário, adicione o caractere seguido pelo comprimento do grupo.

A string comprimida `s` não deve ser retornada separadamente, mas sim armazenada no próprio array de entrada `chars`. Note que comprimentos de grupo com 10 ou mais caracteres serão divididos em múltiplos caracteres em `chars`.

Após terminar de modificar o array de entrada, retorne o novo comprimento do array.

**Você deve escrever um algoritmo que use apenas espaço extra constante.**

**Nota:** Os caracteres no array além do comprimento retornado não importam e devem ser ignorados.

## Exemplos

### Exemplo 1:
**Input:** `chars = ["a","a","b","b","c","c","c"]`  
**Output:** Retorna 6, e os primeiros 6 caracteres do array de entrada devem ser: `["a","2","b","2","c","3"]`  
**Explicação:** Os grupos são "aa", "bb" e "ccc". Isso comprime para "a2b2c3".

### Exemplo 2:
**Input:** `chars = ["a"]`  
**Output:** Retorna 1, e o primeiro caractere do array de entrada deve ser: `["a"]`  
**Explicação:** O único grupo é "a", que permanece sem compressão, pois é um único caractere.

### Exemplo 3:
**Input:** `chars = ["a","b","b","b","b","b","b","b","b","b","b","b","b"]`  
**Output:** Retorna 4, e os primeiros 4 caracteres do array de entrada devem ser: `["a","b","1","2"]`  
**Explicação:** Os grupos são "a" e "bbbbbbbbbbbb". Isso comprime para "ab12".

## Restrições

- `1 <= chars.length <= 2000`
- `chars[i]` é uma letra minúscula inglesa, letra maiúscula inglesa, dígito ou símbolo.

---

## Abordagem de Solução

### Estratégia: Técnica dos Dois Ponteiros (Two Pointers)

A solução utiliza **dois ponteiros** para comprimir o array **in-place** (sem usar espaço extra):

1. **Ponteiro `read`**: Percorre o array original lendo os caracteres
2. **Ponteiro `write`**: Marca a posição onde devemos escrever o resultado comprimido

### Como Funciona (Passo a Passo):

#### 1️⃣ **Contar caracteres repetidos**
- O ponteiro `read` avança enquanto encontra o mesmo caractere
- Contamos quantas vezes o caractere se repete

#### 2️⃣ **Escrever o caractere**
- Escrevemos o caractere na posição `write`
- Incrementamos o ponteiro `write`

#### 3️⃣ **Escrever a contagem (se necessário)**
- Se a contagem for maior que 1, convertemos o número para string
- Escrevemos cada dígito individualmente (para números >= 10)
- Se a contagem for 1, não escrevemos nada (apenas o caractere)

#### 4️⃣ **Repetir até o final**
- Continuamos até processar todos os caracteres do array

### Exemplo Visual:

```
Input: ['a','a','b','b','c','c','c']

Passo 1: read=0, write=0
- Encontra 'a' repetido 2 vezes (read avança para 2)
- Escreve 'a' na posição 0 (write=1)
- Escreve '2' na posição 1 (write=2)
Result: ['a','2','b','b','c','c','c']

Passo 2: read=2, write=2
- Encontra 'b' repetido 2 vezes (read avança para 4)
- Escreve 'b' na posição 2 (write=3)
- Escreve '2' na posição 3 (write=4)
Result: ['a','2','b','2','c','c','c']

Passo 3: read=4, write=4
- Encontra 'c' repetido 3 vezes (read avança para 7)
- Escreve 'c' na posição 4 (write=5)
- Escreve '3' na posição 5 (write=6)
Result: ['a','2','b','2','c','3','c']

Retorna write = 6
```

### Por Que Esta Abordagem É Eficiente?

✅ **Espaço constante O(1)**: Modifica o array original, sem criar estruturas auxiliares  
✅ **Tempo linear O(n)**: Passa pelo array apenas uma vez  
✅ **In-place**: Não usa memória extra proporcional ao tamanho da entrada

### Casos Especiais Tratados:

- **Caractere único**: Não adiciona contagem
- **Números grandes (≥ 10)**: Divide em dígitos individuais ('1', '2' para 12)
- **Array com um único elemento**: Retorna 1 sem modificações

