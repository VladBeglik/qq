using Calculation.Domain;

namespace Calculation.Hub.Client;

public interface ICalculationClient
{
    Task EquationsCalculated(IDictionary<int, CalculationResult> message);
}