namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;
    using System;
    using System.Collections.Generic;

    public enum ModeloContrato
    {
        CLT,
        Terceirizado,
        Temporario
    }

    public class Contratacoes : Entity<Contratacoes>
    {
        public int Modelo {  get; set; }
        
        //Subistituir por um entidade pagamento
        //public String Pagamento {  get; set; }


        public DateTime Inicio {  get; set; }
        public DateTime Termmino {  get; set; }
        public decimal Valor {  get; set; }
        public int OrganizacaoId {  get; set; }
        public Organizacoes Organizacao {  get; set; }
        public ICollection<Associados> Associados {  get; set; }
    }
}
