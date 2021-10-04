namespace Agrobook.Application.UnidadesMedidas.Commmand
{
    using Agrobook.Domain.Core.Messaging;

    public class UnidadeMedidaCreateCommand : Command
    {
        public string Descricao {  get; set; }
        public string Simbolo { get; set; }
        public decimal Quantidade { get; set; }
        public int UnidadesMedidasId {  get; set; }
    }
}
