namespace Agrobook.Application.PessoaFisica.Queries
{
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class PessoasFisicasQuery : Query<List<PessoaFisicaResponse>>
    {
        public PessoasFisicasQuery(bool active) 
        {
            Active = active;
        }

        public bool Active { get; set; }
    }
}

