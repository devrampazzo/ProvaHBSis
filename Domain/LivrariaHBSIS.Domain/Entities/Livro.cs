using System;

namespace LivrariaHBSIS.Domain.Entities
{
    public partial class Livro
    {
        public Livro()
        {
            DataCadastro = DateTime.Now;
        }

        public int LivroId { get; set; }
        public int ISBN { get; set; }
        public string NomeLivro { get; set; }
        public string NomeAutor { get; set; }
        public string Editora { get; set; }
        public int AnoLancamento { get; set; }
        public byte Edicao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
