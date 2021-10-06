namespace Agrobook.Application.UnidadesMedidas.Commmand
{
    using Agrobook.Domain.Core.Messaging;

    public class UnidadeMedidaCreateCommand : Command
    {
        public string Descricao {  get; set; }
        public string Simbolo { get; set; }
        public decimal? ValorUnidade { get; set; }
        public int? UnidadeBaseId {  get; set; }
    }
}
