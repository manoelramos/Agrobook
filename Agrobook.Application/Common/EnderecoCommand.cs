namespace Agrobook.Application.Common
{
    public class EnderecoCommand
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public int EstadoId { get; set; }
        public int CEP { get; set; }
        public int PaisId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
