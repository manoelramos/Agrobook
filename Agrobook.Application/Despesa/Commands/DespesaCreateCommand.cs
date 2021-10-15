namespace Agrobook.Application.Despesa.Commands
{
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class DespesaCreateCommand : Command
    {
        public int CategoriaId { get; set; }
        public string Observacao { get; set; }
        public int PatrimonioId { get; set; }
        public int SafraId { get; set; }
        public List<ParcelaCreateCommand> Parcelas { get; set; }
    }
}

