using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRecipes : MonoBehaviour
{
    private Recipe currentRecipe;
    List<LiquidData> AllLiquids = new List<LiquidData>();
    public int volume = 156;

    // Start is called before the first frame update
    void Start()
    {
        AllLiquids.Add(new LiquidData("whiskey", new Color(0.65f, 0.16f, 0.16f, 0.7f)));
        AllLiquids.Add(new LiquidData("vodka", new Color(1f, 1f, 1f, 0.4f)));
        AllLiquids.Add(new LiquidData("coke", new Color(0.65f, 0.16f, 0.16f, 0.7f)));
        AllLiquids.Add(new LiquidData("lemoncella", new Color(0.65f, 0.16f, 0.16f, 0.7f))); // Change color
        AllLiquids.Add(new LiquidData("brandy", new Color(0.65f, 0.16f, 0.16f, 0.7f)));
        AllLiquids.Add(new LiquidData("tequila", new Color(0.9f, 0.9f, 0.9f, 0.7f))); 
        AllLiquids.Add(new LiquidData("rum", new Color(0.65f, 0.16f, 0.16f, 0.9f)));
        AllLiquids.Add(new LiquidData("soda water", new Color(1f, 1f, 1f, 0.3f)));
        AllLiquids.Add(new LiquidData("wine", new Color(1f, 0.16f, 0.16f, 1f))); // Change color probs
    }

   
    public Recipe GetRecipe()
    {
        return currentRecipe;
    }
    
    public void GenerateNewRecipe()
    {
        System.Random random = new System.Random();
        int count = random.Next(1, AllLiquids.Count);
        int totVol = 0;
        int liquidCount = 0;
        while (totVol < volume && liquidCount < count)
        {
            int randInd = random.Next(0, count);
            string randLiquid = AllLiquids[randInd].LiquidName;
            int randVol = random.Next(0, volume);
            currentRecipe.AddLiquid(randLiquid, randVol);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
