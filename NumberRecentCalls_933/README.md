# 933. Number of Recent Calls

## Problema

Implemente a classe `RecentCounter` que conta o número de requisições recentes dentro de uma janela de tempo de **3000 milissegundos**.

- `RecentCounter()` — inicializa o contador sem requisições.
- `int Ping(int t)` — adiciona uma requisição no tempo `t` e retorna quantas requisições ocorreram no intervalo **[t - 3000, t]**.

### Exemplo

```
Input:  ping(1), ping(100), ping(3001), ping(3002)
Output: 1, 2, 3, 3
```

---

## Solução

A ideia é usar uma **fila (Queue)** para guardar os tempos de cada ping.

### Passo a passo

1. Ao receber um novo `ping(t)`, adiciona `t` no final da fila.
2. Remove do início da fila todos os tempos que estão **fora** da janela de 3000ms, ou seja, menores que `t - 3000`.
3. O tamanho restante da fila é exatamente o número de requisições no intervalo válido.

### Por que funciona?

Como os valores de `t` chegam sempre em ordem crescente, os elementos mais antigos ficam sempre no **início** da fila. Basta removê-los até que todos os restantes estejam dentro da janela `[t - 3000, t]`.

### Complexidade

| | Complexidade |
|---|---|
| Tempo | O(n) amortizado por chamada |
| Espaço | O(n) — no máximo 3001 elementos na fila por vez |

---

## Código

```csharp
public class RecentCounter
{
    private Queue<int> _queue;

    public RecentCounter()
    {
        _queue = new Queue<int>();
    }

    public int Ping(int t)
    {
        _queue.Enqueue(t);

        while (_queue.Peek() < t - 3000)
            _queue.Dequeue();

        return _queue.Count;
    }
}
```
