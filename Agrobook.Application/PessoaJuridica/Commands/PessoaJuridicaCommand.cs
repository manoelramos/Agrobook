namespace Agrobook.Application.PessoaJuridica.Commands
{
    public class PessoaJuridicaCommand
    {
        public long Cnpj { get; set; }
        public string Tipo { get; set; }
        public string NomeFantasia { get; set; }
        public long InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string RamoAtividade { get; set; }
    }
}
