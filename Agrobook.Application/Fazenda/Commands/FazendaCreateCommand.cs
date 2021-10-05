namespace Agrobook.Application.Fazenda.Commands
{
    using Agrobook.Application.Common;

    public class FazendaCreateCommand : PatrimonioCommand
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long? Telefone { get; set; }
        public decimal? Hectare { get; set; }
        public string Administrador { get; set; }
        public decimal? TaxaValorizacaoAnual { get; set; }
        public int? EnderecoId { get; set; }
        public EnderecoCommand Endereco { get; set; }
    }
}
