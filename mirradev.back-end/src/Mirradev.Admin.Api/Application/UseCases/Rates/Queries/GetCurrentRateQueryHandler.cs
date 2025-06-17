using MediatR;
using Mirradev.Admin.Api.Domain.Repositories;

namespace Mirradev.Admin.Api.Application.UseCases.Rates.Queries;

public record GetCurrentRateQuery : IRequest<string>;

public class GetCurrentRateQueryHandler : IRequestHandler<GetCurrentRateQuery, string>
{
    private readonly IRateRepository _rateRepository;

    public GetCurrentRateQueryHandler(IRateRepository rateRepository)
    {
        _rateRepository = rateRepository;
    }

    public async Task<string> Handle(GetCurrentRateQuery request, CancellationToken cancellationToken)
    {
        var result = await _rateRepository.Select();

        return result.RateValue.ToString();
    }
}
