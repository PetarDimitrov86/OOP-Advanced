using System;

public class PrimitiveCalculator
{
    private IStrategy strategy;

    public PrimitiveCalculator() 
        : this(new AdditionStrategy())
    { 
    }

    public PrimitiveCalculator(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ChangeStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}

public class SubtractionStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand - secondOperand;
    }
}

public class AdditionStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand + secondOperand;
    }
}


public class DivisionStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand / secondOperand;
    }
}

public class MultiplicationStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand * secondOperand;
    }
}

public interface IStrategy
{
    int Calculate(int firstOperand, int secondOperand);
}

public class DependencyInversion
{
    static void Main()
    {
        PrimitiveCalculator calculator = new PrimitiveCalculator();
        IStrategy newStrategy = new AdditionStrategy();
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] commandInfo = input.Split();
            if (commandInfo[0] == "mode")
            {
                switch (commandInfo[1][0])
                {
                    case '+':
                        newStrategy = new AdditionStrategy();
                        break;
                    case '-':
                        newStrategy = new SubtractionStrategy();
                        break;
                    case '/':
                        newStrategy = new DivisionStrategy();
                        break;
                    case '*':
                        newStrategy = new MultiplicationStrategy();
                        break;
                }
                calculator.ChangeStrategy(newStrategy);
            }
            else
            {
                int result = calculator.PerformCalculation(int.Parse(commandInfo[0]), int.Parse(commandInfo[1]));
                Console.WriteLine(result);
            }
            input = Console.ReadLine();
        }
    }
}