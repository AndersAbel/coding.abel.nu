using System;

public static class Utility
{
  public static void Method(object obj)
  {
    Console.WriteLine("Utility.Method(object)");
  }  

  public static void Method(int i)
  {
    Console.WriteLine("Utility.Method(int)");
  }

  public static void DefaultMethod(int i = 42)
  {
      Console.WriteLine("Utility.DefaultMethod({0})", i);
  }
}
