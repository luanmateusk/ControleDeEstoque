namespace Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public decimal Preco { get; set; }

        // Adicionando o construtor que aceita nome e descricao
        public Produto(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
