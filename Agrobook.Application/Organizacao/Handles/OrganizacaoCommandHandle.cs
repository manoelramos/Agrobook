namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrganizacaoCommandHandle : CommandHandler, IRequestHandler<OrganizacaoCommand, ValidationResult>
    {
        //private Response _response;
        private readonly IOrganizacaoRepository _organizacaoRepository;
        //private readonly IEnderecosRepository _enderecosRepository;
        private readonly IMapper _map;

        public OrganizacaoCommandHandle(IOrganizacaoRepository organizacaoRepository, IMapper map)
            : base(organizacaoRepository.UnitOfWork)
        {
            _organizacaoRepository = organizacaoRepository;
            //_enderecosRepository = enderecosRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(OrganizacaoCommand request, CancellationToken cancellationToken)
        {
            //_response = new Response();

            //if (request.LogoImage64Bits is not null && !request.IsValidImage())
            //    _response.AddNotification(new Notification("500", "A imagem não está em base 64 ou não pode ser convertida."));

            //if (_response.)
            //    return _response;

            //var endereco = _map.Map<Enderecos> (request.Endereco);

            //Organizacoes organizacao =
            //    new(request.NomeCompleto, request.NomeFantasia, Convert.FromBase64String(request.LogoImage64Bits), 0, true);

            var organizacao = _map.Map<Organizacoes>(request);

            await _organizacaoRepository.CreateAsync(organizacao, cancellationToken);

            //_response.AddValue(result);

            return await CommitAsync(cancellationToken);
        }

        //private async Task<bool> IsValidEndereco(int id)
        //{
        //    var result = await _enderecosRepository.GetByIdAsync((long)id);
        //    return result != null;
        //}
    }
}
