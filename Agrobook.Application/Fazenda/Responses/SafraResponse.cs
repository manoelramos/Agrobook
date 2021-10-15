namespace Agrobook.Application.Fazenda.Responses
{
    using System;

    public class SafraResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string NomeResponsável { get; set; }
        public string TelefoneResponsável { get; set; }
        public DateTime DataPlantio { get; set; }
        public DateTime DataColheita { get; set; }
        public string SementeUtilizada { get; set; }  
    }
}
