namespace Records;

public class Records
{
    public record PersonRecord(string FirstName, string SecondName);

    public class BaseClass
    {
        public virtual string Name => "Base";
    }

    // Error, record not derive class, and the opposite too
    // public record DerivedRecord : BaseClass
    // {
    //     public override string Name => "Derived";
    // }

    public record BaseRecord
    {
        public virtual string Name => "BaseRedor";
    }

    public record DerivedRecord2 : BaseRecord
    {
        public override string Name => "DerivedRecord";
    }
}

// Paste this in the Program to test:

// using static Records;

// PersonRecord personRecord = new PersonRecord("Josiscleudo", "Cleudinho");
// Console.WriteLine(personRecord);

// var personRecord2 = personRecord with { FirstName = "Claidin" };
// Console.WriteLine("Person record 2" + personRecord2);
// Console.WriteLine(personRecord);


// var (FirstName, LastName) = personRecord;
// Console.WriteLine($"FirstName : {FirstName}");
// Console.WriteLine($"LastName : {LastName}");

// var x = new DerivedRecord2();
// var z = new BaseRecord();
// Console.WriteLine(z);
// Console.WriteLine(x);
