﻿using PLC_Simulation.Services.Components.Abstracts;
using PLC_Simulation.Services.Enums;

namespace PLC_Simulation.Services.Components.Concretes;

public class Line : ILine
{
    public Guid Id { get; set; }
    public List<IComponent> Input { get; } = new();
    public bool Output { get; set; }
    public int X1 { get; set; }
    public int X2 {get; set; }
    public int Y1 { get; set; }
    public int Y2 { get; set; }
    public LineType LineType { get; set; }

    public Line()
    {
        Id = Guid.NewGuid();
    }

    public void Execute()
    {
        Output = Resolve();
    }

    private bool Resolve()
    {
        if (Input!.Count == 0)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < Input.Count; i++)
            {
                if (Input[i].Output == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
