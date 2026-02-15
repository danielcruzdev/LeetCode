**Q2. Embaralhar o Array (Shuffle the Array)**

Dado um array `nums` composto por `2n` elementos na forma `[x1, x2, ..., xn, y1, y2, ..., yn]`, retorne o array reorganizado na forma `[x1, y1, x2, y2, ..., xn, yn]`.

**Exemplos**

- Entrada: `nums = [2,5,1,3,4,7]`, `n = 3`
	- Saída: `[2,3,5,4,1,7]`
	- Explicação: `x1=2, x2=5, x3=1, y1=3, y2=4, y3=7` → `[2,3,5,4,1,7]`

- Entrada: `nums = [1,2,3,4,4,3,2,1]`, `n = 4`
	- Saída: `[1,4,2,3,3,2,4,1]`

- Entrada: `nums = [1,1,2,2]`, `n = 2`
	- Saída: `[1,2,1,2]`

**Restrições**

- `1 <= n <= 500`
- `nums.length == 2 * n`
- `1 <= nums[i] <= 10^3`

**Como resolver (explicação)**

A ideia mais direta e clara é construir um novo array de tamanho `2 * n` e preencher as posições alternadas com os elementos de `x` e `y`:

- Para cada `i` de `0` até `n-1`:
	- coloque `nums[i]` na posição `2*i` do resultado (isto é `x_i`)
	- coloque `nums[i + n]` na posição `2*i + 1` do resultado (isto é `y_i`)

Isso produz exatamente a sequência `[x1, y1, x2, y2, ..., xn, yn]`.

**Algoritmo passo a passo**

1. Crie um array `result` com tamanho `2 * n`.
2. Para `i` de `0` até `n - 1`:
	 - `result[2 * i] = nums[i]`
	 - `result[2 * i + 1] = nums[i + n]`
3. Retorne `result`.

**Exemplo ilustrado**

Para `nums = [2,5,1,3,4,7]` e `n = 3`:

- `i = 0` → `result[0] = nums[0] = 2`, `result[1] = nums[3] = 3` → `[2,3,_,_,_,_]`
- `i = 1` → `result[2] = nums[1] = 5`, `result[3] = nums[4] = 4` → `[2,3,5,4,_,_]`
- `i = 2` → `result[4] = nums[2] = 1`, `result[5] = nums[5] = 7` → `[2,3,5,4,1,7]`

**Complexidade**

- Tempo: O(n) — percorremos os `n` pares uma vez.
- Espaço: O(n) — usamos um array adicional de tamanho `2n` (portanto O(n)).

**Exemplo de implementação em C#**

```csharp
public static int[] Shuffle(int[] nums, int n)
{
		int[] result = new int[2 * n];
		for (int i = 0; i < n; i++)
		{
				result[2 * i] = nums[i];
				result[2 * i + 1] = nums[i + n];
		}
		return result;
}
```

Esta implementação é simples, clara e passa nas restrições do problema. Se desejar, há soluções que fazem a transformação in-place usando manipulação de bits ou codificação de pares dentro de inteiros, mas para a maioria das aplicações a versão com array auxiliar é mais legível e suficiente.