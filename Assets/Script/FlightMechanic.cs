using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightMechanic : MonoBehaviour
{
    public float responsiveness = 10f;
    public float force = 100f;
    public float minValue = 0.0f; // minimum value for myValue
    public float maxValue = 100.0f; // maximum value for myValue
    public float throttle = 0.0f;
    private float pitchInput;
    private float yawInput;
    private float rollInput;        
    private float ThrottleInput;
    public float rollSpeed = 10.0f; // speed of the rolling movement
    public float pitchSpeed = 10.0f; // speed of the pitching movement
    public float yawSpeed = 10.0f; // speed of the yawing movement
    public float glideForce = 0.5f; // the force to simulate gliding
    public float horizontalVelocity;
    public float velocitytest;
    public float lift;
    public float liftForce;

    private Rigidbody rb;
    
    [SerializeField]
    private InputActionReference Throttle, Pitch, Yaw, Roll;


    private float ResponseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //localForward = transform.InverseTransformDirection(Vector3.forward); // Get the local forward direction of the object
        //localUp = transform.InverseTransformDirection(Vector3.up); // Get the local up direction of the object
    }

    // Update is called once per frame
    private void HandleInputs()
    {
        pitchInput = Pitch.action.ReadValue<float>();
        yawInput = Yaw.action.ReadValue<float>();
        rollInput = Roll.action.ReadValue<float>();
        ThrottleInput = Throttle.action.ReadValue<float>();

        throttle += ThrottleInput * Time.deltaTime* 10f;
        throttle = Mathf.Clamp(throttle, 0f, 100f);

    }

    private void Update() 
    {
        HandleInputs();
        velocitytest = rb.velocity.y;
    }

    private void FixedUpdate() 
    {
        rb.AddRelativeForce(throttle * force *Vector3.forward);

        horizontalVelocity = rb.velocity.magnitude * Mathf.Cos(Vector3.Angle(rb.velocity, transform.forward));

        rb.AddForce(Vector3.up * rb.velocity.magnitude * 135f);

        rb.AddTorque(transform.up * yawInput * ResponseModifier);
        rb.AddTorque(transform.right * pitchInput * ResponseModifier);
        rb.AddTorque(transform.forward * rollInput * ResponseModifier);

    }   
}
