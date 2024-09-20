using System;

namespace Domain.Models
{
    // Enum para definir se a transação é de entrada ou saída
    public enum TipoTransacao
    {
        Entrada,
        Saida
    }

    public class Transacao
    {
        public int ProdutoId { get; set; }       // ID do produto que está sendo movimentado
        public int Quantidade { get; set; }      // Quantidade movimentada
        public TipoTransacao Tipo { get; set; }  // Tipo da transação (Entrada ou Saída)
        public DateTime DataTransacao { get; set; }  // Data e hora da transação

        // Construtor que inicializa os atributos da transação
        public Transacao(int produtoId, int quantidade, TipoTransacao tipo)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            Tipo = tipo;
            DataTransacao = DateTime.Now;  // A data da transação é definida no momento da criação
        }
    }
}
