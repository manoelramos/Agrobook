namespace Agrobook.Application.Organizacao.Commands
{
    using Agrobook.Application.Common;
    using Agrobook.Domain.Core.Messaging;
    using System;    

    public  class OrganizacaoUpdateCommand : Command
    {
        public int Id {  get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string LogoImage64Bits { get; set; }
        public bool Ativo {  get; set; }

        public EnderecoCommand Endereco { get; set; }

        public bool IsValidImage()
        {
            Span<byte> buffer = new(new byte[LogoImage64Bits.Length]);
            return Convert.TryFromBase64String(LogoImage64Bits, buffer, out int byteParsed);
        }
    }
}
