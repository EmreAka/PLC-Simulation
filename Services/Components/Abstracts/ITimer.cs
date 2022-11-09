namespace PLC_Simulation.Services.Components.Abstracts;
public interface ITimer : IComponent 
{
    public int TimerState { get; set; }
}
