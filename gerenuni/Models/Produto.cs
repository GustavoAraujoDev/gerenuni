namespace gerenuni.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
    }
}
