namespace Agrobook.Application.Common
{
    public class DadosBancariosCommand
    {
        public string Banco { get; set; }
        public int? Agencia { get; set; }
        public int? Conta { get; set; }
        public string TipoPix { get; set; }
        public string PIX { get; set; }
    }
}