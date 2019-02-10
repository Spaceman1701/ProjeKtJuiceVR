using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{

    //private Container container;
    private Cup cup;
    // Start is called before the first frame update
    void Start()
    {
        //container = GetComponentInParent<Container>();
        cup = GetComponentInParent<Cup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        var otherManager = other.GetComponentInParent<PourManager>();
        //container.AddVolume(otherManager.GetCurrentPourRate());
        LiquidData TestLiquid = new LiquidData("Test"); // Temp placeholder for liquid type
        cup.AddVolume(TestLiquid, otherManager.GetDifferenceInVolume());

    }
}
