using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{

    private Container container;
    // Start is called before the first frame update
    void Start()
    {
        container = GetComponentInParent<Container>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        var otherManager = other.GetComponentInParent<PourManager>();
        //container.AddVolume(otherManager.GetCurrentPourRate());
        container.AddVolume(otherManager.GetDifferenceInVolume());

    }
}
