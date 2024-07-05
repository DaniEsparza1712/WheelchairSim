using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleManager : MonoBehaviour
{
    public Handle rightHandle;
    public Handle leftHandle;
    public float rotationSpeed;
    public float moveSpeed;
    private Rigidbody _rb;

    private Vector3 _destinyVector;
    private Vector3 _destinyRotation;
    private float _rotMultiplier;
    private float _moveMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_destinyRotation), 
            rotationSpeed * _rotMultiplier);
        _rb.MovePosition(transform.position + transform.forward * (moveSpeed * _moveMultiplier));
        
    }

    private float GetAngle()
    {
        var rForce = rightHandle.force * rightHandle.direction;
        var lForce = leftHandle.force * leftHandle.direction;
        var dir = Mathf.Sign(rForce + lForce);

        var rAngleVal = -45 * rForce;
        var lAngleVal = 45 * lForce;
        
        if (dir == 1)
        {
            var angle = rAngleVal + lAngleVal;
            return angle;
        }
        else
        {
            var angle = -rAngleVal - lAngleVal + 180;
            if (angle == 180)
                angle = 0;
            return angle;
        }
    }

    public void GetRotMultiplier()
    {
        var rForce = Mathf.Abs(rightHandle.force);
        var lForce = Mathf.Abs(leftHandle.force);

        _rotMultiplier = rForce + lForce;
    }

    public void GetMoveMultiplier()
    {
        var rForce = rightHandle.force * rightHandle.direction;
        var lForce = leftHandle.force * leftHandle.direction;

        _moveMultiplier = rForce + lForce;
    }

    public void GetDestinyRotation()
    {
        var angle = GetAngle();
        var currentRot = transform.eulerAngles;
        
        _destinyRotation = new Vector3(currentRot.x, currentRot.y + angle, currentRot.z);
        
    }
}
