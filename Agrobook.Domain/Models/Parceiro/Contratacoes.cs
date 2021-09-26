namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;
    using System;
    using System.Collections.Generic;

    public enum ModeloContrato
    {
        CLT,
        TempoDeterminado,
        TempoIndeterminado,
        Temporario,
        TrabalhoEventual,
        JovemAprendiz,
        Estagiario,
        Intermitente,
        PessoaJuridica
    }

    public class Contratacoes : Entity<Contratacoes>
    {
        public int Modelo {  get; set; }
        public string Funcao {  get; set; }
                
        public DateTime Inicio {  get; set; }
        public DateTime Termmino {  get; set; }
        public decimal Valor {  get; set; }

        public int OrganizacaoId {  get; set; }
        public Organizacoes Organizacao {  get; set; }

        public int AssociadoId {  get; set; }
        public Associados Associado {  get; set; }
    }
}
