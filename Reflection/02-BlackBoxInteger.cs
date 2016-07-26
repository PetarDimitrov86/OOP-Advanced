using System;
using System.Linq;
using System.Reflection;

public class BlackBoxInt
{
    private static int DefaultValue = 0;

    private int innerValue;

    private BlackBoxInt(int innerValue)
    {
        this.innerValue = innerValue;
    }

    private BlackBoxInt()
    {
        this.innerValue = DefaultValue;
    }

    private void Add(int addend)
    {
        this.innerValue += addend;
    }

    private void Subtract(int subtrahend)
    {
        this.innerValue -= subtrahend;
    }

    private void Multiply(int multiplier)
    {
        this.innerValue *= multiplier;
    }

    private void Divide(int divider)
    {
        this.innerValue /= divider;
    }

    private void LeftShift(int shifter)
    {
        this.innerValue <<= shifter;
    }

    private void RightShift(int shifter)
    {
        this.innerValue >>= shifter;
    }
}

public class BlackBoxInteger
{
    static void Main()
    {
        Type myType = typeof(BlackBoxInt);
        FieldInfo[] allFields = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        FieldInfo field = allFields.First(f => f.Name == "innerValue");

        ConstructorInfo[] nonPublicCtors = myType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
        ConstructorInfo ourConstructor = nonPublicCtors[0];
        BlackBoxInt testBlackBox = (BlackBoxInt)ourConstructor.Invoke(new object[] { 0 });

        string input = Console.ReadLine();
        while (input != "END")
        {
            int fieldValue = (int) field.GetValue(testBlackBox);
            string[] commandInfo = input.Split('_');
            switch (commandInfo[0])
            {
                case "Add":
                    field.SetValue(testBlackBox, fieldValue + int.Parse(commandInfo[1]));
                    break;
                case "Subtract":
                    field.SetValue(testBlackBox, fieldValue - int.Parse(commandInfo[1]));
                    break;
                case "Divide":
                    field.SetValue(testBlackBox, fieldValue / int.Parse(commandInfo[1]));
                    break;
                case "Multiply":
                    field.SetValue(testBlackBox, fieldValue * int.Parse(commandInfo[1]));
                    break;
                case "RightShift":
                    field.SetValue(testBlackBox, fieldValue >>= int.Parse(commandInfo[1]));
                    break;
                case "LeftShift":
                    field.SetValue(testBlackBox, fieldValue <<= int.Parse(commandInfo[1]));
                    break;
            }
            Console.WriteLine(field.GetValue(testBlackBox));
            input = Console.ReadLine();
        }
    }
}