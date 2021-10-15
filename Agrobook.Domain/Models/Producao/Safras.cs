namespace Agrobook.Domain.Models.Producao
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Caixa;
    using System;
    using System.Collections.Generic;

    public class Safras : Entity<Safras>
    {
        public string Descricao { get; set; }
        public string NomeResponsável { get; set; }
        public string TelefoneResponsável { get; set; }
        public DateTime DataPlantio{  get; set; }
        public DateTime DataColheita { get; set; }
        public string SementeUtilizada {  get; set; }

        public ICollection<TalhoesSafras> TalhaoSafras {  get; set; }
        public ICollection<Atividades> Atividades { get; set; }
        public ICollection<Despesas> Despesas { get; set; }

        public int CulturaId { get; set; }
        public Culturas Cultura { get; set; }
    }
}
