# Plano de Testes - Sistema de Controle de Estoque

## Objetivo
O objetivo deste plano de testes é garantir a qualidade e o funcionamento correto do Sistema de Controle de Estoque, utilizando a abordagem de Desenvolvimento Orientado a Testes (TDD). Os testes serão realizados para verificar tanto a funcionalidade de cada componente individual quanto a integração entre os componentes.

## Estrutura do Projeto
O sistema possui as seguintes classes e funcionalidades principais:
- **Produto**: Representa um item no estoque, contendo propriedades como `Id`, `Nome`, `Descricao`, `Quantidade`, `QuantidadeMinima`, e `Preco`.
- **Estoque**: Gerencia os produtos no estoque, permitindo adicionar, remover, atualizar produtos, e processar transações de entrada e saída de estoque.
- **Transacao**: Representa uma operação de entrada ou saída no estoque, afetando a quantidade de produtos disponíveis.

## Testes Unitários

### Classes e Métodos Testados
1. **Classe Produto**
   - Teste de criação de produto com propriedades corretas.

2. **Classe Estoque**
   - Adicionar produto ao estoque.
   - Remover produto pelo ID.
   - Atualizar informações de um produto existente.
   - Verificar produtos com estoque baixo.

3. **Classe Transacao**
   - Processamento de transação de entrada (adicionar ao estoque).
   - Processamento de transação de saída (remover do estoque).
   - Verificar se transações são registradas corretamente no histórico.

### Estratégia de Testes
- Os testes foram escritos para cobrir 100% das funcionalidades do sistema, garantindo que os principais cenários de uso estão contemplados.
- Foram realizados testes para garantir que os limites de quantidade mínima de produtos sejam respeitados.
- A implementação seguiu o ciclo TDD: escrever os testes, implementar o código e refatorar para melhorar a qualidade do código.

### Ferramentas Utilizadas
- **NUnit**: Framework para execução de testes.
- **FluentValidation**: Para validações adicionais.

## Testes de Integração
Os testes de integração foram implementados para garantir que o sistema funcione corretamente como um todo, verificando:
- A interação entre a classe `Estoque` e as transações realizadas.
- O registro de produtos e transações no histórico.
