using LivrariaHBSIS.Domain.Entities;
using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using LivrariaHBSIS.Domain.Interfaces.Repositories;
using LivrariaHBSIS.Infra.Data.Configuration;
using LivrariaHBSIS.Infra.Data.Context;
using LivrariaHBSIS.Infra.Data.Repositories;
using System;
using System.Linq;
using Xunit;

namespace LivrariaHBSIS.Tests
{
    public class RepositoryTests
    {
        protected readonly ILivroRepository _livroRepository;
        protected readonly ICategoriaRepository _categoriaRepository;
        protected readonly ContextoAplicacao _context;
        protected readonly IUnitOfWork _unitOfWork;

        public RepositoryTests()
        {
            _context = new ContextoAplicacao("Server=localhost\\sqlexpress;Database=LivrariaHBSIS;Trusted_Connection=True;");
            _livroRepository = new LivroRepository(_context);
            _categoriaRepository = new CategoriaRepository(_context);
            _unitOfWork = new UnitOfWork(_context);
        }

        [Fact]
        public void LivroRepository_InsertEGetByIdEDelete()
        {
            var livroTeste = new Livro
            {
                NomeLivro = "LIVRO DO TESTE UNITÁRIO",
                NomeAutor = "AUTOR DO TESTE UNITÁRIO",
                AnoLancamento = 2019,
                CategoriaId = 1,
                DataCadastro = DateTime.Now,
                Edicao = 1,
                Editora = "EDITORA DO TESTE UNITÁRIO",
                ISBN = 201901
            };

            _livroRepository.Insert(livroTeste);
            _unitOfWork.Persist();

            var livroInserido = _livroRepository.GetById(livroTeste.LivroId);
            Assert.NotNull(livroInserido);

            _livroRepository.Delete(livroInserido);
        }

        [Fact]
        public void LivroRepository_InsertEObterTodosOsLivrosEDelete()
        {
            var livroTeste = new Livro
            {
                NomeLivro = "LIVRO DO TESTE UNITÁRIO",
                NomeAutor = "AUTOR DO TESTE UNITÁRIO",
                AnoLancamento = 2019,
                CategoriaId = 1,
                DataCadastro = DateTime.Now,
                Edicao = 1,
                Editora = "EDITORA DO TESTE UNITÁRIO",
                ISBN = 201901
            };

            _livroRepository.Insert(livroTeste);
            _unitOfWork.Persist();

            var todosOsLivros = _livroRepository.ObterTodosOsLivros().ToList();
            Assert.True(todosOsLivros != null && todosOsLivros.Any());

            _livroRepository.Delete(livroTeste);
        }

        [Fact]
        public void CategoriaRepository_InsertEGetAllEDelete()
        {
            var categoriaTeste = new Categoria
            {
                Descricao = "CATEGORIA TESTE UNITÁRIO"
            };

            _categoriaRepository.Insert(categoriaTeste);
            _unitOfWork.Persist();

            var todasAsCategorias = _categoriaRepository.GetAll().ToList();
            Assert.True(todasAsCategorias != null && todasAsCategorias.Any());

            _categoriaRepository.Delete(categoriaTeste);
        }
    }
}
