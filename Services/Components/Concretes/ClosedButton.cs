using PLC_Simulation.Services.Components.Abstracts;

namespace PLC_Simulation.Services.Components.Concretes;

public class ClosedButton : IButton
{
    public Guid Id { get; set; }
    public List<IComponent> Input { get; set; } = new();
    public bool IsOpen { get; set; } = false;
    public bool Output { get; set; } = false;
    public int X { get; set; }
    public int Y { get; set; }

    public ClosedButton()
    {
        Id = Guid.NewGuid();
    }

    public void ToggleButton()
    {
        IsOpen = !IsOpen;
    }

    public void Execute()
    {
        Output = Resolve();
    }

    private bool Resolve()
    {
        if (Input.Count == 0)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < Input.Count; i++)
            {
                Console.WriteLine(Input[i].Output);
                if (Input[i].Output == true && IsOpen == false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
