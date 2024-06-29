using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Wheel : MonoBehaviour
{
    private WheelCollider wCollider;
    [Header("Movement Info")]
    [SerializeField]
    private float brakeTorque;
    [SerializeField]
    private float torqueSpeed;
    [SerializeField]
    private bool spinnable;
    [Header("External components")]
    [SerializeField]
    private Transform wheelModel;

    private Vector3 inputVelocity;

    [SerializeField]
    private bool rightHand;

    private Vector3 pos;
    private Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(0, 7);
        wCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        wCollider.GetWorldPose(out pos, out rot);
        wheelModel.position = pos;
    }

    public void AddTorque(){
        InputDevice handDevice;
        if(rightHand)
            handDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        else
            handDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        handDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out inputVelocity);
        wCollider.motorTorque = inputVelocity.magnitude * torqueSpeed;
    }

    public void BrakeTorque(){

    }
}
