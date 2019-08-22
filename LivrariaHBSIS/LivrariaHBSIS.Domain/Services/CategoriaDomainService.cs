using LivrariaHBSIS.Domain.Entities;
using LivrariaHBSIS.Domain.Interfaces.DomainServices;
using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using LivrariaHBSIS.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaHBSIS.Domain.Services
{
    public class CategoriaDomainService : BaseDomainService, ICategoriaDomainService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaDomainService(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<Categoria> ObterTodasAsCategorias() =>
            _categoriaRepository.GetAll();
    }
}
