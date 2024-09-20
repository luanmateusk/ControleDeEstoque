using Domain.Models;
using NUnit.Framework;

namespace UnitTest
{
    public class ProdutoTests
    {
        [Test]
        public void Deve_Criar_Produto_Com_Propriedades_Corretas()
        {
            var produto = new Produto("Produto Teste", "Descrição do Produto Teste")  // Adicionando os parâmetros obrigatórios
            {
                Id = 1,
                Quantidade = 10,
                QuantidadeMinima = 5,
                Preco = 100.0m
            };

            // Assert usando Assert.That
            Assert.That(produto.Id, Is.EqualTo(1));
            Assert.That(produto.Nome, Is.EqualTo("Produto Teste"));
            Assert.That(produto.Descricao, Is.EqualTo("Descrição do Produto Teste"));
            Assert.That(produto.Quantidade, Is.EqualTo(10));
            Assert.That(produto.QuantidadeMinima, Is.EqualTo(5));
            Assert.That(produto.Preco, Is.EqualTo(100.0m));
        }
    }
}
