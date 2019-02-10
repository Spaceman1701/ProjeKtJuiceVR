using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Store the liquid within a cup, with methods to help mix them together and score them and shit.
public class LiquidStorage : MonoBehaviour
{
    private Dictionary<LiquidData, float> LiquidDict = new Dictionary<LiquidData, float>();
    private Color AverageColor = new Color(1,1,1,1); // Start white

    public void CalculateAverageColor(Color NewColor)
    {
        AverageColor = Color.Lerp(NewColor, AverageColor, 0.8f);

    }

    public Color GetAverageColor()
    {
        return AverageColor;
    }

    public void AddLiquid(LiquidData addedLiquid, float volume)
    {
        if (LiquidDict.ContainsKey(addedLiquid))
        {
            LiquidDict[addedLiquid] += volume;
        }
        else
        {
            LiquidDict[addedLiquid] = volume;
            CalculateAverageColor(addedLiquid.GetColor());
        }
    }

    public void RemoveLiquid(float volume)
    {
        float FromEach = volume / LiquidDict.Count;
        foreach (KeyValuePair<LiquidData, float> liquid in LiquidDict)
        {
            float UpdatedVolume = liquid.Value - FromEach;
            if (UpdatedVolume > 0)
            {
                LiquidDict[liquid.Key] = liquid.Value - FromEach;
            }
            else
            {
                LiquidDict.Remove(liquid.Key);
            }
        }

    }

    public Dictionary<LiquidData, float> GetLiquidDict()
    {
        return LiquidDict;
    }

    // Check to see if the liquid exists in the storage in the amount within the given threshold
    public bool CheckValue(LiquidData l, float amount, float threshold)
    {
        if (LiquidDict.ContainsKey(l))
        {
            return System.Math.Abs(LiquidDict[l] - amount) < threshold;
        }
        return false;
    }
}
