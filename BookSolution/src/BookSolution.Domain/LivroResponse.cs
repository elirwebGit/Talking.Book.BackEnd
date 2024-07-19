using System.ComponentModel.DataAnnotations;

namespace BookSolution.Domain
{
    public class LivroResponse
    {
        public int Codigo { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public DateTime Lancamento { get; set; }
        public string? Descricao { get; set; }
      
    }
}
