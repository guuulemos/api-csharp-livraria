using Flunt.Notifications;
using Livraria.Infra.Interfaces.Commands;
using System;

namespace Livraria.Domain.Commands.Inputs
{
    public class AdicionarLivroCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public string Isbn { get; set; }
        public string Imagem { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                else if(Nome.Length > 50)
                    AddNotification("Nome", "Nome maior que 50 caracteres");

                if (string.IsNullOrWhiteSpace(Autor))
                    AddNotification("Autor", "Autor é um campo obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Autor", "Autor maior que 50 caracteres");

                if (Edicao <= 0)
                    AddNotification("Edicao", "Edição deve ser maior que zero");

                if (string.IsNullOrWhiteSpace(Isbn))
                    AddNotification("Isbn", "Isbn é um campo obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Isbn", "Isbn maior que 50 caracteres");

                if (string.IsNullOrWhiteSpace(Imagem))
                    AddNotification("Imagem", "Imagem é um campo obrigatório");

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
