namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Producao;
    using System.Collections.Generic;

    public class Fazendas : Entity<Fazendas>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long? Telefone { get; set; }
        public decimal? Hectare { get; set; }
        public string Administrador { get; set; }
        public decimal? TaxaValorizacaoAnual { get; set; }
        public int? EnderecoId { get; set; }
        public Enderecos Endereco { get; set; }
        public int PatrimonioId { get; set; }
        public Patrimonios Patrimonio { get; set; }
        public ICollection<Talhoes> Talhoes { get; set; }
    }
}
