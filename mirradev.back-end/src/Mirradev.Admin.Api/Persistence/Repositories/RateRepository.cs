using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mirradev.Admin.Api.Domain.Entities;
using Mirradev.Admin.Api.Domain.Repositories;
using Mirradev.Admin.Api.Persistence;

namespace Mirradev.Admin.Api.Persistence.Repositories;

public class RateRepository : IRateRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Rate> _rates;

    public RateRepository(ApplicationDbContext context)
    {
        _context = context;
        _rates = _context.Set<Rate>();
    }


    public async Task<Rate> UpdateAsync(Rate rate)
    {
        return await Task.FromResult(_rates.Update(rate).Entity);
    }

    public async Task<Rate> Select(Expression<Func<Rate, bool>>? predicate = null)
    {
        var result = predicate is null 
            ? await _rates.FirstOrDefaultAsync()
            : await _rates.FirstOrDefaultAsync(predicate);
        
        return result!;
    }
}