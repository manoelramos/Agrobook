namespace Agrobook.Application.Despesa.Response
{
    using Agrobook.Application.CategoriaDespesa.Responses;
    using Agrobook.Application.Fazenda.Responses;
    using System.Collections.Generic;

    public class DespesaResponse
    {
        public decimal? Valor { get; set; }
        public string Observacao { get; set; }
        public AssociadoResponse Credor { get; set; }
        public CategoriaDespesaResponse CategoriaDespesa { get; set; }
        public SafraResponse Safra { get; set; }
        public PatrimonioResponse Patrimonio { get; set; }
        public ICollection<ParcelaResponse> Parcelas { get; set; }
    }
}
