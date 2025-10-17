namespace CrudToAlgo.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        // Progressão e pontos
        public int Pontos { get; set; } = 0;
    }
}
