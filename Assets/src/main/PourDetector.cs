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
        if (other.GetComponent<PourEmitter>() != null)
        {
            var otherManager = other.GetComponentInParent<PourManager>();
            var cup = other.GetComponentInParent<Cup>();
            //container.AddVolume(otherManager.GetCurrentPourRate());
            cup.AddVolumeStorage(cup.GetLiquidStorage(), otherManager.GetDifferenceInVolume());
        } else
        {
            var bottle = other.GetComponent<BottleEmitter>();
            LiquidData lq = new LiquidData(bottle.name, bottle.color);
            cup.AddVolume(lq, bottle.GetDifferenceInVolume());
        }


    }
}
