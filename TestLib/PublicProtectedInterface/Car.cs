using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestLib.PublicProtectedInterface
{
    public class Key
    {
        public int KeySignature { get; set; } 
    }

abstract class Car
{
    private static Random keyGenerator = new Random();

    private readonly int keySignature = keyGenerator.Next();
        
    public string Driver { get; set; }

    public void Start(Key key)
    {
        CheckSeat();
        CheckMirrors();
        if (BeforeStartEngine != null)
        {
            BeforeStartEngine(this, new EventArgs());
        }
        StartEngine(key);
    }

    public event EventHandler<EventArgs> BeforeStartEngine;

    protected bool IsKeyApproved(Key key)
    {
        return key.KeySignature == keySignature;
    }

    protected abstract void StartEngine(Key key);

    protected virtual void CheckSeat()
    {
        Debug.WriteLine("Checking seat settings for driver {0}", Driver);
    }

    protected virtual void CheckMirrors()
    {
        Debug.WriteLine("Checking mirrors settings for driver {0}", Driver);
    }
}
}
