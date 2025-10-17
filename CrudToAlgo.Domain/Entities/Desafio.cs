namespace CrudToAlgo.Domain.Entities
{
    public class Desafio
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Dificuldade { get; set; } = "Facil"; // Facil, Medio, Dificil
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        // Relacionamento
        public ICollection<CasoTeste> CasosTeste { get; set; } = new List<CasoTeste>();
    }
}
