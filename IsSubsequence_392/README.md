# 392. É Subsequência (Is Subsequence)

## 📋 Descrição do Problema

Dadas duas strings `s` e `t`, retorne `true` se `s` é uma subsequência de `t`, ou `false` caso contrário.

Uma **subsequência** de uma string é uma nova string formada a partir da string original removendo alguns (pode ser nenhum) dos caracteres **sem alterar as posições relativas** dos caracteres restantes.

Por exemplo:
- ✅ "ace" **é** uma subsequência de "abcde"
- ❌ "aec" **não é** uma subsequência de "abcde" (ordem errada)

## 📝 Exemplos

### Exemplo 1:
```
Entrada: s = "abc", t = "ahbgdc"
Saída: true
Explicação: 
    a h b g d c
    ↓   ↓     ↓
    a   b     c
```

### Exemplo 2:
```
Entrada: s = "axc", t = "ahbgdc"
Saída: false
Explicação: Não existe 'x' em "ahbgdc"
```

## ⚙️ Restrições

- `0 <= s.length <= 100`
- `0 <= t.length <= 10⁴`
- `s` e `t` consistem apenas de letras minúsculas do alfabeto inglês

## 💡 Abordagem da Solução

### Conceito
A solução usa a técnica de **Dois Ponteiros** (Two Pointers) para percorrer ambas as strings de forma eficiente.

### Como Funciona?

Imagine que você está lendo um livro (string `t`) procurando por palavras específicas em ordem (string `s`):

1. **Você tem uma lista de palavras para encontrar** → string `s` = "abc"
2. **Você lê o livro página por página** → string `t` = "ahbgdc"
3. **Quando encontra uma palavra da lista, marca como encontrada e passa para a próxima**
4. **Se chegar ao final tendo encontrado todas as palavras NA ORDEM, sucesso!**

### Passo a Passo

```
s = "abc"
t = "ahbgdc"
     ↑
     
Ponteiro j = 0 (procurando 'a')

1. t[0] = 'a' == s[0] = 'a' ✓ → j = 1 (agora procura 'b')
2. t[1] = 'h' != s[1] = 'b' ✗ → continua
3. t[2] = 'b' == s[1] = 'b' ✓ → j = 2 (agora procura 'c')
4. t[3] = 'g' != s[2] = 'c' ✗ → continua
5. t[4] = 'd' != s[2] = 'c' ✗ → continua
6. t[5] = 'c' == s[2] = 'c' ✓ → j = 3 = s.Length → ENCONTROU TUDO!

Resultado: true
```

### Complexidade

- **Tempo:** O(n) onde n é o tamanho de `t` - percorremos `t` apenas uma vez
- **Espaço:** O(1) - usamos apenas variáveis simples (ponteiro `j`)

## 🚀 Desafio Adicional (Follow-up)

**Pergunta:** Se você tiver que verificar milhares de strings `s` (s₁, s₂, ..., sₖ onde k ≥ 10⁹) contra a mesma string `t`, como otimizar?

**Resposta:** Pré-processar `t` criando um dicionário que mapeia cada caractere para uma lista de índices onde ele aparece. Depois, para cada `s`, usar busca binária nos índices para encontrar ocorrências em ordem crescente. Isso reduz cada busca de O(n) para O(m log n) onde m é o tamanho de `s`.

