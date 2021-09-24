namespace Agrobook.Application.Organizacao.Commands
{
    using Agrobook.Domain.Core.Messaging;

    public class OrganizacaoDeleteCommand : Command
    {
        public OrganizacaoDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }
    }
}
