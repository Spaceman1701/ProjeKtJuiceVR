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

    void Start()
    {
        volume = (float)System.Math.PI * diameter / 2 * height;
    }

    private void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);
        Vector3 liquidRotation = Quaternion.RotateTowards(liquidRender.transform.localRotation, inverseRotation, 60 * Time.deltaTime).eulerAngles;
        //liquidRotation.x = ClampRotationValue(liquidRotation.x, difference);
        //liquidRotation.y = ClampRotationValue(liquidRotation.y, difference);

        liquidRender.transform.localEulerAngles = liquidRotation;
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

    void Update()
    {
        LiquidData test = new LiquidData("testdata");
        AddLiquid(test, testAdd);
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
        Pos[2] = (filledVolume / volume) * 0.02f - 0.01f;
        liquidRender.transform.localPosition = Pos;
    }
}
