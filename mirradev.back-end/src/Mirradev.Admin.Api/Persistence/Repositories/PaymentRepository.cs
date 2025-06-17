using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mirradev.Admin.Api.Domain.Entities;
using Mirradev.Admin.Api.Domain.Repositories;
using Mirradev.Admin.Api.Persistence;

namespace Mirradev.Admin.Api.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Payment> _payments;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
        _payments = context.Set<Payment>();
    }

    public async Task<IEnumerable<Payment>> SelectAll(Expression<Func<Payment, bool>>? predicate = null)
    {
        var result = predicate is null 
            ? await _payments.ToListAsync()
            : await Task.FromResult(_payments.Where(predicate).AsEnumerable());
        
        return result;
    }
}