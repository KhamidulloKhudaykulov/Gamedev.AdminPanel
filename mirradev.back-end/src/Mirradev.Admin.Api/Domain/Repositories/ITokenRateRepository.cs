using System.Linq.Expressions;
using Mirradev.Admin.Api.Domain.Entities;

namespace Mirradev.Admin.Api.Domain.Repositories;

public interface IRateRepository
{
    Task<Rate> UpdateAsync(Rate rate);
    Task<Rate> Select(Expression<Func<Rate, bool>>? predicate = null);
}