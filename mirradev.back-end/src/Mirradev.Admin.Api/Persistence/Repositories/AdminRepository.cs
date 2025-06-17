using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mirradev.Admin.Api.Domain.Repositories;

namespace Mirradev.Admin.Api.Persistence.Repositories;

public class AdminRepository : IAdminRepository 
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Domain.Entities.Admin> _admins;

    public AdminRepository(ApplicationDbContext context)
    {
        _context = context;
        _admins = context.Set<Domain.Entities.Admin>();
    }

    public Task<Domain.Entities.Admin> InsertAsync(Domain.Entities.Admin admin)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Admin> UpdateAsync(Domain.Entities.Admin admin)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Admin> DeleteAsync(Domain.Entities.Admin admin)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Entities.Admin> SelectAsync(Expression<Func<Domain.Entities.Admin, bool>>? predicate = null)
    {
        var result = predicate is null 
            ? await _admins.FirstOrDefaultAsync()
            : await _admins.FirstOrDefaultAsync(predicate);
        
        return result!;
    }
}