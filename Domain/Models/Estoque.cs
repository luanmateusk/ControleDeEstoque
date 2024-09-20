using System.Collections.Generic;

namespace Domain.Models
{
    public class Estoque
    {
        private List<Produto> _produtos = new List<Produto>();  // Lista de produtos no estoque
        private List<Transacao> _transacoes = new List<Transacao>();  // Lista de transações de entrada e saída

        // Método para adicionar um produto ao estoque
        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        

        // Método para remover um produto do estoque pelo ID
        public bool RemoverProduto(int produtoId)
        {
            var produto = _produtos.Find(p => p.Id == produtoId);
            if (produto != null)
            {
                _produtos.Remove(produto);
                return true;
            }
            return false;
        }

        // Método para atualizar um produto no estoque
        public bool AtualizarProduto(int produtoId, Produto produtoAtualizado)
        {
            var produto = _produtos.Find(p => p.Id == produtoId);
            if (produto != null)
            {
                produto.Nome = produtoAtualizado.Nome;
                produto.Descricao = produtoAtualizado.Descricao;
                produto.Quantidade = produtoAtualizado.Quantidade;
                produto.QuantidadeMinima = produtoAtualizado.QuantidadeMinima;
                produto.Preco = produtoAtualizado.Preco;
                return true;
            }
            return false;
        }

        // Método para processar uma transação de entrada ou saída
        public bool ProcessarTransacao(Transacao transacao)
        {
            var produto = _produtos.Find(p => p.Id == transacao.ProdutoId);
            if (produto == null) return false;  // Produto não encontrado

            if (transacao.Tipo == TipoTransacao.Entrada)
            {
                produto.Quantidade += transacao.Quantidade;  // Entrada: aumenta a quantidade
            }
            else if (transacao.Tipo == TipoTransacao.Saida)
            {
                if (produto.Quantidade < transacao.Quantidade) return false;  // Verifica se há estoque suficiente para a saída
                produto.Quantidade -= transacao.Quantidade;  // Saída: diminui a quantidade
            }

            _transacoes.Add(transacao);  // Registra a transação
            return true;
        }

        // Método para verificar produtos com estoque abaixo do mínimo
        public List<Produto> VerificarEstoqueBaixo()
        {
            return _produtos.FindAll(p => p.Quantidade < p.QuantidadeMinima);
        }

        // Método para listar todos os produtos no estoque
        public List<Produto> ListarProdutos()
        {
            return _produtos;
        }

        // Método para listar todas as transações realizadas
        public List<Transacao> ListarTransacoes()
        {
            return _transacoes;
        }
    }
}
