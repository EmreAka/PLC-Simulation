using System.Timers;

namespace PLCSimulation.Services;

public static class SimulationTimer
{
    public static System.Timers.Timer Timer;
    public static void StartTimer()
    {
        Timer = new System.Timers.Timer(1000);
        //Timer.Elapsed += OnTimedEvent;
        Timer.AutoReset = true;
        Timer.Enabled = true;
    }

    public static void StopTimer()
    {
        Timer.Stop();
    }

    //private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    //{
    //    Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
    //                      e.SignalTime);
    //}
}
