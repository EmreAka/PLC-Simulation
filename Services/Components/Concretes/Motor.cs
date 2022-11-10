using PLC_Simulation.Services.Components.Abstracts;

namespace PLC_Simulation.Services.Components.Concretes;

public class Motor : IMotor
{
    public Guid Id { get; set; }
    public List<IComponent> Input { get; } = new();

    public bool Output { get; set; }

    public Motor()
    {
        Id = Guid.NewGuid();
    }

    public void Execute()
    {
    }
}
