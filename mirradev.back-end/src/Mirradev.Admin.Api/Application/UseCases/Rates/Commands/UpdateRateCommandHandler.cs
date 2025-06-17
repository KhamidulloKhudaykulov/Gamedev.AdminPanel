using MediatR;
using Mirradev.Admin.Api.Domain.Repositories;

namespace Mirradev.Admin.Api.Application.UseCases.Rates.Commands;

public record UpdateRateCommand(decimal RateValue)
    : IRequest<string>;

public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, string>
{
    private readonly IRateRepository _rateRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRateCommandHandler(IRateRepository rateRepository, IUnitOfWork unitOfWork)
    {
        _rateRepository = rateRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<string> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
    {
        var rate = await _rateRepository.Select();
        rate.RateValue = request.RateValue;
        rate.UpdatedAt = DateTime.UtcNow;
        
        await _rateRepository.UpdateAsync(rate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return rate.RateValue.ToString();
    }
}
