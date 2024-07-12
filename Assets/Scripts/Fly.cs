using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Rigidbody rb;
    public float flySpeed;

    public void FlyUp()
    {
        rb.AddForce(Vector3.up * flySpeed, ForceMode.Impulse);
    }
}
