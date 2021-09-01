namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using System.Collections.Generic;

    public class Enderecos : Entity<Enderecos>
    {
        public Enderecos() { }
        public Enderecos(string logradouro, string bairro, Cidades cidade, Estados estado, Paises pais, int cep, decimal latitude, decimal longitude)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            CEP = cep;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int CEP { get; set; }
        public int CidadeId { get; set; }
        public Cidades Cidade { get; set; }
        public int EstadoId { get; set; }
        public Estados Estado { get; set; }
        public int PaisId { get; set; }
        public Paises Pais { get; set; }        
        public Fazendas Fazenda {  get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ICollection<Organizacoes> Oraganizacoes {  get; set; }
        public ICollection<Associados> Associados { get; set; }
        public ICollection<Imoveis> Imoveis { get; set; }

        protected IEnumerable<object> GetEqualityComponents()
        {
            yield return Logradouro;
            yield return Bairro;
            yield return Cidade;
            yield return Estado;
            yield return CEP;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
