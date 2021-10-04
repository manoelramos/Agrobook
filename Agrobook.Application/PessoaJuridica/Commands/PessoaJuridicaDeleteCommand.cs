namespace Agrobook.Application.PessoaJuridica.Commands
{
    using Agrobook.Domain.Core.Messaging;

    public class PessoaJuridicaDeleteCommand : Command
    {
        public PessoaJuridicaDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }

    }
}
