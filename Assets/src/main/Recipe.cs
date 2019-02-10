using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{

    Dictionary<string, float> requiredVals;

    public Recipe()
    {
        requiredVals = new Dictionary<string, float>();
    }

    public void AddLiquid(string name, float val)
    {
        if (requiredVals.ContainsKey(name))
        {
            requiredVals[name] += val;
        }
        else
        {
            requiredVals[name] = val;
        }
    }

    public Dictionary<string,float> getRecipe()
    {
        return requiredVals;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
