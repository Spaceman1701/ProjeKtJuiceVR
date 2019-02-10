using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourManager : MonoBehaviour
{

    public float maxRate;
    public float minRate;

    public float current;
    private float VolDiff = 0;

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
        VolDiff += current;
        container.PourVolume(current);
    }

    public float GetDifferenceInVolume()
    {
        float oldDiff = VolDiff;
        VolDiff = 0;
        return oldDiff;

    }

    public float GetCurrentPourRate()
    {
        if (container.GetCurrentVolume() > 0)
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
        }
        

        return 0;
    }
}
