namespace Calculation.Domain;

public class CalculationList
{
    public int CountEquations { get; set; }
    public List<double> Yi { get; set; }
    public List<double> Parameters { get; set; }
    public double StartTime { get; set; }
    public double EndTime { get; set; }
    public double StepTime { get; set; }
}