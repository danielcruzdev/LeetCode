# Subsequência Tripla Crescente (Increasing Triplet Subsequence) - LeetCode 334

## Problema

Dado um array de inteiros `nums`, retorne `true` se existir um trio de índices (i, j, k) tal que i < j < k e nums[i] < nums[j] < nums[k]. Se não existir, retorne `false`.

## Exemplos

**Exemplo 1:**
```
Input: nums = [1,2,3,4,5]
Output: true
Explicação: Qualquer trio onde i < j < k é válido.
```

**Exemplo 2:**
```
Input: nums = [5,4,3,2,1]
Output: false
Explicação: Nenhum trio existe.
```

**Exemplo 3:**
```
Input: nums = [2,1,5,0,4,6]
Output: true
Explicação: Um dos trios válidos é (3, 4, 5), porque nums[3] == 0 < nums[4] == 4 < nums[5] == 6.
```

**Exemplo 4:**
```
Input: nums = [20,100,10,12,5,13]
Output: true
Explicação: O trio válido é nos índices (2, 3, 5), porque nums[2] == 10 < nums[3] == 12 < nums[5] == 13.
```

## Restrições

- 1 <= nums.length <= 5 * 10⁵
- -2³¹ <= nums[i] <= 2³¹ - 1

## Solução

### Abordagem: Rastreamento de Dois Menores Valores

**Complexidade:** O(n) tempo e O(1) espaço

### Explicação Simples

A ideia é muito inteligente! Em vez de procurar por três números consecutivos, vamos manter o controle de **dois números especiais** enquanto percorremos o array:

1. **`first`** → O menor número que encontramos até agora
2. **`second`** → O segundo menor número (mas que aparece DEPOIS do `first`)

**A lógica é:**
- Se encontrarmos um número **menor ou igual** ao `first`, atualizamos o `first`
- Se encontrarmos um número **maior que `first` mas menor ou igual ao `second`**, atualizamos o `second`
- Se encontrarmos um número **maior que ambos**, encontramos nosso trio! 🎉

### Por que funciona?

Quando atualizamos `first` e `second`, estamos sempre garantindo que:
- `first` < `second` (ordem dos valores)
- O índice de `first` < índice de `second` (ordem das posições)

Assim, quando encontramos um terceiro número maior que `second`, automaticamente temos três números em posições crescentes com valores crescentes!

### Exemplo passo a passo

Para `[20, 100, 10, 12, 5, 13]`:

```
i=0, num=20:  first=20, second=MAX
i=1, num=100: first=20, second=100
i=2, num=10:  first=10, second=100  (achamos um número menor que first!)
i=3, num=12:  first=10, second=12   (achamos um número entre first e second!)
i=4, num=5:   first=5,  second=12   (achamos um número menor que first!)
i=5, num=13:  13 > 12 → ENCONTRADO! ✓
```

O trio é: 10 < 12 < 13 (índices 2, 3, 5)

### Código

```csharp
private static bool IncreasingTriplet(int[] nums)
{
    var first = int.MaxValue;   // Menor valor encontrado
    var second = int.MaxValue;  // Segundo menor valor encontrado

    foreach (int num in nums)
    {
        if (num <= first)
        {
            first = num;  // Atualiza o menor
        }
        else if (num <= second)
        {
            second = num;  // Atualiza o segundo menor
        }
        else
        {
            return true;  // Encontrou um número maior que ambos!
        }
    }
    
    return false;  // Não encontrou trio crescente
}
```

### Por que essa solução é melhor?

- ✅ **Eficiente:** Passa pelo array apenas uma vez - O(n)
- ✅ **Econômica:** Usa apenas 2 variáveis - O(1) de espaço
- ✅ **Simples:** Lógica fácil de entender e implementar
- ✅ **Correta:** Funciona para todos os casos, não só números consecutivos!
