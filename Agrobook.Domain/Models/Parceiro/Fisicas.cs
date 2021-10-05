namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;
    using System;

    public class Fisicas : Entity<Fisicas>
    {
        public long CPF {  get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento {  get; set; }
        public string GrauInstrucao {  get; set; }
        public string EstadoCivil {  get; set; }
        public string CTPS {  get; set; }
        public string SerieCtps {  get; set; }
        public string PisPasep { get; set; }

        public int AssociadoId {  get; set; }
        public Associados Pessoa {  get; set; }
    }
}

