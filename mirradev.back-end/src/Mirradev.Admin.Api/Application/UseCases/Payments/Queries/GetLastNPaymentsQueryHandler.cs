using MediatR;
using Mirradev.Admin.Api.Domain.Entities;
using Mirradev.Admin.Api.Domain.Repositories;

namespace Mirradev.Admin.Api.Application.UseCases.Payments.Queries;

public record GetLastNPaymentsQuery(
    int Amount) : IRequest<List<Payment>>; 

public class GetLastNPaymentsQueryHandler : IRequestHandler<GetLastNPaymentsQuery, List<Payment>>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetLastNPaymentsQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<List<Payment>> Handle(GetLastNPaymentsQuery request, CancellationToken cancellationToken)
    {
        var nPayments = (await _paymentRepository.SelectAll())
            .OrderByDescending(x => x.CreatedAt)
            .Take(request.Amount);
        
        return nPayments.ToList();
    }
}
