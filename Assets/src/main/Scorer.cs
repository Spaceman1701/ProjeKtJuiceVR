using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer
{

    public float Score(Recipe recipe, LiquidStorage liquid)
    {
        int ingredientCount = recipe.getRecipe().Count;
        int correctIngredients = 0;
        foreach (KeyValuePair<string, float> ingredient in recipe.getRecipe())
        {
            if (liquid.CheckValue(ingredient.Key, ingredient.Value, 25))
            {
                correctIngredients += 1;
            }
        }
        return correctIngredients / ingredientCount;
    }
}
