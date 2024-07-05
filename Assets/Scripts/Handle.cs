using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Handle : MonoBehaviour
{
    public float force;
    public float marginDistance;
    
    public float speed;
    public float snapSpeed;
    public float snapRate;
    
    private float _timer;
    public Transform origin;
    public string axis;
    public int direction;
    public UnityEvent onPosChanged;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis(axis);
        if (Mathf.Abs(input) > 0 + Mathf.Epsilon && Vector3.Distance(origin.position, transform.position) < marginDistance)
        {
            transform.Translate(transform.forward * (input * speed), Space.World);
            if(transform.hasChanged)
                PosChanged();
        }
        else if (input == 0)
            transform.position = origin.position;
        
        if (Mathf.Abs(force) > 0 + Mathf.Epsilon)
        {
            _timer += Time.deltaTime;
            if (_timer >= snapRate)
            {
                force = Mathf.Max(force - snapSpeed * Time.deltaTime, 0);
                onPosChanged.Invoke();
                _timer = 0;
            }
        }
    }

    private void PosChanged()
    {
        //Get direction
        var referenceVector = transform.InverseTransformPoint(origin.position);
        if (referenceVector.z < 0)
            direction = 1;
        else
            direction = -1;
        
        force = Mathf.Min(Vector3.Distance(origin.position, transform.position) / marginDistance, 1);
    }
}
