namespace Agrobook.Application.Financiamento.Commands
{
    using Agrobook.Application.Parcela.Commands;
    using Agrobook.Domain.Core.Messaging;
    using System;
    using System.Collections.Generic;

    public class FinanciamentoCreateCommand : Command
    {
        public decimal ValorFinanciado { get; set; }
        public string Descricao { get; set; }
        public DateTime AdquiridoEm { get; set; }

        public int CredorId { get; set; }
        public int PatrimonioId { get; set; }
        public int IdMoedaParcela { get; set; }

        public ICollection<ParcelaCreateCommand> Parcelas { get; set; }
    }
}
