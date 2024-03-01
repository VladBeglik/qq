using Calculation.Domain;
using Calculation.Hub;
using Calculation.Hub.Client;
using Calculation.Services;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Calculation.Calculations.Commands;

public class CalculateEquationsCommand : IRequest
{
    public CalculationList CalculationList { get; set; }
}

public class CalculateEquationsCommandHandler : IRequestHandler<CalculateEquationsCommand>
{
    private readonly IHubContext<CalculationHub, ICalculationClient> _hubClient;
    private readonly ICalculationService _calculationService;

    public CalculateEquationsCommandHandler(IHubContext<CalculationHub, ICalculationClient> hubClient, ICalculationService calculationService)
    {
        _hubClient = hubClient;
        _calculationService = calculationService;
    }

    public async Task Handle(CalculateEquationsCommand request, CancellationToken cancellationToken)
    {
        var result = _calculationService.Calculate(request.CalculationList);
        await _hubClient.Clients.All.EquationsCalculated(result);
    }
}