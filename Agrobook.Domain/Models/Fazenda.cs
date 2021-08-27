namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class Fazenda : Entity<Fazenda>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long Telefone {  get; set; }
        public decimal Hectare {  get; set; }        
        public string Administrador { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco {  get; set; }
        public Patrimonio Patrimonio {  get; set; }
    }
}
