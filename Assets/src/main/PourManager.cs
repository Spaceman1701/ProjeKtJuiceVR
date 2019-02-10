using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourManager : MonoBehaviour
{

    public float maxRate;
    public float minRate;

    public float current;

    public Vector3 up;

    private Container container;

    // Start is called before the first frame update
    void Start()
    {
        container = GetComponent<Container>();
    }

    // Update is called once per frame
    void Update()
    {
        current = GetCurrentPourRate();
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
            float rate = Mathf.Lerp(minRate, maxRate, (x - 90) / 90);
            container.PourVolume(rate);
            return rate;
        }

        return 0;
    }
}
