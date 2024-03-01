using Calculation.Domain;
using Calculation.Hub.Client;
using Microsoft.AspNetCore.SignalR;

namespace Calculation.Hub;

public class CalculationHub : Hub<ICalculationClient>, ICalculationHub
{
    public Task CalculateEquations(CalculationList calculationList)
    {
        throw new NotImplementedException();
    }

    public Task<List<CalculationResult>> GetHistory()
    {
        throw new NotImplementedException();
    }
}