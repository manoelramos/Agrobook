namespace Agrobook.Domain.Core.Enum
{
    public static class Categorias
    {
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

        public enum TipoRelacao
        {
            Cliente,
            Fornecedor,
            Colaborador
        }
    }
}
