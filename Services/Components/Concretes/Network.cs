using PLC_Simulation.Services.Components.Abstracts;

namespace PLC_Simulation.Services.Components.Concretes;

public class Network : IComponent
{
    public Guid Id { get; set; }
    public List<IComponent>? Input { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool Output { get; set; } = true;

    public void Execute()
    {
    }
}
