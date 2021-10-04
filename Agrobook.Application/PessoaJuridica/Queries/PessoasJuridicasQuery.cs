namespace Agrobook.Application.PessoaJuridica.Queries
{
    using Agrobook.Application.PessoaJuridica.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class PessoasJuridicasQuery : Query<List<PessoaJuridicaResponse>>
    {
        public PessoasJuridicasQuery(bool active) 
        {
            Active = active;
        }

        public bool Active { get; set; }
    }
}

