namespace Agrobook.Application.Imoveis.Commands
{
    using Agrobook.Application.Common;

    public class ImovelCreateCommand : PatrimonioCommand
    {
        public int? FazendaId { get; set; }
        public string Tipo { get; set; }
        public string CodigoImovel { get; set; }
        public decimal Area { get; set; }
        public string UnidadeMedidaArea { get; set; }
        public decimal Capacidade { get; set; }
        public string UnidadeMedidaCapacidade { get; set; }
        public EnderecoCommand Endereco { get; set; }
    }
}
