using Calculation.Domain;

namespace Calculation.Services;

public class CalculationService : ICalculationService
{
    public IDictionary<int, CalculationResult> Calculate(CalculationList calculationList)
    {
        var res = new Dictionary<int, CalculationResult>();
        var count = default(int);
        
        for (var t = calculationList.StartTime; t < calculationList.EndTime;t = t + calculationList.StepTime)
        {
            var calculationListYi = calculationList.Yi;
            var y = EulerMethod(calculationListYi, calculationList.Parameters, calculationList.StepTime);
            Console.WriteLine($" t={t}, y({t}) = {y[0]}, y({t}) = {y[1]}");
            res.Add(count, new CalculationResult { Time = t, Y = y});
            count++;
        }

        return res;
    }
    
    private static List<double> Function(List<double> y, IReadOnlyList<double> parameters)
    {
        return y.Select((t, i) => parameters[i] * t).ToList();
    }
    
    private static List<double> EulerMethod(List<double> y, IReadOnlyList<double> parameters, double h)
    {
        var res = new List<double>();
        var dy = Function(y, parameters);
        
        for (var i = 0; i < y.Count; i++)
        {
            y[i] += h * dy[i];
            res.Add(y[i]);
        }

        res = y;
        return res;
    }
}

public interface ICalculationService
{
    public IDictionary<int, CalculationResult> Calculate(CalculationList calculationList);
}