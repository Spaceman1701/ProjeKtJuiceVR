using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public float diameter;
    public float height;
    private float volume;
    private Dictionary<LiquidData, float> liquidDict = new Dictionary<LiquidData, float>();

    public float filledVolume = 0.0f;
    public GameObject liquidRender;

    public float testAdd = 0.5f;
    public int difference = 25;
    public int sloshRate = 60;


    void Start()
    {
        volume = (float)System.Math.PI * diameter / 2 * height;
    }

    void Update()
    {
        LiquidData test = new LiquidData("testdata");
        AddLiquid(test, testAdd);
        Slosh();
    }

    private void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);
        Vector3 liquidRotation = Quaternion.RotateTowards(liquidRender.transform.localRotation, inverseRotation, sloshRate * Time.deltaTime).eulerAngles;
        //liquidRotation.x = ClampRotationValue(liquidRotation.x, difference);
        // liquidRotation.y = ClampRotationValue(liquidRotation.y, difference);
        // liquidRotation.x = liquidRotation.x - 90;
        liquidRender.transform.localEulerAngles = liquidRotation;
    }

    private float ClampRotationValue(float value, float difference)
    {
        float returnVal = 0.0f;
        if (value > 180)
        {
            returnVal = Mathf.Clamp(value, 360 - difference, 360);
        }
        else
        {
            returnVal = Mathf.Clamp(value, 0, difference);
        }
        return returnVal;

    }

    void AddLiquid(LiquidData addedLiquid, float addedVolume)
    {
        if (liquidDict.ContainsKey(addedLiquid))
        {
            liquidDict[addedLiquid] += addedVolume;
        }
        else
        {
            liquidDict[addedLiquid] = addedVolume;
        }

        filledVolume += addedVolume;
        FixVolume();
        UpdateLiquidRender();
    }

    
    // TODO: Make it so that the ratios of liquids change properly here 
    void FixVolume()
    {
        if (filledVolume > volume)
        {
            //filledVolume = volume;
            filledVolume = 0;
        }
    }

    private void UpdateLiquidRender()
    {
        // liquidRender.transform.localScale.y = filledVolume / volume;
        Vector3 Pos = liquidRender.transform.localPosition;
        //Pos[2] = (filledVolume / volume) * 0.02f - 0.01f;
        Pos[1] = (filledVolume / volume) / 10;
        liquidRender.transform.localPosition = Pos;
    }
}
