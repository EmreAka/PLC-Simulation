namespace PLC_Simulation.Services.Components.Abstracts;

public interface IComponent
{
    public Guid Id { get; set; }
    public List<IComponent> Input { get; }
    public bool Output { get; set; }
    public void Execute();
}
