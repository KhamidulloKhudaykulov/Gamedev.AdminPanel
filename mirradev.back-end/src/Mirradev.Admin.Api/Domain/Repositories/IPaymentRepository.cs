using System.Linq.Expressions;
using Mirradev.Admin.Api.Domain.Entities;

namespace Mirradev.Admin.Api.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> SelectAll(Expression<Func<Payment, bool>>? predicate = null);
}