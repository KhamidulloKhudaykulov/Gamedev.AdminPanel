using Mirradev.Admin.Api.Domain.Entities;
using MediatR;
using Mirradev.Admin.Api.Domain.Repositories;

namespace Mirradev.Admin.Api.Application.UseCases.Clients.Queries;

public record GetAllClientsQuery: IRequest<List<Client>>;

public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<Client>>
{
    private readonly IClientRepository _clientRepository;

    public GetAllClientsQueryHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<List<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        var result = await _clientRepository.SelectAllAsync();
        
        return result.ToList();
    }
}