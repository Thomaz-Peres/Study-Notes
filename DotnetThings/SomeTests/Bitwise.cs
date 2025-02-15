namespace Bitwise;

public class Bitwise
{
    public class TesteBitwise<T>
    {
        public int MyProperty { get; set; } = 1 | 2 | 3 | 4;
        public int MyPropertyint { get; set; } = (1 << 1) << 1;
        public dynamic MyPropertydynamic { get; set; } = 1 << 2 & 4;
        public object MyPropertyobject { get; set; } = new { abc =  1 << 2 & 4 };
        public string MyPropertystring { get; set; } = (1 << 2 & 4).ToString();
        public T MyPropertygenericWork { get; set; } = (T)(new { abc =  (1 << 2 ) & 4 }.ToString() as dynamic ?? string.Empty);

        // This returns a error in compiler, but not in the LSP
        // public T MyPropertygenericNotWork { get; set; } = (T)(new { abc =  (1 << 2 ) & 4 } as  object);

        // This give an error in compiler too, but not in the LSP
        //public T MyProperty2 { get; set; } = new { name = "2" } as dynamic | new { inteiro = 3 } as dynamic;
    }

    public enum TesteBitwise2
    {
        Name,
        Name2,
        Name3,
        Name4,
    }
}
