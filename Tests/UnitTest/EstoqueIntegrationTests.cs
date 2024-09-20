using Domain.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{
    public class EstoqueIntegrationTests
    {
        private Estoque _estoque;

        [SetUp]
        public void Setup()
        {
            _estoque = new Estoque();
        }

        [Test]
        public void Deve_Processar_Entrada_De_Produto_E_Atualizar_Estoque()
        {
            // Arrange
            var produto = new Produto("Produto Integrado", "Descrição Integrada")
            {
                Id = 1,
                Quantidade = 10,
                QuantidadeMinima = 5,
                Preco = 50.0m
            };
            _estoque.AdicionarProduto(produto);
            var transacao = new Transacao(1, 5, TipoTransacao.Entrada);

            // Act
            var resultadoTransacao = _estoque.ProcessarTransacao(transacao);

            // Assert
            var produtoNoEstoque = _estoque.ListarProdutos().Find(p => p.Id == 1);
            Assert.That(resultadoTransacao, Is.True);
            Assert.That(produtoNoEstoque!.Quantidade, Is.EqualTo(15)); // 10 + 5
        }

        [Test]
        public void Deve_Processar_Saida_De_Produto_E_Atualizar_Estoque()
        {
            // Arrange
            var produto = new Produto("Produto Integrado", "Descrição Integrada")
            {
                Id = 1,
                Quantidade = 10,
                QuantidadeMinima = 5,
                Preco = 50.0m
            };
            _estoque.AdicionarProduto(produto);
            var transacao = new Transacao(1, 3, TipoTransacao.Saida);

            // Act
            var resultadoTransacao = _estoque.ProcessarTransacao(transacao);

            // Assert
            var produtoNoEstoque = _estoque.ListarProdutos().Find(p => p.Id == 1);
            Assert.That(resultadoTransacao, Is.True);
            Assert.That(produtoNoEstoque!.Quantidade, Is.EqualTo(7)); // 10 - 3
        }

        [Test]
        public void Nao_Deve_Processar_Transacao_Com_Estoque_Insuficiente()
        {
            // Arrange
            var produto = new Produto("Produto Integrado", "Descrição Integrada")
            {
                Id = 1,
                Quantidade = 5,
                QuantidadeMinima = 2,
                Preco = 50.0m
            };
            _estoque.AdicionarProduto(produto);
            var transacao = new Transacao(1, 10, TipoTransacao.Saida); // Saída maior que a quantidade em estoque

            // Act
            var resultadoTransacao = _estoque.ProcessarTransacao(transacao);

            // Assert
            var produtoNoEstoque = _estoque.ListarProdutos().Find(p => p.Id == 1);
            Assert.That(resultadoTransacao, Is.False); // A transação deve falhar
            Assert.That(produtoNoEstoque!.Quantidade, Is.EqualTo(5)); // A quantidade não deve mudar
        }

        [Test]
        public void Deve_Registrar_Multiplas_Transacoes()
        {
            // Arrange
            var produto = new Produto("Produto Integrado", "Descrição Integrada")
            {
                Id = 1,
                Quantidade = 10,
                QuantidadeMinima = 5,
                Preco = 50.0m
            };
            _estoque.AdicionarProduto(produto);

            var transacaoEntrada = new Transacao(1, 5, TipoTransacao.Entrada);
            var transacaoSaida = new Transacao(1, 3, TipoTransacao.Saida);

            // Act
            _estoque.ProcessarTransacao(transacaoEntrada);
            _estoque.ProcessarTransacao(transacaoSaida);
            var transacoes = _estoque.ListarTransacoes();

            // Assert
            Assert.That(transacoes.Count, Is.EqualTo(2));
            Assert.That(transacoes[0].Tipo, Is.EqualTo(TipoTransacao.Entrada));
            Assert.That(transacoes[1].Tipo, Is.EqualTo(TipoTransacao.Saida));
        }
    }
}
