using Calculation.Domain;
using Calculation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculation.Controllers;

[Controller]
public class CalculateController : ControllerBase
{
    private readonly ICalculationService _calculationService;

    public CalculateController(ICalculationService calculationService)
    {
        _calculationService = calculationService;
    }

    [HttpPost]
    [Route("/Calculate")]
    public async Task<IDictionary<int, CalculationResult>> GetCalculation(CalculationList r)
    {
        var res = _calculationService.Calculate(r);
        return res;
    }
}