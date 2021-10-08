namespace Agrobook.Application.Imoveis.Responses
{
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Application.UnidadesMedidas.Response;

    public class ImovelResponse
    {
        public int PatrimonioId { get; set; }
        public string CodigoImovel { get; set; }
        public decimal Area { get; set; }
        public decimal Capacidade { get; set; }

        public ClasseResponse Classe { get; set; }
        public UnidadeMedidaResponse unidadeMedidaArea { get; set; }
        public UnidadeMedidaResponse unidadeMedidaCapacidade { get; set; }
        public FazendaResponse Fazenda { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}
