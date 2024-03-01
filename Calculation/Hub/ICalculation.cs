using Calculation.Domain;

namespace Calculation.Hub;

public interface ICalculationHub
{
    Task CalculateEquations(CalculationList calculationList);
    Task<List<CalculationResult>> GetHistory();
}