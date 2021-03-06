namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Base;

    public class Imoveis : Entity<Imoveis>
    {
        public string Nome { get; set; }
        public string CodigoImovel { get; set; }

        public decimal? Area { get; set; }
        public int UnidadeMedidaAreaId { get; set; }
        public UnidadesMedidas UnidadeMedidaArea { get; set; }

        public decimal Capacidade { get; set; }
        public int UnidadeMedidaCapacidadeId { get; set; }
        public UnidadesMedidas UnidadeMedidaCapcidade { get; set; }

        public int? FazendaId { get; set; }
        public Fazendas Fazenda { get; set; }

        public int? EnderecoId { get; set; }
        public Enderecos Endereco { get; set; }

        public int PatrimonioId { get; set; }
        public Patrimonios Patrimonio { get; set; }

        public int? ClasseId { get; set; }
        public Classses Classe { get; set; }

    }
}
