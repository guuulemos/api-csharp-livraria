using Flunt.Notifications;
using Livraria.Infra.Interfaces.Commands;
using System;
using System.Text.Json.Serialization;

namespace Livraria.Domain.Commands.Inputs
{
    public class ExcluirLivroCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id deve ser maior que zero");

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
