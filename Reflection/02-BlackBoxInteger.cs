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

        MethodInfo[] methods = myType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] commandInfo = input.Split('_');
            object[] parameters = new object[] {int.Parse(commandInfo[1])};

            switch (commandInfo[0])
            {
                case "Add":
                    MethodInfo addMethod = methods.First(m=>m.Name == "Add");
                    addMethod.Invoke(testBlackBox, parameters);
                    break;
                case "Subtract":
                    MethodInfo subtractMethod = methods.First(m => m.Name == "Subtract");
                    subtractMethod.Invoke(testBlackBox, parameters);
                    break;
                case "Divide":
                    MethodInfo divideMethod = methods.First(m => m.Name == "Divide");
                    divideMethod.Invoke(testBlackBox, parameters);
                    break;
                case "Multiply":
                    MethodInfo multiplyMethod = methods.First(m => m.Name == "Multiply");
                    multiplyMethod.Invoke(testBlackBox, parameters);
                    break;
                case "RightShift":
                    MethodInfo rightShiftMethod = methods.First(m => m.Name == "RightShift");
                    rightShiftMethod.Invoke(testBlackBox, parameters);
                    break;
                case "LeftShift":
                    MethodInfo leftShiftMethod = methods.First(m => m.Name == "LeftShift");
                    leftShiftMethod.Invoke(testBlackBox, parameters);
                    break;
            }
            Console.WriteLine(field.GetValue(testBlackBox));
            input = Console.ReadLine();
        }
    }
}