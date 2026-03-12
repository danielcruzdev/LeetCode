namespace LRUCache_Q1;

class Program
{
    static void Main(string[] args)
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(1, 1); // cache é {1=1}
        lRUCache.Put(2, 2); // cache é {1=1, 2=2}
        Console.WriteLine(lRUCache.Get(1)); // retorna 1
        lRUCache.Put(3, 3); // LRU era 2, remove 2, cache é {1=1, 3=3}
        Console.WriteLine(lRUCache.Get(2)); // retorna -1 (não encontrado)
        lRUCache.Put(4, 4); // LRU era 1, remove 1, cache é {4=4, 3=3}
        Console.WriteLine(lRUCache.Get(1)); // retorna -1 (não encontrado)
        Console.WriteLine(lRUCache.Get(3)); // retorna 3
        Console.WriteLine(lRUCache.Get(4)); // retorna 4
    }
}

/// <summary>
/// Nó da lista duplamente encadeada.
/// </summary>
public class DLinkedNode
{
    public int Key;
    public int Value;
    public DLinkedNode? Prev;
    public DLinkedNode? Next;
}

/// <summary>
/// Implementação do LRU Cache usando HashMap + Lista Duplamente Encadeada.
/// - HashMap: acesso O(1) ao nó pelo key.
/// - Lista encadeada: mantém a ordem de uso (mais recente na cabeça, menos recente na cauda).
/// </summary>
public class LRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, DLinkedNode> _cache;

    // Sentinelas: evitam checar null nas extremidades
    private readonly DLinkedNode _head; // mais recentemente usado (MRU)
    private readonly DLinkedNode _tail; // menos recentemente usado (LRU)

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, DLinkedNode>(capacity);

        _head = new DLinkedNode();
        _tail = new DLinkedNode();
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    /// <summary>
    /// Retorna o valor da chave se existir; caso contrário, -1.
    /// Marca o item como recentemente usado.
    /// </summary>
    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out DLinkedNode? node))
            return -1;

        MoveToHead(node);
        return node.Value;
    }

    /// <summary>
    /// Insere ou atualiza a chave. Se a capacidade for excedida, remove o LRU.
    /// </summary>
    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out DLinkedNode? node))
        {
            node.Value = value;
            MoveToHead(node);
        }
        else
        {
            DLinkedNode newNode = new DLinkedNode { Key = key, Value = value };
            _cache[key] = newNode;
            AddToHead(newNode);

            if (_cache.Count > _capacity)
            {
                DLinkedNode lru = RemoveTail();
                _cache.Remove(lru.Key);
            }
        }
    }

    // ── Helpers da lista encadeada ──────────────────────────────────────────

    private void AddToHead(DLinkedNode node)
    {
        node.Prev = _head;
        node.Next = _head.Next;
        _head.Next!.Prev = node;
        _head.Next = node;
    }

    private void RemoveNode(DLinkedNode node)
    {
        node.Prev!.Next = node.Next;
        node.Next!.Prev = node.Prev;
    }

    private void MoveToHead(DLinkedNode node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    private DLinkedNode RemoveTail()
    {
        DLinkedNode lru = _tail.Prev!;
        RemoveNode(lru);
        return lru;
    }
}
