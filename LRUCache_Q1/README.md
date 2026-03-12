# 146. LRU Cache

## Descrição do Problema

Projete uma estrutura de dados que siga as restrições de um cache **LRU (Least Recently Used — Menos Recentemente Utilizado)**.

🔗 [Wikipedia — LRU Cache](https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU)

Implemente a classe `LRUCache`:

| Método | Descrição |
|---|---|
| `LRUCache(int capacity)` | Inicializa o cache com capacidade máxima positiva. |
| `int Get(int key)` | Retorna o valor da chave se ela existir; caso contrário, retorna **-1**. |
| `void Put(int key, int value)` | Insere ou atualiza o par chave-valor. Se a capacidade for excedida, **remove o item menos recentemente utilizado**. |

> ⚠️ `Get` e `Put` devem ter complexidade de tempo **O(1)** em média.

---

## Exemplo

```
Entrada:
["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
[[2], [1,1], [2,2], [1], [3,3], [2], [4,4], [1], [3], [4]]

Saída:
[null, null, null, 1, null, -1, null, -1, 3, 4]
```

### Passo a passo

```
LRUCache(2)     → capacidade = 2
put(1, 1)       → cache: {1=1}
put(2, 2)       → cache: {1=1, 2=2}
get(1)          → retorna 1      | cache: {2=2, 1=1}  (1 vira o mais recente)
put(3, 3)       → LRU é 2, remove 2 | cache: {1=1, 3=3}
get(2)          → retorna -1     | (2 foi removido)
put(4, 4)       → LRU é 1, remove 1 | cache: {3=3, 4=4}
get(1)          → retorna -1     | (1 foi removido)
get(3)          → retorna 3
get(4)          → retorna 4
```

---

## Restrições

- `1 <= capacity <= 3000`
- `0 <= key <= 10⁴`
- `0 <= value <= 10⁵`
- No máximo `2 × 10⁵` chamadas a `Get` e `Put`.

---

## Solução

### Estratégia: HashMap + Lista Duplamente Encadeada

A solução combina duas estruturas de dados para garantir **O(1)** em todas as operações:

| Estrutura | Papel |
|---|---|
| `Dictionary<int, DLinkedNode>` | Acesso direto O(1) ao nó pela chave |
| Lista duplamente encadeada | Mantém a ordem de uso (mais recente → menos recente) |

### Como funciona

```
HEAD ↔ [mais recente] ↔ ... ↔ [menos recente] ↔ TAIL
  (MRU)                                           (LRU)
```

- **HEAD** e **TAIL** são nós sentinelas (não armazenam dados), eliminando verificações de `null`.
- Itens mais recentemente usados ficam próximos ao `HEAD`.
- O candidato a remoção (LRU) é sempre o nó imediatamente antes do `TAIL`.

### Operações

#### `Get(key)`
1. Busca o nó no `Dictionary` → O(1).
2. Move o nó para a cabeça da lista (marca como mais recente) → O(1).
3. Retorna o valor, ou `-1` se não existir.

#### `Put(key, value)`
- **Chave já existe:** atualiza o valor e move para a cabeça → O(1).
- **Chave nova:**
  1. Cria um novo nó e insere na cabeça → O(1).
  2. Adiciona ao `Dictionary` → O(1).
  3. Se `Count > capacity`, remove o nó da cauda (LRU) e apaga do `Dictionary` → O(1).

### Complexidade

| | Tempo | Espaço |
|---|---|---|
| `Get` | O(1) | — |
| `Put` | O(1) | — |
| **Total** | **O(1)** | **O(capacity)** |

---

## Por que não usar `OrderedDictionary` ou `LinkedList<T>` do C#?

- `LinkedList<T>` + `Dictionary` funcionaria, mas exigiria guardar `LinkedListNode<T>` no dicionário — essa solução faz o mesmo, porém com um nó customizado mais enxuto e sem overhead de boxing.
- `OrderedDictionary` não garante O(1) na remoção por posição.
- A implementação manual da lista duplamente encadeada com nós sentinelas é a abordagem clássica e mais eficiente para este problema.
