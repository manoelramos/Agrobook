namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Caixa;
    using System;
    using System.Collections.Generic;

    public class Patrimonios : Entity<Patrimonios>
    {
        public string Classificacao { get; set; }
        public string Identificacao { get; set; }
        public string Descricao { get; set; }
        public long NumeroNotaFical { get; set; }


        public DateTime Fabricacao { get; set; }
        public DateTime Compra { get; set; }
        public DateTime Venda { get; set; }

        public int ExpectativaUso { get; set; }
        public decimal ValorNovo { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal TaxaDepreciacaoAnual { get; set; }


        public int FazendaId { get; set; }
        public Fazendas Fazenda { get; set; }
        public int VeivuloId { get; set; }
        public Veiculos Veiculo { get; set; }
        public int OrganizacaoId { get; set; }
        public Organizacoes Organizacao { get; set; }
        public int ImovelId {  get; set; }
        public Imoveis Imovel { get; set; }
        public ICollection<DetalhesPatrimonio> Detalhes { get; set; }
        public ICollection<Despesas> Despesas { get; set; }
    }
}
