namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;

    public class Imoveis : Entity<Imoveis>
    {
        public string Tipo { get; set; }
        public string CodigoImovel { get; set; }
        public decimal Area { get; set; }
        public string UnidadeMedidaArea { get; set; }
        public decimal Capacidade { get; set; }
        public string UnidadeMedidaCapacidade { get; set; }

        public int EnderecoId { get; set; }
        public Enderecos Endereco { get; set; }
        public int PatrimonioId { get; set; }
        public Patrimonios Patrimonio { get; set; }

        public int? FazendaId { get; set; }
        public Fazendas Fazenda {  get; set; }
    }
}
