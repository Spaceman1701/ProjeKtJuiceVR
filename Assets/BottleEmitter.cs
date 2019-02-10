using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEmitter : MonoBehaviour
{

    public string name;
    public Color color;

    public float minRate;
    public float maxRate;

    public float volDiff;

    public Vector3 up;

    private ParticleSystem emitter;


    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var current = GetCurrentPourRate();
        volDiff += current;

         
        var emission = emitter.emission;
        if (current > 0)
        {
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }

    public float GetDifferenceInVolume()
    {
        float oldDiff = volDiff;
        volDiff = 0;
        return oldDiff;

    }

    public float GetCurrentPourRate()
    {

        float x = (transform.eulerAngles.x - up.x) % 360;


        if (x < 0)
        {
            x += 360;
        }

        if (x > 90)
        {
            return Mathf.Lerp(minRate, maxRate, (x - 90) / 90);
        }
        

        return 0;
    }
}
