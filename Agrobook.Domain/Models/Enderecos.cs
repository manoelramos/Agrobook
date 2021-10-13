namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using System.Collections.Generic;

    public class Enderecos : Entity<Enderecos>
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
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
            yield return CEP;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
