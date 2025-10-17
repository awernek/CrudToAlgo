namespace CrudToAlgo.Domain.Entities
{
    public class CasoTeste
    {
        public int Id { get; set; }
        public int DesafioId { get; set; }
        public Desafio Desafio { get; set; } = null!;
        public string Entrada { get; set; } = null!;   // JSON/text
        public string SaidaEsperada { get; set; } = null!;
        public bool Publico { get; set; } = false;     // casos privados vs públicos
    }
}
