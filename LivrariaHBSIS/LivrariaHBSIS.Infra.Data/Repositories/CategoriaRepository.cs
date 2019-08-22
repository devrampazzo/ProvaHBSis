using LivrariaHBSIS.Domain.Entities;
using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using LivrariaHBSIS.Domain.Interfaces.Repositories;
using LivrariaHBSIS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaHBSIS.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ContextoAplicacao context) :base(context) { }
    }
}
