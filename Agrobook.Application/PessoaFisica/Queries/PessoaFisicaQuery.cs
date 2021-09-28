namespace Agrobook.Application.PessoaFisica.Queries
{
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class PessoaFisicaQuery : Query<List<AssociadoResponse>>
    {
        public PessoaFisicaQuery(bool active) 
        {
            Active = active;
        }

        public bool Active { get; set; }
    }
}

