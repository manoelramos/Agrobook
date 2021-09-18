namespace Agrobook.Application.Organizacao.Commands
{
    using Agrobook.Domain.Core.Messaging;
    using System;

    public record Endereco(string Logradouro, string Bairro, int CidadeId, int EstadoId, int CEP, int PaisId, decimal? Latitude, decimal? Longitude);

    public class OrganizacaoCreateCommand : Command
    {
        public string NomeCompleto { get; set; }
        public string NomeFantasia { get; set; }
        public string LogoImage64Bits { get; set; }
        public Endereco Endereco { get; set; }

        public bool IsValidImage()
        {
            Span<byte> buffer = new(new byte[LogoImage64Bits.Length]);
            return Convert.TryFromBase64String(LogoImage64Bits, buffer, out int byteParsed);
        }
    }
}
