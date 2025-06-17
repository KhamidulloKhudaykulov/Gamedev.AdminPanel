using System.Linq.Expressions;

namespace Mirradev.Admin.Api.Domain.Repositories;

public interface IAdminRepository
{
    Task<Entities.Admin> InsertAsync(Entities.Admin admin);
    Task<Entities.Admin> UpdateAsync(Entities.Admin admin);
    Task<Entities.Admin> DeleteAsync(Entities.Admin admin);
    Task<Domain.Entities.Admin> SelectAsync(Expression<Func<Entities.Admin, bool>>? predicate = null);
}