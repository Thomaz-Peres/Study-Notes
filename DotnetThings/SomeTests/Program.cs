// using Bt = Bitwise;

// var z = new Bt.Bitwise.TesteBitwise<string>();

// Console.WriteLine(z.MyProperty);
// Console.WriteLine(z.MyPropertyint);
// Console.WriteLine(z.MyPropertydynamic);
// Console.WriteLine(z.MyPropertyobject);
// Console.WriteLine(z.MyPropertystring);
// Console.WriteLine(z.MyPropertygenericWork);
// // Console.WriteLine(z.MyProperty2);
// Console.WriteLine(Bt.Bitwise.TesteBitwise2.Name2 & Bt.Bitwise.TesteBitwise2.Name); // print small number
// Console.WriteLine(Bt.Bitwise.TesteBitwise2.Name2 | Bt.Bitwise.TesteBitwise2.Name); // print higher number
// Console.WriteLine(Bt.Bitwise.TesteBitwise2.Name2 | Bt.Bitwise.TesteBitwise2.Name | Bt.Bitwise.TesteBitwise2.Name3); // print the sum, and the sum is Name4, nice
// Console.WriteLine(Bt.Bitwise.TesteBitwise2.Name2 | Bt.Bitwise.TesteBitwise2.Name | Bt.Bitwise.TesteBitwise2.Name3 | Bt.Bitwise.TesteBitwise2.Name4); // print the higher
// Console.WriteLine(~Bt.Bitwise.TesteBitwise2.Name2);


using System.Text;


StreamReader srSource = new StreamReader("async-await", Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
StreamReader srDest = new StreamReader("async-await2", Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
new AsyncAwait().CopyStreamToStream(srSource, srDest);
srSource.Dispose();
srDest.Dispose();
