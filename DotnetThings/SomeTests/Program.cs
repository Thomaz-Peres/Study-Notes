using System;
using System.Reflection;

internal partial class Program
{
    static void PrintTypeFields(Type t)
    {
        FieldInfo[] fields = t.GetFields(
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);
        foreach (FieldInfo f in fields)
        {
            Console.WriteLine(
                $"{f.Name} (of type {f.FieldType}): " +
                $"private? {f.IsPrivate} / static? {f.IsStatic}");
        }
    }

    static void Main(string[] args)
    {
        Type t = typeof(TestClass);
        PrintTypeFields(t);
    }
}

public class TestClass
{
    // fields
    private int _myPrivateInt;
    private string? _myPrivateString;
    public bool myPublicBool;
    public float myStaticFloat;

    // properties
    public int DoubleMyPrivateInt => _myPrivateInt * 2;
    public string? MyPrivateString
    {
        get => _myPrivateString;
        set
        {
            _myPrivateString = value;
        }
    }
}