﻿namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;

    public class Juridicas : Entity<Juridicas>
    {
        public int CNPJ {  get; set; }        
        public string NomeFantasia {  get; set; }
        public int? InscricaoEstadual { get; set; }
        public int? InscricaoMunicipal { get; set; }
        public string RamoAtividade {  get; set; }

        public int AssociadoId { get; set; }
        public Associados Pessoa { get; set; }
    }
}
