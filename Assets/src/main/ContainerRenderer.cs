using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerRenderer : MonoBehaviour
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
        var position = this.transform.localPosition;
        position.z = container.GetCurrentHeight();
        position.x = 0;
        position.y = 0;
        this.transform.localPosition = position;
    }
}
