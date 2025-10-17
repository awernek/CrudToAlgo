namespace CrudToAlgo.Domain.Entities
{
    public class Submissao
    {
        public int Id { get; set; }
        public int DesafioId { get; set; }
        public int UsuarioId { get; set; }
        public string Linguagem { get; set; } = "csharp";
        public string Codigo { get; set; } = null!;
        public DateTime DataEnvio { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pendente"; // Pendente, Rodando, Aprovado, Rejeitado
        public int PontosGanho { get; set; } = 0;

        public Desafio Desafio { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
    }
}
