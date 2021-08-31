namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using System;

    public class Patrimonio : Entity<Patrimonio>
    {
        public string Descricao { get; set; }
        public DateTime Compra { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime Venda { get; set; }
        public decimal ValorVenda { get; set; }
        public int FazendaId {  get; set; }
        public Fazenda Fazenda {  get; set; }
        public int VeivuloId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int OrganizacaoId {  get; set; }
        public Organizacao Organizacao {  get; set; }
    }
}
