using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidData : MonoBehaviour
{
    public string LiquidName = "";
    public string color = "0x000000";
    public float viscosity = 0.5f;
    public LiquidData(string name)
    {
        LiquidName = name;
    }
}
