# 735. Asteroid Collision

**Dificuldade:** Medium

---

## Problema

É dado um array `asteroids` de inteiros representando asteroides em uma fila.

- O **valor absoluto** representa o **tamanho** do asteroide
- O **sinal** representa a **direção** (`+` = direita, `−` = esquerda)

Todos os asteroides se movem na mesma velocidade. Descubra o estado final após todas as colisões.

> **Regras:**
> - Se dois asteroides se encontrarem, o **menor explode**
> - Se forem do **mesmo tamanho**, **ambos explodem**
> - Dois asteroides indo na **mesma direção nunca se encontram**

---

## Exemplos

**Exemplo 1**
```
Input:  [5, 10, -5]
Output: [5, 10]
```
O `10` e o `-5` colidem → `10` sobrevive. O `5` e o `10` nunca se encontram.

---

**Exemplo 2**
```
Input:  [8, -8]
Output: []
```
O `8` e o `-8` colidem → ambos explodem.

---

**Exemplo 3**
```
Input:  [10, 2, -5]
Output: [10]
```
O `2` e o `-5` colidem → `-5` sobrevive. Depois `-5` e `10` colidem → `10` sobrevive.

---

**Exemplo 4**
```
Input:  [3, 5, -6, 2, -1, 4]
Output: [-6, 2, 4]
```
O `-6` destrói o `3` e o `5` e continua para a esquerda. O `2` destrói o `-1` e continua para a direita sem alcançar o `4`.

---

## Restrições

- `2 <= asteroids.length <= 10⁴`
- `-1000 <= asteroids[i] <= 1000`
- `asteroids[i] != 0`

---

## Solução explicada (pt-br)

A ideia é simular os asteroides usando uma **pilha** — mas em vez de criar uma pilha separada na memória, reutilizamos o próprio array de entrada como pilha, usando um índice `top` para controlar o topo.

### Passo a passo

```
Percorremos cada asteroide do array:

  ┌─────────────────────────────────────────────────────┐
  │  O asteroide atual vai para a ESQUERDA (< 0)        │
  │  E o topo da pilha vai para a DIREITA (> 0)?        │
  │                                                     │
  │  SIM → colisão! Compare os tamanhos:                │
  │    topo menor  → topo explode, continua verificando │
  │    topo igual  → ambos explodem                     │
  │    topo maior  → asteroide atual explode            │
  │                                                     │
  │  NÃO → sem colisão, empilha o asteroide             │
  └─────────────────────────────────────────────────────┘
```

### Exemplo visual — `[5, 10, -5]`

```
Passo 1: asteroide =  5  → pilha vazia, empilha   → pilha: [5]
Passo 2: asteroide = 10  → positivo, empilha       → pilha: [5, 10]
Passo 3: asteroide = -5  → colisão com 10!
           10 > 5 → -5 explode, 10 sobrevive       → pilha: [5, 10]

Resultado: [5, 10] ✅
```

### Por que reutilizar o próprio array?

Quando usamos `Stack<int>`, o C# aloca memória extra na heap. Com o array in-place:
- O índice `top` substitui o topo da pilha
- Escrevemos direto no array existente
- No final, retornamos apenas o trecho válido com `asteroids[..(top + 1)]`

---

## Complexidade

| | |
|---|---|
| **Tempo** | O(n) — cada asteroide é empilhado e desempilhado no máximo uma vez |
| **Espaço** | O(1) extra — sem alocações adicionais, reutiliza o array de entrada |
