using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Store the liquid within a cup, with methods to help mix them together and score them and shit.
public class LiquidStorage : MonoBehaviour
{
    public Dictionary<string, float> LiquidDict;
    private Color AverageColor = new Color(1,1,1,1); // Start white

    public void Start()
    {
        LiquidDict = new Dictionary<string, float>();
    }

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
        
        if (LiquidDict.ContainsKey(addedLiquid.LiquidName))
        {
            LiquidDict[addedLiquid.LiquidName] += volume;
            Debug.Log("Adding value");
        }
        else
        {
            LiquidDict[addedLiquid.LiquidName] = volume;
            CalculateAverageColor(addedLiquid.GetColor());
        }
        Debug.Log("Added " + addedLiquid.LiquidName);

        foreach(KeyValuePair<string, float> data in LiquidDict)
        {
            Debug.Log(data.Key+", "+ data.Value);
        }
        Debug.Log("================");
    }

    public void RemoveLiquid(float volume)
    {
        float FromEach = volume / LiquidDict.Count;
        foreach (KeyValuePair<string, float> liquid in LiquidDict)
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
        Debug.Log("------Removing------------");
        foreach (KeyValuePair<string, float> data in LiquidDict)
        {
            Debug.Log(data.Key + ", " + data.Value);
        }
        Debug.Log("----------------------------");
    }

    public void ClearLiquids()
    {
        Debug.Log("Clearing dict");
        LiquidDict.Clear();
        foreach (KeyValuePair<string, float> data in LiquidDict)
        {
            Debug.Log(data.Key + ", " + data.Value);
        }
        Debug.Log("----------------------------");
    }

    public void Merge(LiquidStorage otherStorage)
    {
        Dictionary<string, float> otherDict = otherStorage.GetLiquidDict();
        // Basically add them all together
        foreach (KeyValuePair<string, float> other in otherDict)
        {
            if (LiquidDict.ContainsKey(other.Key))
            {
                LiquidDict[other.Key] += other.Value;   
            }
            else
            {
                LiquidDict[other.Key] = other.Value;
            }
        }
    }

    public Dictionary<string, float> GetLiquidDict()
    {
        return LiquidDict;
    }

    // Check to see if the liquid exists in the storage in the amount within the given threshold
    public bool CheckValue(string LiquidName, float amount, float threshold)
    {
        if (LiquidDict.ContainsKey(LiquidName))
        {
            return System.Math.Abs(LiquidDict[LiquidName] - amount) < threshold;
        }
        return false;
    }
}
