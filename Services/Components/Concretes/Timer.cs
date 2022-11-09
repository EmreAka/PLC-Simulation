using PLC_Simulation.Services.Components.Abstracts;
using PLCSimulation.Services;
using System.Timers;

namespace PLC_Simulation.Services.Components.Concretes;

public class Timer : ITimer
{
    public Guid Id { get; set; }
    public List<IComponent> Input { get; set; } = new();
    public int TimerState { get; set; }
    public bool Output { get; set; } = false;
    public Timer()
    {
        Id = Guid.NewGuid();
        Subscribe();
    }

    private void Subscribe()
    {
        SimulationTimer.Timer.Elapsed += OnTimedEvent;
    }

    public async void Execute()
    {
        if (TimerState >= 15 && InputStatus())
        {
            Output = true;
        }
        else
        {
            Output = false;
        }
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if (InputStatus() == true)
        {
            TimerState++;
            Console.WriteLine("Counter: " + TimerState);
        }
        else
        {
            TimerState = 0;
        }

    }

    private bool InputStatus()
    {
        foreach (var item in Input)
        {
            if (item.Output == true)
            {
                return true;
            }
        }
        return false;
    }
}
