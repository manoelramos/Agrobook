namespace Agrobook.Application.Common
{
    using Agrobook.Domain.Core.Messaging;
    using System;

    public class PatrimonioCommand : Command
    {
        public int OrganizacaoId {  get; set; }
        public DateTime? DataCompra { get; set; }
        public DateTime? DataVenda { get; set; }
        public decimal? ValorCompra { get; set; }
        public decimal? ValorVenda { get; set; }
    }
}
