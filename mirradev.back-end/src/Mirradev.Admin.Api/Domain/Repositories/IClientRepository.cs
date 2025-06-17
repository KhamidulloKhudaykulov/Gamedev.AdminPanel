using Mirradev.Admin.Api.Domain.Entities;

namespace Mirradev.Admin.Api.Domain.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> SelectAllAsync();
}