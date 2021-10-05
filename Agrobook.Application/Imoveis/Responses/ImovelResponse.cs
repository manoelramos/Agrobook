namespace Agrobook.Application.Imoveis.Responses
{
    using Agrobook.Application.Organizacao.Responses;

    public class ImovelResponse
    {
        public int? FazendaId { get; set; }
        public string Tipo { get; set; }
        public string CodigoImovel { get; set; }
        public decimal Area { get; set; }
        public string UnidadeMedidaArea { get; set; }
        public decimal Capacidade { get; set; }
        public string UnidadeMedidaCapacidade { get; set; }
        public EnderecoResponse Endereco { get; set; }
        
    }
}
