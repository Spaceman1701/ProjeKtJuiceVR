using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{

    public float maxVolume;
    public float heightRatio;
    public float zeroHeight;

    public float currentVolume;
    public float currentHeight;

    // Start is called before the first frame update
    void Start()
    {
        currentVolume = 0;
        currentHeight = zeroHeight;
    }

    // Update is called once per frame
    void Update()
    {
        currentHeight = heightRatio * currentVolume + zeroHeight;
    }

    public float GetCurrentHeight()
    {
        return currentHeight;
    }
}
