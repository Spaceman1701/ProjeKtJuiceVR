using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHandController : MonoBehaviour
{
    public GameObject hand;

    private OVRGrabber grabber;
    // Start is called before the first frame update
    void Start()
    {
        grabber = GetComponent<OVRGrabber>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabber.isGrabbing && hand.activeInHierarchy)
        {
            hand.SetActive(false);
        }
        if (!grabber.isGrabbing && !hand.activeInHierarchy)
        {
            hand.SetActive(true);
        }
    }
}
