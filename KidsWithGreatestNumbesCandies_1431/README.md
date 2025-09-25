1431. Kids With the Greatest Number of Candies

## Descri��o

Dado um array de inteiros `candies`, onde cada elemento representa a quantidade de doces que cada crian�a possui, e um inteiro `extraCandies` representando doces extras dispon�veis, o objetivo � retornar um array booleano indicando se cada crian�a pode ter o maior n�mero de doces ao receber todos os doces extras.

## Como o problema foi resolvido

A solu��o percorre o array de doces e, para cada crian�a, soma os doces extras � sua quantidade atual. Em seguida, verifica se esse total � maior ou igual ao maior n�mero de doces que qualquer crian�a possui originalmente. Se for, marca `true` para essa crian�a; caso contr�rio, marca `false`.

### Passos da solu��o:
1. Encontrar o maior valor no array original de doces (`maxValue`).
2. Para cada crian�a, somar os doces extras � sua quantidade de doces.
3. Verificar se o novo total � maior ou igual ao `maxValue`.
4. Retornar um array de booleanos com o resultado para cada crian�a.

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

## Observa��o
O c�digo est� implementado em C# utilizando .NET 9, aproveitando recursos modernos da linguagem.