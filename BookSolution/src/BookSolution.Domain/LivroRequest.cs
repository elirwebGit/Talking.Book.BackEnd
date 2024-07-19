using System;
using System.ComponentModel.DataAnnotations;

namespace BookSolution.Domain
{
    public class LivroRequest
    {
        public int Codigo { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public DateTime Lancamento { get; set; }
        public string? Descricao { get; set; }
        [Required]
        public string TipoLivro { get; set; }
        [Required]
        public Tag Tag { get; set; }
        public TipoEncadernacao? TipoEncadernacao { get; set; }
    }

    public class Tag { 
        public string? Descricao { get; set; }
        
    }

    public class TipoEncadernacao {
        public string? Nome { get; set; }
        public string? DescricaoEncardenação {get;set;}
        public string? Formato { get; set; }
    }





}