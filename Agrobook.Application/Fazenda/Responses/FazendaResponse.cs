namespace Agrobook.Application.Fazenda.Responses
{
    using Agrobook.Application.Organizacao.Responses;

    public class FazendaResponse
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long? Telefone { get; set; }
        public decimal? Hectare { get; set; }
        public string Administrador { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}
