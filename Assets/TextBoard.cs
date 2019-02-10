using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBoard : MonoBehaviour
{

    public float score;
    public string drinkName;

    public Dictionary<string, float> steps;

    public TextMeshPro tm;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMeshPro>();
        score = 0;
        drinkName = "Alcholoic Beverage";
        steps = new Dictionary<string, float>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        string text =
            "Score: " + score + "\n" +
            "Drink: " + drinkName + "\n";
        int currentStep = 1;
        foreach (KeyValuePair<string, float> entry in steps)
        {
            string step = currentStep + ". " + entry.Key + " (" + entry.Value + " mL) \n";
            text += step;
            currentStep += 1;
        }

        tm.SetText(text);
    }

    public void SetRecipe(Recipe r)
    {
        steps = r.getRecipe();
    }
}
