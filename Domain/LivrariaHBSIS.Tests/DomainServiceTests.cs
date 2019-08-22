using LivrariaHBSIS.Domain.Entities;
using LivrariaHBSIS.Domain.Interfaces.DomainServices;
using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using LivrariaHBSIS.Domain.Interfaces.Repositories;
using LivrariaHBSIS.Domain.Services;
using LivrariaHBSIS.Infra.Data.Configuration;
using LivrariaHBSIS.Infra.Data.Context;
using LivrariaHBSIS.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LivrariaHBSIS.Tests
{
    public class DomainServiceTests
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ContextoAplicacao _context;
        protected readonly ILivroRepository _livroRepository;
        protected readonly ICategoriaRepository _categoriaRepository;
        protected readonly ILivroDomainService _livroDomainService;
        protected readonly ICategoriaDomainService _categoriaDomainService;

        public DomainServiceTests()
        {
            _context = new ContextoAplicacao("Server=localhost\\sqlexpress;Database=LivrariaHBSIS;Trusted_Connection=True;");
            _unitOfWork = new UnitOfWork(_context);
            _livroRepository = new LivroRepository(_context);
            _categoriaRepository = new CategoriaRepository(_context);
            _livroDomainService = new LivroDomainService(_livroRepository, _unitOfWork);
            _categoriaDomainService = new CategoriaDomainService(_categoriaRepository, _unitOfWork);
        }

        [Fact]
        public void LivroDomainService_CadastrarLivroEObterLivroPorIdEAlterarLivroERemoverLivro()
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
                ISBN = 201902
            };

            _livroDomainService.CadastrarLivro(livroTeste);

            var livroInserido = _livroDomainService.ObterLivroPorId(livroTeste.LivroId);

            if (livroInserido == null)
                Assert.NotNull(livroInserido);

            livroInserido.NomeLivro = "NOME ALTERADO";

            _livroDomainService.AlterarLivro(livroInserido);

            var livroAlterado = _livroDomainService.ObterLivroPorId(livroTeste.LivroId);

            Assert.Equal("NOME ALTERADO", livroAlterado.NomeLivro);

            _livroDomainService.RemoverLivro(livroAlterado);
        }

        [Fact]
        public void LivroDomainService_CadastrarLivroEObterTodosOsLivrosERemoverLivro()
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
                ISBN = 201902
            };

            _livroDomainService.CadastrarLivro(livroTeste);

            var livroInserido = _livroDomainService.ObterLivroPorId(livroTeste.LivroId);

            if (livroInserido == null)
                Assert.NotNull(livroInserido);

            var todosOsLivros = _livroDomainService.ObterTodosOsLivros();

            Assert.True(todosOsLivros != null && todosOsLivros.Any());

            _livroDomainService.RemoverLivro(livroInserido);
        }

        [Fact]
        public void LivroDomainService_CadastrarLivroEOObterLivrosPorCategoriaERemoverLivro()
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
                ISBN = 201902
            };

            _livroDomainService.CadastrarLivro(livroTeste);

            var livroInserido = _livroDomainService.ObterLivroPorId(livroTeste.LivroId);

            if (livroInserido == null)
                Assert.NotNull(livroInserido);

            var todosOsLivrosCategoria1 = _livroDomainService.ObterLivrosPorCategoria(1);

            Assert.True(todosOsLivrosCategoria1 != null && todosOsLivrosCategoria1.Any());

            _livroDomainService.RemoverLivro(livroInserido);
        }

        [Fact]
        public void CategoriaDomainService_ObterTodasAsCategorias()
        {
            var todasAsCategorias = _categoriaDomainService.ObterTodasAsCategorias();

            Assert.True(todasAsCategorias != null && todasAsCategorias.Any());
        }
    }
}
