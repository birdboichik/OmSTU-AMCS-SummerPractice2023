namespace SquareEquationLib.BDDTests;
using SquareEquationLib;
using TechTalk.SpecFlow;
using System;
using Xunit;

[Binding]
public class StepDefinitions
{
    private const double TOLERATE = 10e-7;
    private double[] _coefficients = new double[3];
    private double[] _actualRoots = new double[0];
    private Exception _actualException = new Exception();
    [When("вычисляются корни квадратного уравнения")]
    public void EvaluateEquationRoots()
    {
        try 
        {
            _actualRoots = SquareEquation.Solve(
                _coefficients[0],
                _coefficients[1],
                _coefficients[2]
            );
        }
        catch (Exception e)
        {
            _actualException =  e;
        }
    }
    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void GiveSqaureEquationCoefficients(string a, string b, string c) 
    {
        string[] input = new string[] {a.Split(".")[^1], b.Split(".")[^1], c.Split(".")[^1]};
        
        for (int i = 0; i < 3; i++)
        {
            if (input[i] == "NegativeInfinity")
                _coefficients[i] = double.NegativeInfinity;
            else if (input[i] == "PositiveInfinity")
                _coefficients[i] = double.PositiveInfinity;
            else if (input[i] == "NaN")
                _coefficients[i] = double.NaN;
            else
                _coefficients[i] = double.Parse(input[i]);
        }
    }
    [Then("выбрасывается исключение ArgumentException")]
    public void ThrowingArgumentException()
    {
        Assert.ThrowsAsync<ArgumentException>(() => throw _actualException);
    }
    
    [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
    public void SquareEquationHasOneRoot(double x)
    {
        double[] expectedRoots = new double[] {x};
        
        if (_actualRoots.Length != 1)
        {
            Assert.True(false, "Message");
        }

        for (int i = 0; i < expectedRoots.Length; i++)
        {
            Assert.Equal(_actualRoots[i], expectedRoots[i]);
        }
    }

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
    public void SqaureEquationHasTwoRoots(double x1, double x2)
    {
        double[] expectedRoots = new double[] {x1, x2};
        
        Array.Sort(expectedRoots);
        Array.Sort(_actualRoots);

        if (_actualRoots.Length != 2)
        {
            Assert.True(false, "Message");
        }

        for (int i = 0; i < expectedRoots.Length; i++)
        {
            Assert.Equal(_actualRoots[i], expectedRoots[i]);
        }
    }

    [Then(@"множество корней квадратного уравнения пустое")]
    public void SqaureEquationHasNoRoots()
    {
        Assert.Empty(_actualRoots);
    }
}