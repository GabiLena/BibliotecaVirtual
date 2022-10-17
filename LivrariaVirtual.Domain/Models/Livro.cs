using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtual.Domain.Models
{
    public class Livro 
    {
        public string Titulo { get; set; }
        public string Volume { get; set; }
        public string Autor { get; set; }
        public decimal Valor { get; set; }
        public GeneroDoLivro Genero { get; set; }
    }
}
