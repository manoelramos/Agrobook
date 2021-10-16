namespace Agrobook.Application.Financiamento.Commands
{
    using Agrobook.Domain.Core.Messaging;

    public class FinanciamentoDeleteCommand : Command
    {
        public FinanciamentoDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
