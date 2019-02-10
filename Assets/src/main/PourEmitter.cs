using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourEmitter : MonoBehaviour
{

    private PourManager pourManager;
    private ParticleSystem emitter;
    // Start is called before the first frame update
    void Start()
    {
        pourManager = GetComponentInParent<PourManager>();
        emitter = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float pourValue = pourManager.GetCurrentPourRate();
        var emission = emitter.emission;
        if (pourValue > 0)
        {
            emission.enabled = true;
        } else
        {
            emission.enabled = false;
        }
    }
}
