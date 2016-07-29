using System;

public class PrimitiveCalculator
{
    private AdditionStrategy additionStrategy;
    private SubtractionStrategy subtractionStrategy;
    private DivisionStrategy divisionStrategy;
    private MultiplicationStrategy multiplicationStrategy;

    private IStrategy currentStrategy;

    public PrimitiveCalculator()
    {
        this.additionStrategy = new AdditionStrategy();
        this.subtractionStrategy = new SubtractionStrategy();
        this.divisionStrategy = new DivisionStrategy();
        this.multiplicationStrategy = new MultiplicationStrategy();
        this.currentStrategy = additionStrategy;
    }

    public void changeStrategy(char @operator)
    {
        switch (@operator)
        {
            case '+':
                currentStrategy = additionStrategy;
                break;
            case '-':
                currentStrategy = subtractionStrategy;
                break;
            case '/':
                currentStrategy = divisionStrategy;
                break;
            case '*':
                currentStrategy = multiplicationStrategy;
                break;
        }
    }

    public int performCalculation(int firstOperand, int secondOperand)
    {
        return currentStrategy.Calculate(firstOperand, secondOperand);
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
    static void Main(string[] args)
    {
        PrimitiveCalculator calculator = new PrimitiveCalculator();
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] commandInfo = input.Split();
            if (commandInfo[0] == "mode")
            {
                calculator.changeStrategy(commandInfo[1][0]);
            }
            else
            {
                int result = calculator.performCalculation(int.Parse(commandInfo[0]), int.Parse(commandInfo[1]));
                Console.WriteLine(result);
            }
            input = Console.ReadLine();
        }
    }
}