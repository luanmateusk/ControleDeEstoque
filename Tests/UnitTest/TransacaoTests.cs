using Domain.Models;
using NUnit.Framework;

namespace UnitTest
{
    public class TransacaoTests
    {
        private Estoque _estoque;

        [SetUp]
        public void Setup()
        {
            _estoque = new Estoque();
            var produto = new Produto("Produto Teste", "Descrição Produto Teste")
            {
                Id = 1,
                Quantidade = 10,
                QuantidadeMinima = 5,
                Preco = 100.0m
            };
            _estoque.AdicionarProduto(produto);
        }

        [Test]
        public void Deve_Adicionar_Produto_Ao_Estoque_Com_Transacao_Entrada()
        {
            // Arrange
            var transacao = new Transacao(1, 5, TipoTransacao.Entrada);

            // Act
            var resultado = _estoque.ProcessarTransacao(transacao);

            // Assert
            Assert.That(resultado, Is.True);
            var produto = _estoque.ListarProdutos().Find(p => p.Id == 1);
            Assert.That(produto!.Quantidade, Is.EqualTo(15));  // 10 + 5 = 15
        }

[Test]
public void Deve_Remover_Produto_Do_Estoque_Com_Transacao_Saida()
{
    // Arrange
    var transacao = new Transacao(1, 3, TipoTransacao.Saida);

    // Act
    var resultado = _estoque.ProcessarTransacao(transacao);

    // Assert
    Assert.That(resultado, Is.True);
    var produto = _estoque.ListarProdutos().Find(p => p.Id == 1);
    Assert.NotNull(produto);  // Adiciona verificação nula aqui
    Assert.That(produto!.Quantidade, Is.EqualTo(7));  // Usa o operador '!' para desreferenciar de forma segura
}

        [Test]
        public void Nao_Deve_Realizar_Transacao_Saida_Se_Estoque_Insuficiente()
        {
            // Arrange
            var transacao = new Transacao(1, 20, TipoTransacao.Saida);  // Tentando remover mais do que o estoque

            // Act
            var resultado = _estoque.ProcessarTransacao(transacao);

            // Assert
            Assert.That(resultado, Is.False);  // Transação não deve ser realizada
            var produto = _estoque.ListarProdutos().Find(p => p.Id == 1);
            Assert.That(produto!.Quantidade, Is.EqualTo(10));  // Quantidade deve permanecer a mesma
        }

        [Test]
        public void Deve_Registrar_Transacao_No_Historico()
        {
            // Arrange
            var transacao = new Transacao(1, 5, TipoTransacao.Entrada);

            // Act
            _estoque.ProcessarTransacao(transacao);
            var transacoes = _estoque.ListarTransacoes();

            // Assert
            Assert.That(transacoes.Count, Is.EqualTo(1));
            Assert.That(transacoes[0].ProdutoId, Is.EqualTo(1));
            Assert.That(transacoes[0].Quantidade, Is.EqualTo(5));
            Assert.That(transacoes[0].Tipo, Is.EqualTo(TipoTransacao.Entrada));
        }
    }
}
