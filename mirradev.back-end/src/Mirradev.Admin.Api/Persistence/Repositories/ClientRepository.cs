using Microsoft.EntityFrameworkCore;
using Mirradev.Admin.Api.Domain.Entities;
using Mirradev.Admin.Api.Domain.Repositories;
using Mirradev.Admin.Api.Persistence;

namespace Mirradev.Admin.Api.Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Client> _clients;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
        _clients = context.Set<Client>();
    }

    public async Task<IEnumerable<Client>> SelectAllAsync()
    {
        return await _clients
            .Include(c => c.Payments)
            .ToListAsync();
    }
}