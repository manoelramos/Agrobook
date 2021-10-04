namespace Agrobook.Application.PessoaFisica.Commands
{
    using Agrobook.Domain.Core.Messaging;

    public class PessoaFisicaDeleteCommand : Command
    {
        public PessoaFisicaDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }

    }
}
