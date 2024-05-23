using System.Diagnostics;

namespace teste;

public class Teste20
{
  public string Load(object teste)
  {
    if (teste == null)
      throw new ArgumentNullException($"{nameof(teste)} at\n {new StackFrame().GetMethod()?.DeclaringType}\n" + 
      $"{new StackFrame().GetFileColumnNumber()}");

    return teste?.ToString() ?? "";
  }
}