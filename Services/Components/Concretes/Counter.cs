using PLC_Simulation.Services.Components.Abstracts;

namespace PLC_Simulation.Services.Components.Concretes;

public class Counter : ICounter
{
    public Guid Id { get; set; }
    public List<IComponent> Input { get; } = new();
    public bool Output { get; set; }

    public int CountState { get; set; }
    public int PeakCounter { get; set; }

    private bool previusInputState = false;
    public Counter()
    {
        Id = Guid.NewGuid();
    }
    public void Execute()
    {
        /*if (InputStatus())
        {
            Count();
        }
        else
        {
            previusInputState = false;
        }*/

        var result = InputStatus();
        if (result)
        {
            Count();
        }
        if (result && CountState >= PeakCounter)
        {
            Output = true;
        }
        if (!result)
        {
            Output = false;
        }
        if (result == false)
        {
            previusInputState = false;
        }
    }

    private void Count()
    {
        if (previusInputState != true)
        {
            previusInputState = true;
            CountState++;
        }
    }

    private bool InputStatus()
    {
        foreach (var item in Input)
        {
            if (item.Output == true)
            {
                return true;
            }
        }
        return false;
    }
}
