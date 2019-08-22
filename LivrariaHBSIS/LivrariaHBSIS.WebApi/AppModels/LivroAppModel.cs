using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaHBSIS.Application.WebApi.AppModels
{
    [Serializable]
    public class LivroAppModel
    {
        public int LivroId { get; set; }
        public int ISBN { get; set; }
        public string NomeLivro { get; set; }
        public string NomeAutor { get; set; }
        public string Editora { get; set; }
        public int AnoLancamento { get; set; }
        public byte Edicao { get; set; }
        public string DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        public string DescricaoCategoria { get; set; }
    }
}
