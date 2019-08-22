using LivrariaHBSIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivrariaHBSIS.Domain.Interfaces.DomainServices
{
    public interface ILivroDomainService
    {
        void CadastrarLivro(Livro livro);
        void RemoverLivro(Livro livro);
        void RemoverLivro(int livroId);
        void AlterarLivro(Livro livro);
        Livro ObterLivroPorId(int id);
        IEnumerable<Livro> ObterTodosOsLivros();
        IEnumerable<Livro> ObterLivrosPorCategoria(int categoriaId);
    }
}
