using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Score(Recipe recipe, LiquidStorage liquid)
    {
        int ingredientCount = recipe.getRecipe().Count;
        int correctIngredients = 0;
        foreach (var ingredient in recipe.getRecipe())
        {
            if (liquid.CheckValue(ingredient.Key, ingredient.Value, 25))
            {
                correctIngredients += 1;
            }
        }
        return correctIngredients / ingredientCount;
    }
}
