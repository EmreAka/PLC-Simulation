using PLC_Simulation.Services.Components.Abstracts;
using PLC_Simulation.Services.Components.Concretes;

namespace PLC_Simulation.Services;

public class SimulationService
{
    public event EventHandler ProcessCompleted;

    private bool isRunning = false;
    public List<IComponent> Components = new List<IComponent>();
    public List<ILine> Lines = new List<ILine>();
    public Network Network = new();

    public void StopSimulation()
    {
        isRunning = false;

        foreach (var item in Components)
        {
            item.Output = false;
        }

        foreach (var item in Lines)
        {
            item.Output = false;
        }
    }

    public async Task StartSimulation()
    {
        isRunning = true;
        var i = 0;
        while (isRunning)
        {
            Task t1 =  Task.Run(RunComponents);
            Task t2 = Task.Run(RunLines);
            await Task.WhenAll(t1, t2);
            OnProcessCompleted(EventArgs.Empty);

        }
    }

    private async Task RunComponents()
    {
        await Task.Delay(1);
        foreach (var item in Components)
        {
            item.Execute();
        }
    }

    private async Task RunLines()
    {
        await Task.Delay(1);
        foreach (var item in Lines)
        {
            item.Execute();
        }
    }

    protected virtual void OnProcessCompleted(EventArgs e)
    {
        ProcessCompleted?.Invoke(this, e);
    }
}
