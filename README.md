
# Sistema de Controle de Estoque

Este é um projeto de um **Sistema de Controle de Estoque** desenvolvido para a disciplina de **Teste de Software**. O sistema foi implementado utilizando **C#**, **.NET Core**, **NUnit** e **FluentValidation**, seguindo o ciclo de **Desenvolvimento Orientado a Testes (TDD)**. 

O projeto inclui funcionalidades de cadastro de produtos, controle de estoque (entrada e saída de itens), notificações de estoque baixo e geração de relatórios de transações realizadas.

## Funcionalidades Principais

1. **Cadastro de Produtos**
   - Adição de novos produtos ao estoque.
   - Atualização e remoção de produtos existentes.

2. **Controle de Estoque**
   - Processamento de transações de entrada e saída de produtos.
   - Validação de estoque disponível antes da retirada de itens.

3. **Notificação de Estoque Baixo**
   - Verificação e listagem de produtos cujo estoque está abaixo do limite mínimo definido.

4. **Histórico de Transações**
   - Registro e consulta de todas as transações (entrada e saída) realizadas.

## Tecnologias Utilizadas

- **C#**
- **.NET Core**
- **NUnit** (para testes unitários e de integração)
- **FluentValidation** (para validação de dados)
  
## Estrutura do Projeto

O projeto está organizado nas seguintes pastas:

```
/ControleDeEstoque
    ├── Domain
    │   ├── Models
    │   │   ├── Produto.cs
    │   │   ├── Estoque.cs
    │   │   └── Transacao.cs
    ├── Tests
    │   ├── UnitTest
    │   │   ├── ProdutoTests.cs
    │   │   ├── EstoqueTests.cs
    │   │   └── TransacaoTests.cs
```

## Como Executar o Projeto

1. **Clonar o repositório**:
   ```bash
   git clone https://github.com/seu_usuario/sistema-controle-estoque.git
   ```

2. **Navegar até o diretório do projeto**:
   ```bash
   cd ControleDeEstoque
   ```

3. **Restaurar os pacotes**:
   ```bash
   dotnet restore
   ```

4. **Compilar o projeto**:
   ```bash
   dotnet build
   ```

5. **Executar os testes**:
   ```bash
   dotnet test
   ```

## Plano de Testes

O projeto foi desenvolvido utilizando o ciclo de TDD (Test-Driven Development). Todos os componentes principais foram cobertos por testes unitários e de integração.

- **Testes Unitários**:
  - Garantem que cada funcionalidade individual funcione corretamente.
  - Exemplo: Verificação de cadastro de produtos, processamento de transações de estoque.

- **Testes de Integração**:
  - Validam a interação entre diferentes componentes do sistema.
  - Exemplo: Processamento de transações de entrada e saída de produtos.

## Autor

- **Luan Mateus Kusma**
