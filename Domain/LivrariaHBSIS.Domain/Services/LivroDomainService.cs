using LivrariaHBSIS.Domain.Entities;
using LivrariaHBSIS.Domain.Exceptions;
using LivrariaHBSIS.Domain.Interfaces.DomainServices;
using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using LivrariaHBSIS.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivrariaHBSIS.Domain.Services
{
    public class LivroDomainService : BaseDomainService, ILivroDomainService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroDomainService(ILivroRepository livroRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _livroRepository = livroRepository;
        }

        public void AlterarLivro(Livro livro)
        {
            try
            {
                _livroRepository.Update(livro);
                PersistTransaction();
            }
            catch (Exception ex)
            {
                throw new DomainException(ex);
            }
        }

        public void CadastrarLivro(Livro livro)
        {
            try
            {
                _livroRepository.Insert(livro);
                PersistTransaction();
            }
            catch (Exception ex)
            {
                throw new DomainException(ex);
            }
        }

        public void RemoverLivro(Livro livro)
        {
            try
            {
                _livroRepository.Delete(livro);
                PersistTransaction();
            }
            catch (Exception ex)
            {
                throw new DomainException(ex);
            }
        }

        public void RemoverLivro(int livroId)
        {
            try
            {
                _livroRepository.Delete(livroId);
                PersistTransaction();
            }
            catch (Exception ex)
            {
                throw new DomainException(ex);
            }
        }

        public Livro ObterLivroPorId(int id) =>
            _livroRepository.GetById(id);

        public IEnumerable<Livro> ObterLivrosPorCategoria(int categoriaId) =>
            _livroRepository.GetAll().Where(l => l.CategoriaId == categoriaId);

        public IEnumerable<Livro> ObterTodosOsLivros() =>
            _livroRepository.ObterTodosOsLivros();
    }
}
