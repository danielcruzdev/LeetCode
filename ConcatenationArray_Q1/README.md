# Concatenação de Array (LeetCode #1929)

## Descrição do Problema

Dado um array de inteiros `nums` de tamanho `n`, você deve criar um array `ans` de tamanho `2n` onde `ans[i] == nums[i]` e `ans[i + n] == nums[i]` para `0 <= i < n` (indexado em 0).

Especificamente, `ans` é a concatenação de dois arrays `nums`.

Retorne o array `ans`.

## Exemplos

### Exemplo 1:
```
Input: nums = [1,2,1]
Output: [1,2,1,1,2,1]
Explicação: O array ans é formado da seguinte forma:
- ans = [nums[0],nums[1],nums[2],nums[0],nums[1],nums[2]]
- ans = [1,2,1,1,2,1]
```

### Exemplo 2:
```
Input: nums = [1,3,2,1]
Output: [1,3,2,1,1,3,2,1]
Explicação: O array ans é formado da seguinte forma:
- ans = [nums[0],nums[1],nums[2],nums[3],nums[0],nums[1],nums[2],nums[3]]
- ans = [1,3,2,1,1,3,2,1]
```

## Restrições

- `n == nums.length`
- `1 <= n <= 1000`
- `1 <= nums[i] <= 1000`

## Solução

### Abordagem

A solução utiliza um loop simples para concatenar o array consigo mesmo:

1. **Criação do array resultado**: Primeiro, criamos um novo array com tamanho `2n` (o dobro do array original)
2. **Iteração única**: Percorremos o array original apenas uma vez
3. **Preenchimento simultâneo**: Em cada iteração, preenchemos duas posições:
   - Posição `i`: copia o elemento atual (`nums[i]`)
   - Posição `i + n`: copia o mesmo elemento novamente (`nums[i]`)

### Complexidade

- **Tempo**: O(n) - percorremos o array uma única vez
- **Espaço**: O(n) - criamos um novo array de tamanho 2n (considerando apenas o espaço adicional, seria O(n))

### Código

```csharp
private static int[] GetConcatenation(int[] nums) 
{
    var n = nums.Length;
    var result = new int[2 * n];
    
    for (var i = 0; i < n; i++) 
    {
        result[i] = nums[i];
        result[i + n] = nums[i];
    }
    
    return result;
}
```

### Por que essa solução funciona?

A solução é eficiente porque:
- Evita a necessidade de dois loops separados
- Preenche ambas as metades do array resultado simultaneamente
- Utiliza apenas uma passagem pelos dados originais
- É simples e fácil de entender
