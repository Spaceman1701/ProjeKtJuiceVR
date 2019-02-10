using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public float diameter;
    public float height;
    private float volume;

    public float filledVolume = 0.0f;
    public GameObject liquidRender;


    public float testAdd = 0.5f;
    public int difference = 25;
    public int sloshRate = 60;

    private LiquidStorage savedLiquidStorage;

    private LiquidStorage storage;
    private int count = 0;

    void Start()
    {
        storage = GetComponent<LiquidStorage>();
        volume = (float)System.Math.PI * diameter / 2 * height;
    }

    void Update()
    {
        if (testAdd != 0)
        {
            if (count == 5)
            {
                AddVolume(new LiquidData("MMM", new Color(0, 0, 0, 1)), testAdd);
            }

            count++;
            LiquidData test = new LiquidData("testdata", new Color(1, 1, 1, 1));
            AddVolume(test, testAdd);
        }
        FixVolume();
        // Slosh();
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

    public float GetCurrentVolume()
    {
        return filledVolume;
    }

    public void AddVolume(LiquidData addedLiquid, float addedVolume)
    {
        savedLiquidStorage = null;
        filledVolume += addedVolume;
        FixVolume();
        UpdateLiquidRender();
        if (filledVolume != volume)
        {
            storage.AddLiquid(addedLiquid, addedVolume);
        }
    }

    public void AddVolumeStorage(LiquidStorage addedLiquid, float addedVolume)
    {
        savedLiquidStorage = null;
        filledVolume += addedVolume;
        FixVolume();
        UpdateLiquidRender();
        if (filledVolume != volume)
        {
            storage.Merge(addedLiquid);
        }
    }

    public void PourVolume(float removedVolume)
    {
        // Actually remove the volume
        filledVolume -= removedVolume;
        savedLiquidStorage = storage; // Basically just save the liquid when it starts spilling out because whatever scoring is hard
        UpdateLiquidRender();
        // storage.RemoveLiquid(removedVolume);
    }

    void FixVolume()
    {
        
        if (filledVolume <= 0)
        {
            filledVolume = 0;
            storage.ClearLiquids();
            UpdateLiquidRender();
        }

        if (filledVolume > volume)
        {
            filledVolume = volume;
        }
    }

    public LiquidStorage GetLiquidStorage()
    {
        return storage;
    }



    private void UpdateLiquidRender()
    {
        // liquidRender.transform.localScale.y = filledVolume / volume;
        Vector3 Pos = liquidRender.transform.localPosition;
        //Pos[2] = (filledVolume / volume) * 0.02f - 0.01f;
        Pos[1] = (filledVolume / volume) / 10;
        liquidRender.transform.localPosition = Pos;
    }

    public float GetTotalVolume()
    {
        return volume;
    }

}