using LivrariaHBSIS.Domain.Entities;
using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using LivrariaHBSIS.Domain.Interfaces.Repositories;
using LivrariaHBSIS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivrariaHBSIS.Infra.Data.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        public LivroRepository(ContextoAplicacao context) :base(context) { }

        public IQueryable<Livro> ObterTodosOsLivros()
        {
            return GetAll().Include(livro => livro.Categoria);
        }
    }
}
