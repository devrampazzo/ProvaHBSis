using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaHBSIS.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            Livros = new List<Livro>();
        }
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
