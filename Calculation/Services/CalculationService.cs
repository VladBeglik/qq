using System.Globalization;
using Calculation.Domain;

namespace Calculation.Services;

public class CalculationService : ICalculationService
{
    public IDictionary<int, CalculationResult> Calculate(CalculationList calculationList)
    {
        var res = new Dictionary<int, List<CalculationResult>>();
        var count = default(int);
        // Выполнение метода Эйлера для каждого временного шага
        for (var t = calculationList.StartTime; t < calculationList.EndTime;t =+ calculationList.StepTime)
        {
            var calculationListYi = calculationList.Yi;
            EulerMethod(ref calculationListYi, calculationList.Parameters, calculationList.StepTime);
            Console.WriteLine($" t={t}, y({t}) = {calculationListYi[0]}, y({t}) = {y[1]}");
            res.Add(count, new CalculationResult{ Time = t, Y = calculationListYi.ForEach(_ => _.)});
        }
    }
    
    private static List<double> Function(List<double> y, IReadOnlyList<double> parameters)
    {
        return y.Select((t, i) => parameters[i] * t).ToList();
    }
    
    //Метод Эйлера
    private static void EulerMethod(ref List<double> y, IReadOnlyList<double> parameters, double h)
    {
        var dy = Function(y, parameters);
        
        for (var i = 0; i < y.Count; i++)
        {
            y[i] += h * dy[i];
        }
    }
}

public interface ICalculationService
{
    public IDictionary<int, CalculationResult> Calculate(CalculationList calculationList);
}