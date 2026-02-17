# 1732. Encontrar a Maior Altitude

**Dificuldade:** Fácil

## 📝 Descrição do Problema

Um ciclista está fazendo uma viagem que passa por vários pontos com diferentes altitudes. Ele começa sua jornada no ponto 0 com altitude igual a 0.

Você recebe um array de inteiros `gain` onde `gain[i]` representa o **ganho ou perda de altitude** entre os pontos `i` e `i + 1`. 

Sua tarefa é retornar a **maior altitude** alcançada durante toda a viagem.

## 💡 Exemplos

**Exemplo 1:**
```
Entrada: gain = [-5,1,5,0,-7]
Saída: 1
Explicação: As altitudes são [0,-5,-4,1,1,-6]. A maior é 1.
```

**Exemplo 2:**
```
Entrada: gain = [-4,-3,-2,-1,4,3,2]
Saída: 0
Explicação: As altitudes são [0,-4,-7,-9,-10,-6,-3,-1]. A maior é 0.
```

## 🎯 Como o Problema Foi Resolvido

### Estratégia
A solução utiliza uma abordagem simples e eficiente:

1. **Inicialização**: Começamos com duas variáveis:
   - `highest = 0`: armazena a maior altitude encontrada (iniciamos em 0 pois essa é a altitude inicial)
   - `current = 0`: mantém a altitude atual durante a iteração

2. **Iteração**: Percorremos o array `gain` uma única vez:
   - A cada passo, calculamos a altitude atual: `current = gain[i] + current`
   - Verificamos se a altitude atual é maior que a maior altitude registrada
   - Se for maior, atualizamos `highest`

3. **Retorno**: Ao final, retornamos `highest` que contém a maior altitude alcançada

### Complexidade
- **Tempo:** O(n) - percorremos o array apenas uma vez
- **Espaço:** O(1) - usamos apenas duas variáveis auxiliares

### Por que funciona?
Em vez de criar um array com todas as altitudes, calculamos cada altitude dinamicamente e mantemos apenas o registro da maior. Isso economiza memória e mantém o código simples e eficiente.

## 🔧 Restrições

- `n == gain.length`
- `1 <= n <= 100`
- `-100 <= gain[i] <= 100`
