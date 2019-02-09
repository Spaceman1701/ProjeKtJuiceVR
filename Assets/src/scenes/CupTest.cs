using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTest : MonoBehaviour
{
    public GameObject liquid; 
    private int sloshSpeed = 60;
    private int difference = 25;
    // Update is called once per frame
    void Update()
    {
        Slosh();
    }

    private void Slosh(){
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);
        Vector3 liquidRotation = Quaternion.RotateTowards(liquid.transform.localRotation, inverseRotation, 60*Time.deltaTime).eulerAngles;
        //liquidRotation.x = ClampRotationValue(liquidRotation.x, difference);
        //liquidRotation.y = ClampRotationValue(liquidRotation.y, difference);

        liquid.transform.localEulerAngles = liquidRotation;
    }

    private float ClampRotationValue(float value, float difference){
        float returnVal = 0.0f;
        if (value > 180){
            returnVal = Mathf.Clamp(value, 360-difference, 360);
        }
        else{
            returnVal = Mathf.Clamp(value, 0, difference);
        }
        return returnVal;
        
    }
}
