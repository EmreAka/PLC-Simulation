using PLC_Simulation.Services.Components.Abstracts;

namespace PLC_Simulation.Services.Components.Concretes;

public class OpenButton : IButton
{
    public List<IComponent> Input { get; } = new();
    public bool Output { get; set; } = false;
    public Guid Id { get; set; }
    public bool IsOpen { get; set; }
    public int X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public OpenButton()
    {
        Id = Guid.NewGuid();
    }

    public void ToggleButton()
    {
        throw new NotImplementedException();
    }

    public void Execute()
    {
    }
}
