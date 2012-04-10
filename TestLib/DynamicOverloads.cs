using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestLib
{
    public class Animal
    {
        public string Name { get; set; }
    }
    public class Elephant : Animal { }

public static class AnimalTransport
{
    public static void LoadAnimal(Animal animal)
    {
        Debug.WriteLine("Putting " + animal.Name + " in a cage.");
    }

    public static void LoadAnimal(Elephant elephant)
    {
        Debug.WriteLine("Loading " + elephant.Name + " on a trailer.");
    }
}

public interface ITransportationService
{
    void TransportAnimal(Animal a);
}

public class SimpleTransportation : ITransportationService
{
    public void TransportAnimal(Animal a)
    {
        AnimalTransport.LoadAnimal(a);
    }
}

public class FlexibleTransportation : ITransportationService
{
    public void TransportAnimal(Animal a)
    {
        AnimalTransport.LoadAnimal((dynamic)a);
    }
}
}
