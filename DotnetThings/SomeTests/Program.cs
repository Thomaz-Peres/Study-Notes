var z = new Bitwise.TesteBitwise<string>();

Console.WriteLine(z.MyProperty);
Console.WriteLine(z.MyPropertyint);
Console.WriteLine(z.MyPropertydynamic);
Console.WriteLine(z.MyPropertyobject);
Console.WriteLine(z.MyPropertystring);
Console.WriteLine(z.MyPropertygenericWork);
// Console.WriteLine(z.MyProperty2);
Console.WriteLine(Bitwise.TesteBitwise2.Name2 & Bitwise.TesteBitwise2.Name); // print small number
Console.WriteLine(Bitwise.TesteBitwise2.Name2 | Bitwise.TesteBitwise2.Name); // print higher number
Console.WriteLine(Bitwise.TesteBitwise2.Name2 | Bitwise.TesteBitwise2.Name | Bitwise.TesteBitwise2.Name3); // print the sum, and the sum is Name4, nice
Console.WriteLine(Bitwise.TesteBitwise2.Name2 | Bitwise.TesteBitwise2.Name | Bitwise.TesteBitwise2.Name3 | Bitwise.TesteBitwise2.Name4); // print the higher
Console.WriteLine(~Bitwise.TesteBitwise2.Name2);