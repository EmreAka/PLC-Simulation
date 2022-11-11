using PLC_Simulation.Services.Components.Abstracts;
using PLC_Simulation.Services.Components.Concretes;
using PLC_Simulation.Services.Enums;

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

    public void AddButtonsToTheNetwork(ILine line)
    {
        //Existing line is editted.
        line.X2 = line.X1 + 150;

        //New component is added.
        IButton newButton = new ClosedButton() { X = (line.X2), Y = line.Y1 - 50 };
        newButton.Input.Add(line);
        Components.Add(newButton);

        //New line is added.
        ILine newLine = new Line() { X1 = (newButton.X + 60), X2 = 1500, Y1 = 100, Y2 = 100, LineType = LineType.Network };
        newLine.Input.Add(newButton);
        Lines.Add(newLine);
    }

    public void AddButtonToTheParallelLine(ILine line)
    {
        IButton newButton = new ClosedButton() { X = (line.X2), Y = line.Y1 - 50 };
        newButton.Input.Add(line);
        Components.Add(newButton);

        ILine newLine = new Line() { X1 = newButton.X + 60, X2 = newButton.X + 135, Y1 = line.Y1, Y2 = line.Y1, LineType = LineType.Serial };
        newLine.Input.Add(newButton);
        Lines.Add(newLine);
    }

    public void AddButtonToTheSerialLine(ILine line)
    {
        //Existing line is editted.
        line.X2 = line.X1 + 150;

        //New component is added.
        IButton newButton = new ClosedButton() { X = (line.X2), Y = line.Y1 - 50 };
        newButton.Input.Add(line);
        Components.Add(newButton);

        //New line in the end.
        ILine newLine = new Line() { X1 = (newButton.X + 60), X2 = newButton.X + 135, Y1 = line.Y2, Y2 = line.Y2, LineType = LineType.Serial };
        newLine.Input.Add(newButton);
        Lines.Add(newLine);
    }

    public void AddParallelLineToTheNetworkLine(ILine line)
    {
        ILine newLine = new Line() { X1 = (line.X1 + line.X2) / 2, X2 = (line.X1 + line.X2) / 2, Y1 = line.Y1, Y2 = line.Y1 + 200 };
        newLine.Input.Add(line);

        ILine newLine1 = new Line() { X1 = newLine.X1, X2 = newLine.X1 + 75, Y1 = newLine.Y2, Y2 = newLine.Y2, LineType = LineType.Parallel };
        newLine1.Input.Add(newLine);

        Lines.AddRange(new List<ILine> { newLine, newLine1 });
    }

    public void AddParallelLineToTheParallelLine(ILine line)
    {
        ILine newLine = new Line() { X1 = line.X1, X2 = line.X1, Y1 = line.Y1, Y2 = line.Y1 + 200 };
        newLine.Input.Add(line);

        ILine newLine1 = new Line() { X1 = newLine.X1, X2 = newLine.X1 + 75, Y1 = newLine.Y2, Y2 = newLine.Y2, LineType = LineType.Parallel };
        newLine1.Input.Add(newLine);

        Lines.AddRange(new List<ILine> { newLine, newLine1 });
    }
}
