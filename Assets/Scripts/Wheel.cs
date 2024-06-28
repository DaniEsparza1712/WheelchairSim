using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private WheelCollider wCollider;
    // Start is called before the first frame update
    void Start()
    {
        wCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            wCollider.motorTorque = 10;
            Debug.Log("Added torque...");
        }
    }
}
