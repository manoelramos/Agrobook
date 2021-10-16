namespace Agrobook.Application.Financiamento.Responses
{
    using System;

    public class FinanciamentoResponse
    {
        public decimal ValorFinanciado { get; set; }
        public string Descricao { get; set; }
        public DateTime AdquiridoEm { get; set; }

        //public int? CredorId { get; set; }
        //public Associados Credor { get; set; }

        //public int? PatrimonioId { get; set; }
        //public Patrimonios Patrimonio { get; set; }

        //public int IdMoedaParcela { get; set; }
        //public Moedas Moeda { get; set; }

        //public ICollection<Parcelas> Parcelas { get; set; }
    }
}

