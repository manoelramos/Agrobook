namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;

    public class PessoasJuridicas : Entity<PessoasJuridicas>
    {
        public int CNPJ {  get; set; }
        public string Tipo {  get; set; } //Prestador de serviço ou  fornecedor
        public string NomeFantasia {  get; set; }
        public int InscricaoEstadual { get; set; }
        public int InscricaoMunicipal { get; set; }
        public string RamoAtividade {  get; set; }

        public Associados Associado { get; set; }
    }
}
