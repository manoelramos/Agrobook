namespace Agrobook.Application.Fazenda.Commands
{
    using Agrobook.Domain.Core.Messaging;

    public class FazendaDeleteCommand : Command
    {
        public FazendaDeleteCommand(int id)
        {
            Id = id;
        }

        public  int Id {  get; set; }
    }
}
