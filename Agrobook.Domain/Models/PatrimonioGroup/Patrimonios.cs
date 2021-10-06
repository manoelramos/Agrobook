namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Caixa;
    using System;
    using System.Collections.Generic;

    public class Patrimonios : Entity<Patrimonios>
    {
        public long? NumeroNotaFical { get; set; }

        public DateTime? DataCompra { get; set; }
        public DateTime? DataVenda { get; set; }

        public int? ExpectativaUso { get; set; }
        public decimal? ValorCompra { get; set; }
        public decimal? ValorVenda { get; set; }

        public Fazendas Fazenda { get; set; }
        public Veiculos Veiculo { get; set; }
        public Imoveis Imovel { get; set; }

        public int? OrganizacaoId { get; set; }
        public Organizacoes Organizacao { get; set; }

        public ICollection<DetalhesPatrimonio> Detalhes { get; set; }
        public ICollection<Despesas> Despesas { get; set; }
    }
}
