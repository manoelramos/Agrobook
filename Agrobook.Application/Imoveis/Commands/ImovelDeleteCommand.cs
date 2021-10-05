﻿namespace Agrobook.Application.Imoveis.Commands
{
    using Agrobook.Application.Imoveis.Responses;
    using Agrobook.Domain.Core.Messaging;

    public class ImovelDeleteCommand : Command
    {
        public ImovelDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }
    }
}
