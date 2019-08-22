using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LivrariaHBSIS.Application.WebApi.AppModels;
using LivrariaHBSIS.Domain.Entities;
using LivrariaHBSIS.Domain.Interfaces.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaHBSIS.Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly ILivroDomainService _livroDomainService;
        private readonly ICategoriaDomainService _categoriaDomainService;
        private readonly IMapper _mapper;

        public LivrariaController(ILivroDomainService livroDomainService, ICategoriaDomainService categoriaDomainService, IMapper mapper)
        {
            _livroDomainService = livroDomainService;
            _categoriaDomainService = categoriaDomainService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LivroAppModel>> ListarTodosOsLivrosEmOrdemAscendente()
        {
            var listaEntidades =_livroDomainService.ObterTodosOsLivros()
                .OrderBy(entidade => entidade.NomeLivro)
                .Select(entidade => entidade);

            var listaAppModels = _mapper.Map<IEnumerable<LivroAppModel>>(listaEntidades);

            return new JsonResult(listaAppModels);
        }

        [HttpPost("CadastrarLivro")]
        public ActionResult<LivroAppModel> CadastrarLivro(LivroAppModel livro)
        {
            var livroEntidade = _mapper.Map<Livro>(livro);
            _livroDomainService.CadastrarLivro(livroEntidade);

            var livroAppModel = _mapper.Map<LivroAppModel>(livroEntidade);

            return new JsonResult(livroAppModel);
        }

        [HttpPost("AlterarLivro")]
        public ActionResult<LivroAppModel> AlterarLivro(LivroAppModel livro)
        {
            var livroEntidade = _mapper.Map<Livro>(livro);
            _livroDomainService.AlterarLivro(livroEntidade);

            var livroAppModel = _mapper.Map<LivroAppModel>(livroEntidade);

            return new JsonResult(livroAppModel);
        }

        [HttpDelete("RemoverLivro/{id}")]
        public ActionResult<string> RemoverLivro(int id)
        {
            _livroDomainService.RemoverLivro(id);

            return "Livro apagado com sucesso!";
        }

        [HttpGet("ObterLivro")]
        public ActionResult<LivroAppModel> ObterLivro(int livroId)
        {
            var livroEntidade = _livroDomainService.ObterLivroPorId(livroId);
            var livroAppModel = _mapper.Map<LivroAppModel>(livroEntidade);
            return new JsonResult(livroAppModel);
        }

        [HttpGet("ObterLivrosPorCategoria/{categoriaId}")]
        public ActionResult<IEnumerable<LivroAppModel>> ObterLivrosPorCategoria(int categoriaId)
        {
            var listaEntidades = _livroDomainService.ObterLivrosPorCategoria(categoriaId)
                .OrderBy(entidade => entidade.NomeLivro)
                .Select(entidade => entidade);

            var listaAppModels = _mapper.Map<IEnumerable<LivroAppModel>>(listaEntidades);

            return new JsonResult(listaAppModels);
        }

        [HttpGet("ObterTodasAsCategorias")]
        public ActionResult<IEnumerable<CategoriaAppModel>> ObterTodasAsCategorias()
        {
            var listaEntidades = _categoriaDomainService.ObterTodasAsCategorias()
                .OrderBy(entidade => entidade.CategoriaId)
                .Select(entidade => entidade);

            var listaAppModels = _mapper.Map<IEnumerable<CategoriaAppModel>>(listaEntidades);

            return new JsonResult(listaAppModels);
        }

    }
}