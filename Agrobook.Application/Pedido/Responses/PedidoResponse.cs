namespace Agrobook.Application.Pedido.Responses
{
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Application.Insumo.Responses;
    using Agrobook.Application.PessoaJuridica.Responses;
    using Agrobook.Application.UnidadesMedidas.Response;
    using System.Collections.Generic;

    public class PedidoResponse
    {
        public int NumeroPedidoFornecedor { get; set; }
        public decimal Quantidade { get; set; }
        public bool PossuiRoyalty { get; set; }

        public UnidadeMedidaResponse UnidadeMedida { get; set; }
        public List<ParcelaResponse> Parcela { get; set; }
        public PessoaJuridicaResponse Fornedor { get; set; }
        public FazendaResponse Fazenda { get; set; }
        public InsumoResponse Insumo { get; set; }
    }
}
