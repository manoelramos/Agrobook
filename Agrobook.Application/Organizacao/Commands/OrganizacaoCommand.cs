namespace Agrobook.Application.Organizacao.Commands
{
    using Agrobook.Domain.Core.Messaging;
    using FluentValidation.Results;
    using System;

    public record Endereco(string Logradouro, string Bairro, int CidadeId, int EstadoId, int CEP, int PaisId, decimal? Latitude, decimal? Longitude);

    public class OrganizacaoCommand : Command
    {
        //public OrganizacaoCommand(string nomeCompleto, string nomeFantasia, string logoImage64Bits, Endereco endereco)
        //{
        //    NomeCompleto = nomeCompleto;
        //    NomeFantasia = nomeFantasia;
        //    LogoImage64Bits = logoImage64Bits;
        //    Endereco = endereco;
        //}

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
