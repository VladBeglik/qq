using Calculation.Calculations.Commands;
using Calculation.Domain;

namespace Calculation.Hub;

public interface ICalculationHub
{
    Task CalculateEquations(CalculateEquationsCommand command);
    Task<List<CalculationResult>> GetHistory();
}