using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading;

public class RichSoilLand
{
    private int testInt;
    public double testDouble;
    protected string testString;
    private long testLong;
    protected double aDouble;
    public string aString;
    private Calendar aCalendar;
    public StringBuilder aBuilder;
    private char testChar;
    public short testShort;
    protected byte testByte;
    public byte aByte;
    protected StringBuilder aBuffer;
    private BigInteger testBigInt;
    protected BigInteger testBigNumber;
    protected float testFloat;
    public float aFloat;
    private Thread aThread;
    public Thread testThread;
    private object aPredicate;
    protected object testPredicate;
    public object anObject;
    private object hiddenObject;
    protected object fatherMotherObject;
    private string anotherString;
    protected string moarString;
    public int anotherIntBitesTheDust;
    private Exception internalException;
    protected Exception inheritableException;
    public Exception justException;
    public Stream aStream;
    protected Stream moarStreamz;
    private Stream secretStream;
}

public class HarvestingFields
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Type myType = typeof(RichSoilLand);
        while (input != "HARVEST")
        {
            switch (input)
            {
                case "protected":
                    FieldInfo[] protectedFields = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                    foreach (var protectedField in protectedFields)
                    {
                        if (protectedField.IsFamily)
                        {
                            Console.WriteLine($"{GetVisibility(protectedField)} {protectedField.FieldType.ToString().Substring(protectedField.FieldType.ToString().LastIndexOf('.') + 1)} {protectedField.Name}");
                        }
                    }
                    break;
                case "private":
                    FieldInfo[] privateFields = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                    foreach (var privateField in privateFields)
                    {
                        if (privateField.IsPrivate)
                        {
                            Console.WriteLine($"{GetVisibility(privateField)} {privateField.FieldType.ToString().Substring(privateField.FieldType.ToString().LastIndexOf('.') + 1)} {privateField.Name}");
                        }
                    }
                    break;
                case "public":
                    FieldInfo[] publicFields = myType.GetFields(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var publicField in publicFields)
                    {
                        if (publicField.IsPublic)
                        {
                            Console.WriteLine($"{GetVisibility(publicField)} {publicField.FieldType.ToString().Substring(publicField.FieldType.ToString().LastIndexOf('.') + 1)} {publicField.Name}");
                        }
                    }
                    break;
                case "all":
                    FieldInfo[] allFields = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (var field in allFields)
                    {
                        Console.WriteLine($"{GetVisibility(field)} {field.FieldType.ToString().Substring(field.FieldType.ToString().LastIndexOf('.') + 1)} {field.Name}");
                    }
                    break;
            }
            input = Console.ReadLine();
        }
    }
    public static String GetVisibility(FieldInfo accessor)
    {
        if (accessor.IsPublic)
            return "public";
        else if (accessor.IsPrivate)
            return "private";
        else if (accessor.IsFamily)
            return "protected";
        return null;
    }
}