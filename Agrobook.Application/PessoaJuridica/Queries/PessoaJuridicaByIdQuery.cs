namespace Agrobook.Application.PessoaJuridica.Queries
{
    using Agrobook.Application.PessoaJuridica.Responses;
    using Agrobook.Domain.Core.Messaging;

    public class PessoaJuridicaByIdQuery : Query<PessoaJuridicaResponse>
    {
        public PessoaJuridicaByIdQuery(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }
    }
}
