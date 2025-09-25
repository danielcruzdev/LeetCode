1431. Kids With the Greatest Number of Candies

## Descrição

Dado um array de inteiros `candies`, onde cada elemento representa a quantidade de doces que cada criança possui, e um inteiro `extraCandies` representando doces extras disponíveis, o objetivo é retornar um array booleano indicando se cada criança pode ter o maior número de doces ao receber todos os doces extras.

## Como o problema foi resolvido

A solução percorre o array de doces e, para cada criança, soma os doces extras à sua quantidade atual. Em seguida, verifica se esse total é maior ou igual ao maior número de doces que qualquer criança possui originalmente. Se for, marca `true` para essa criança; caso contrário, marca `false`.

### Passos da solução:
1. Encontrar o maior valor no array original de doces (`maxValue`).
2. Para cada criança, somar os doces extras à sua quantidade de doces.
3. Verificar se o novo total é maior ou igual ao `maxValue`.
4. Retornar um array de booleanos com o resultado para cada criança.

### Exemplo de uso
```csharp
var candies = new int[] { 2, 3, 5, 1, 3 };
var extraCandies = 3;
var resultado = KidsWithCandies(candies, extraCandies);
// resultado: [true, true, true, false, true]
```

## Exemplos

- Input: candies = [2,3,5,1,3], extraCandies = 3
  Output: [true,true,true,false,true]
- Input: candies = [4,2,1,1,2], extraCandies = 1
  Output: [true,false,false,false,false]
- Input: candies = [12,1,12], extraCandies = 10
  Output: [true,false,true]

## Observação
O código está implementado em C# utilizando .NET 9, aproveitando recursos modernos da linguagem.