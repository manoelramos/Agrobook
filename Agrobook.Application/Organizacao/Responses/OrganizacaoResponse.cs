namespace Agrobook.Application.Organizacao.Responses
{
    public class OrganizacaoResponse
    {
        public long Id {  get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public byte[] LogoMarca { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }

    public class EnderecoResponse
    {
        public long Id {  get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int? CEP { get; set; }
        public int? CidadeId { get; set; }
        public int? EstadoId { get; set; }
        public int? PaisId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
