using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestLib.Extensions
{
public interface IRideable { void Mount(); void Start(); }
public abstract class Animal { public string Name { get; set; } }
public abstract class HorseAnimal : Animal { }
public class Zebra : HorseAnimal { }
public class Horse : HorseAnimal, IRideable
{
    public virtual void Mount()
    {
        Debug.WriteLine("Swing into the saddle");
    }
    public virtual void Start()
    {
        Debug.WriteLine("Press heels into horse's side");
    }
}
public class Elephant : Animal, IRideable
{
    public void Mount()
    {
        Debug.WriteLine("Climb the ladder");
    }
    public void Start()
    {
        Debug.WriteLine("Poke behind ears with toes");
    }
}

public static class RideableExtensions
{
    public static void Ride(this IRideable animal)
    {
        animal.Mount();
        animal.Start();
    }
}

public class WildHorse : Horse
{
    public void Catch()
    {
        Debug.WriteLine("Catch the horse with lasso");
    }
    public override void Mount()
    {
        Debug.WriteLine("Swing onto back");
    }
    public override void Start()
    {
        Debug.WriteLine("ERROR: Horse already running");
    }
}

public static class WildHorseExtensions 
{
    public static void Ride(this WildHorse horse)
    {
        horse.Catch();
        horse.Mount();
        // No need to start, the wild horse is already
        // running for it's life when someoune mounts.
    }
}
}
