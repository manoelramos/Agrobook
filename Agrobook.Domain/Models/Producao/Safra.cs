namespace Agrobook.Domain.Models.Producao
{
    using Agrobook.Domain.Core.Models;
    using System;
    using System.Collections.Generic;

    public class Safra : Entity<Safra>
    {
        public string Descricao { get; set; }
        public string Cultura { get; set; }
        public string NomeResponsável { get; set; }
        public string TelefoneResponsável { get; set; }
        public DateTime DataPlantio{  get; set; }
        public DateTime DataColheita { get; set; }
        public string SementeUtilizada {  get; set; }

        public ICollection<TalhaoSafra> TalhaoSafras {  get; set; }
        public ICollection<Atividades> Atividades { get; set; }
    }
}
