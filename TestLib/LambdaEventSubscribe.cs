using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TestLib
{
    public static class LambdaEventSubscribe
    {
public static void Run(Stack<int> result)
{
    ScheduleAdd(result, number: 1, timeoutms: 2);
    ScheduleAdd(result, number: 2, timeoutms: 1);

    System.Threading.Thread.Sleep(20);
}

private static void ScheduleAdd(Stack<int> stack, int number, int timeoutms)
{
    var t = new Timer(timeoutms) { AutoReset = false };

    t.Elapsed += (object sender, ElapsedEventArgs eventArgs) => stack.Push(number);
    t.Enabled = true;
}
    }
}
