using Flunt.Notifications;
using Livraria.Domain.Commands.Inputs;
using Livraria.Domain.Commands.Outputs;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Infra.Interfaces.Commands;
using System;

namespace Livraria.Domain.Handler
{
    public class LivroHandler : ICommandHandler<AdicionarLivroCommand>, ICommandHandler<AtualizarLivroCommand>, ICommandHandler<ExcluirLivroCommand>
    {
        private readonly ILivroRepository _repository;

        public LivroHandler(ILivroRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarLivroCommand command)
        {

            if (!command.ValidarCommand())
                return new LivroCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

            long id = 0;
            string nome = command.Nome;
            string autor = command.Autor;
            int edicao = command.Edicao;
            string isbn = command.Isbn;
            string imagem = command.Imagem;

            Livro livro = new Livro(id, nome, autor, edicao, isbn, imagem);

            id = _repository.Inserir(livro);

            return new LivroCommandResult(true, "Livro adicionado com sucesso!", new
            {
                Nome = livro.Nome,
                Autor = livro.Autor,
                Edicao = livro.Edicao,
                Isbn = livro.Isbn,
                Imagem = livro.Imagem
            });

        }

        public ICommandResult Handle(AtualizarLivroCommand command)
        {
            if (!command.ValidarCommand())
                return new LivroCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

            if (!_repository.CheckId(command.Id))
                return new LivroCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadastrado!"));

            long id = command.Id;
            string nome = command.Nome;
            string autor = command.Autor;
            int edicao = command.Edicao;
            string isbn = command.Isbn;
            string imagem = command.Imagem;

            Livro livro = new Livro(id, nome, autor, edicao, isbn, imagem);

            _repository.Atualizar(livro);

            return new LivroCommandResult(true, "Livro atualizado com sucesso!", new
            {
                Id = livro.Id,
                Nome = livro.Nome,
                Autor = livro.Autor,
                Edicao = livro.Edicao,
                Isbn = livro.Isbn,
                Imagem = livro.Imagem
            });

        }

        public ICommandResult Handle(ExcluirLivroCommand command)
        {

            if (!command.ValidarCommand())
                return new LivroCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

            if (!_repository.CheckId(command.Id))
                return new LivroCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadastrado!"));

            _repository.Excluir(command.Id);

            return new LivroCommandResult(true, "Livro excluído com sucesso!", new { Id = command.Id });
        }
    }
}
