using System.Diagnostics;

public class Marmore
{
  public static void Main(string[] args)
  {
    var x = new teste.Teste20();

    x.Load(default);
    // Console.WriteLine(x);

    //object teste = default;

    //if (teste is null)
    //	throw new ArgumentNullException($"{nameof(teste)} {new StackTrace(new StackFrame().GetFileColumnNumber())}");
  }
}