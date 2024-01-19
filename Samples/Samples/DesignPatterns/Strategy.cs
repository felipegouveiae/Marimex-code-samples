namespace Samples.DesignPatterns;

public interface IBonusStrategy
{
    double GetBonusAmount(IEmployee employee);
}

public interface IEmployee
{
    double Salary { get; set; }
    string Country { get; set; }
}

public class BrazilStrategy : IBonusStrategy
{
    public double GetBonusAmount(IEmployee employee)
        => employee.Salary * 1.3;
}

public class EuropStrategy : IBonusStrategy
{
    public double GetBonusAmount(IEmployee employee)
        => employee.Salary * 2.5;
}

public class StrategyProvider
{
   public IBonusStrategy GetStrategy(IEmployee employee)
    {
        if (employee.Country == "BR")
            return new BrazilStrategy();

        return new EuropStrategy();
    }
}

public class BonusCalculator
{
    public double CalculateBonus(IEmployee employee)
    {
        var strategy = new StrategyProvider().GetStrategy(employee);

        return strategy.GetBonusAmount(employee);
    }
}