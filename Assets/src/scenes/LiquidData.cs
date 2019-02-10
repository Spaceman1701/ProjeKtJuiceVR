using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidData
{
    public string LiquidName = "";
    public Color color;
    public float viscosity = 0.5f;
    public LiquidData(string name, Color c)
    {
        LiquidName = name;
        color = c;
    }

    public Color GetColor()
    {
        return color;
    }
}
