using Livraria.Domain.Commands.Inputs;
using Livraria.Domain.Handler;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Query;
using Livraria.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LivrariaApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repository;
        private readonly LivroHandler _handler;

        public LivroController(ILivroRepository repository, LivroHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/livro/{id}")]
        public LivroQueryResult ObterLivro(long id)
        {
            return _repository.Obter(id);
        }

        [HttpGet]
        [Route("v1/livro")]
        public List<LivroQueryResult> ListarLivros()
        {
            return _repository.Listar();
        }

        [HttpPost]
        [Route("v1/livro")]
        public ICommandResult Inserir([FromBody] AdicionarLivroCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/livro/{id}")]
        public ICommandResult Atualizar(long id, [FromBody] AtualizarLivroCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/livro/{id}")]
        public ICommandResult Excluir(long id)
        {
            var command = new ExcluirLivroCommand() { Id = id};
            return _handler.Handle(command);
        }
    }
}
