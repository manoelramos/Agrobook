namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Enum;
    using Agrobook.Domain.Core.Models;
    using System;  

    public class Contratacoes : Entity<Contratacoes>
    {
        public Categorias.ModeloContrato Modelo {  get; set; }
        public string Funcao {  get; set; }
                
        public DateTime Inicio {  get; set; }
        public DateTime Termmino {  get; set; }
        public decimal ValorReferencia {  get; set; }

        public int OrganizacaoId {  get; set; }
        public Organizacoes Organizacao {  get; set; }

        public int AssociadoId {  get; set; }
        public Associados Associado {  get; set; }
    }
}
