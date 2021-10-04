namespace Agrobook.Application.PessoaFisica.Queries
{
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Domain.Core.Messaging;

    public class PessoaFisicaByIdQuery : Query<PessoaFisicaResponse>
    {
        public PessoaFisicaByIdQuery(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }
    }
}
