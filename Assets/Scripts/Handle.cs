using UnityEngine;
using UnityEngine.Events;

public class Handle : MonoBehaviour
{
    [Header("Handle Info")]
    public float force;
    public float marginDistance;
    
    [Header("Speed Info")]
    public float speed;
    public float snapSpeed;
    public float snapRate;
    private float _timer;
    [Header("Transforms")]
    public Transform origin;
    public Transform controller;
    [Header("Input")]
    public string axis;
    public int direction;
    private bool _isGrabbed = false;
    public UnityEvent onPosChanged;
    private Vector3 _prevPos;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //For axis control
        /*
        var input = Input.GetAxis(axis);
        if (Mathf.Abs(input) > 0 + Mathf.Epsilon && Vector3.Distance(origin.position, transform.position) < marginDistance)
        {
            transform.Translate(transform.forward * (input * speed), Space.World);
            if(transform.hasChanged)
                PosChanged();
        }
        else if (input == 0)
            transform.position = origin.position;
        */
        //For XR control
        if (_isGrabbed)
            SetPositionRelativeToControl();
        else
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

    public void SetGrabbed(bool grabbed)
    {
        _isGrabbed = grabbed;
    }

    public void SetPositionRelativeToControl()
    {
        var controlPosRelativeToOrigin = origin.InverseTransformPoint(controller.position);
        var handleZOffset = Mathf.Clamp(controlPosRelativeToOrigin.z, -marginDistance, marginDistance);
        Debug.Log(controlPosRelativeToOrigin);
        var handlePos = Vector3.zero;
        handlePos.z = controlPosRelativeToOrigin.z;

        handlePos = origin.TransformPoint(handlePos);

        transform.position = handlePos;
        if(Vector3.Distance(origin.InverseTransformPoint(transform.position), _prevPos) > 0.2f)
                PosChanged();
    }

    private void PosChanged()
    {
        //Get direction
        var referenceVector = transform.InverseTransformPoint(origin.position);
        if (referenceVector.z < 0)
            direction = 1;
        else
            direction = -1;
        transform.hasChanged = false;
        _prevPos = origin.InverseTransformPoint(transform.position);
        force = Mathf.Min(Vector3.Distance(origin.position, transform.position) / marginDistance, 1);
    }
}