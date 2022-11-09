namespace PLC_Simulation.Services.Components.Abstracts;

public interface IComponent
{
    public Guid Id { get; set; }
    public List<IComponent>? Input { get; set; }
    public bool Output { get; set; }
    public void Execute();
}
