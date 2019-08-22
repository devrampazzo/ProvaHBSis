using LivrariaHBSIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivrariaHBSIS.Domain.Interfaces.DomainServices
{
    public interface ICategoriaDomainService
    {
        IEnumerable<Categoria> ObterTodasAsCategorias();
    }
}
