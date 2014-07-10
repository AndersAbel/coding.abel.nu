using System;

public static class Utility
{
  public static void Method(object obj)
  {
    Console.WriteLine("Utility.Method(object)");
  }  

  public static void DefaultMethod(int i = 7)
  {
    Console.WriteLine("Utility.DefaultMethod({0})", i);
  }
}
