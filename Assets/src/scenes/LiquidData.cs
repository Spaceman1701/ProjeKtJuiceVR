using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidData : MonoBehaviour
{
    public string name = "";
    public string color = "0x000000";
    public float viscosity = 0.5f;
    public LiquidData(string name)
    {
        name = name;
    }
}
