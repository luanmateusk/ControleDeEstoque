using Domain.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{
    public class EstoqueTests
    {
        private Estoque _estoque;

        [SetUp]
        public void Setup()
        {
            _estoque = new Estoque();
        }

        [Test]
        public void Deve_Adicionar_Produto_No_Estoque()
        {
            // Arrange
            var produto = new Produto("Produto 1", "Descrição Produto 1")
            {
                Id = 1,
                Quantidade = 10,
                QuantidadeMinima = 5,
                Preco = 100.0m
            };

            // Act
            _estoque.AdicionarProduto(produto);

            // Assert
            var produtos = _estoque.ListarProdutos();
            Assert.That(produtos.Count, Is.EqualTo(1));
            Assert.That(produtos[0].Nome, Is.EqualTo("Produto 1"));
        }

        [Test]
        public void Deve_Remover_Produto_Do_Estoque_Por_Id()
        {
            // Arrange
            var produto = new Produto("Produto 1", "Descrição Produto 1")
            {
                Id = 1,
                Quantidade = 10,
                QuantidadeMinima = 5,
                Preco = 100.0m
            };
            _estoque.AdicionarProduto(produto);

            // Act
            var resultado = _estoque.RemoverProduto(1);

            // Assert
            Assert.That(resultado, Is.True);
            Assert.That(_estoque.ListarProdutos().Count, Is.EqualTo(0));
        }

        [Test]
        public void Deve_Atualizar_Produto_No_Estoque()
        {
            // Arrange
            var produto = new Produto("Produto 1", "Descrição Produto 1")
            {
                Id = 1,
                Quantidade = 10,
                QuantidadeMinima = 5,
                Preco = 100.0m
            };
            _estoque.AdicionarProduto(produto);

            var produtoAtualizado = new Produto("Produto 1 Atualizado", "Descrição Atualizada")
            {
                Quantidade = 15,
                QuantidadeMinima = 5,
                Preco = 120.0m
            };

            // Act
            var resultado = _estoque.AtualizarProduto(1, produtoAtualizado);

            // Assert
            Assert.That(resultado, Is.True);
            var produtoNoEstoque = _estoque.ListarProdutos()[0];
            Assert.That(produtoNoEstoque.Nome, Is.EqualTo("Produto 1 Atualizado"));
            Assert.That(produtoNoEstoque.Quantidade, Is.EqualTo(15));
        }

        [Test]
        public void Deve_Verificar_Produtos_Com_Estoque_Baixo()
        {
            // Arrange
            var produto = new Produto("Produto 1", "Descrição Produto 1")
            {
                Id = 1,
                Quantidade = 3,
                QuantidadeMinima = 5,
                Preco = 100.0m
            };
            _estoque.AdicionarProduto(produto);

            // Act
            var produtosComEstoqueBaixo = _estoque.VerificarEstoqueBaixo();

            // Assert
            Assert.That(produtosComEstoqueBaixo.Count, Is.EqualTo(1));
            Assert.That(produtosComEstoqueBaixo[0].Nome, Is.EqualTo("Produto 1"));
        }
    }
}
