var z = new Bitwise.TesteBitwise<string>();

Console.WriteLine(z.MyProperty);
Console.WriteLine(z.MyPropertyint);
Console.WriteLine(z.MyPropertydynamic);
Console.WriteLine(z.MyPropertyobject);
Console.WriteLine(z.MyPropertystring);
Console.WriteLine(z.MyPropertygenericWork);
// Console.WriteLine(z.MyProperty2);
Console.WriteLine(Bitwise.TesteBitwise2.Name2 & Bitwise.TesteBitwise2.Name);
Console.WriteLine(Bitwise.TesteBitwise2.Name2 | Bitwise.TesteBitwise2.Name);
Console.WriteLine(~Bitwise.TesteBitwise2.Name2);