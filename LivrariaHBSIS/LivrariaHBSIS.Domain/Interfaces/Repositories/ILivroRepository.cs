using LivrariaHBSIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivrariaHBSIS.Domain.Interfaces.Repositories
{
    public interface ILivroRepository : IBaseRepository<Livro>
    {
        IQueryable<Livro> ObterTodosOsLivros();
    }
}
