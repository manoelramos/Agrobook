﻿namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;
    using System;

    public class PessoasFisicas : Entity<PessoasFisicas>
    {
        public int CPF {  get; set; }
        public int RG { get; set; }
        public DateTime DataNascimento {  get; set; }
        public string NomeMae {  get; set; }
        public string NomePai { get; set; }
        public string GrauInstrucao {  get; set; }
        public string Funcao {  get; set; }
        public string EstadoCivil {  get; set; }
        public string CTPS {  get; set; }
        public string PisPasep {  get; set; }
        public Associados Associado {  get; set; }
    }
}

