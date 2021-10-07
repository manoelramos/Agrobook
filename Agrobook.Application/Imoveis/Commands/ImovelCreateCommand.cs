namespace Agrobook.Application.Imoveis.Commands
{
    using Agrobook.Application.Common;

    public class ImovelCreateCommand : PatrimonioCommand
    {
        public string Nome { get; set; }
        public string CodigoImovel { get; set; }
        public decimal? Area { get; set; }
        public int UnidadeMedidaAreaId { get; set; }
        public int? FazendaId { get; set; }
        public decimal Capacidade { get; set; }
        public int UnidadeMedidaCapacidadeId { get; set; }
        public int? ClasseId { get; set; }
        public EnderecoCommand Endereco { get; set; }
    }
}
