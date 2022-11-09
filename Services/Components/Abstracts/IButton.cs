namespace PLC_Simulation.Services.Components.Abstracts;

public interface IButton : IComponent
{
    public bool IsOpen { get; set; }
    public void ToggleButton();
    public int X { get; set; }
    public int Y { get; set; }
}