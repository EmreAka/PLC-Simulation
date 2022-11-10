using PLC_Simulation.Services.Enums;

namespace PLC_Simulation.Services.Components.Abstracts;
public interface ILine : IComponent
{
    public int X1 { get; set; }
    public int X2 { get; set; }
    public int Y1 { get; set; }
    public int Y2 { get; set; }
    public LineType LineType { get; set; }
}