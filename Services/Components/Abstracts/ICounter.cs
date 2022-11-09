namespace PLC_Simulation.Services.Components.Abstracts;

public interface ICounter : IComponent
{
    public int CountState { get; set; }
}
