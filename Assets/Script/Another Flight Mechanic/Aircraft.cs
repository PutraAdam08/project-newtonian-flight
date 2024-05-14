using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Aircraft : MonoBehaviour
{
	private PlayerControls playerControls;
	
    public ControlSurfaces elevator;
	public ControlSurfaces aileronLeft;
	public ControlSurfaces aileronRight;
	public ControlSurfaces rudder;
	public Propulsion engine;

	public Rigidbody rb { get; internal set; }

	private float inputPitch;
	private float inputRoll;
	private float inputYaw;

	private float throttle = 0.0f;
	private bool yawDefined = false;

	Vector3 controlInput;
    float throttleInput;

    [SerializeField]
    private InputActionReference Throttle, Pitch, Yaw, Roll;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		playerControls = new PlayerControls();
	}

	private void Start()
	{
		if (elevator == null)
			Debug.LogWarning(name + ": Airplane missing elevator!");
		if (aileronLeft == null)
			Debug.LogWarning(name + ": Airplane missing left aileron!");
		if (aileronRight == null)
			Debug.LogWarning(name + ": Airplane missing right aileron!");
		if (rudder == null)
			Debug.LogWarning(name + ": Airplane missing rudder!");
		if (engine == null)
			Debug.LogWarning(name + ": Airplane missing engine!");

		try
		{
			Yaw.action.ReadValue<float>();
			yawDefined = true;
		}
		catch (ArgumentException e)
		{
			Debug.LogWarning(e);
			Debug.LogWarning(name + ": \"Yaw\" axis not defined in Input Manager. Rudder will not work correctly!");
		}
	}

	/*public void SetControlInput(Vector3 input) {
        controlInput = Vector3.ClampMagnitude(input, 1);
    }

    public void SetThrottleInput(float input) {
        throttleInput = input;
    }*/

	public void onThrottle(InputAction.CallbackContext context)
	{
		throttleInput = context.ReadValue<float>();
	}

	public void onYaw(InputAction.CallbackContext context)
	{
		inputYaw = context.ReadValue<float>();
	}

	public void onPitchRoll(InputAction.CallbackContext context)
	{
		var input = context.ReadValue<Vector2>();
		inputPitch = input.y;
		inputRoll = input.x;
	}

    private void Update()
    {
        if (elevator != null)
		{
			elevator.targetDeflection = -inputPitch;
		}
		if (aileronLeft != null)
		{
			aileronLeft.targetDeflection = inputRoll;
		}
		if (aileronRight != null)
		{
			aileronRight.targetDeflection = -inputRoll;
		}
		if (rudder != null && yawDefined)
		{
			// YOU MUST DEFINE A YAW AXIS FOR THIS TO WORK CORRECTLY.
			// Imported packages do not carry over changes to the Input Manager, so
			// to restore yaw functionality, you will need to add a "Yaw" axis.
			rudder.targetDeflection = -inputYaw;
		}
        
        if (engine != null)
		{
			// Fire 1 to speed up, Fire 2 to slow down. Make sure throttle only goes 0-1.
			throttle += throttleInput * Time.deltaTime;
			throttle = Mathf.Clamp01(throttle);

			engine.throttle = throttle;
		}
    }

    private float CalculatePitchG()
        {
            // Angular velocity is in radians per second.
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            Vector3 localAngularVel = transform.InverseTransformDirection(rb.angularVelocity);

            // Local pitch velocity (X) is positive when pitching down.

            // Radius of turn = velocity / angular velocity
            float radius = (Mathf.Approximately(localAngularVel.x, 0.0f)) ? float.MaxValue : localVelocity.z / localAngularVel.x;

            // The radius of the turn will be negative when in a pitching down turn.

            // Force is mass * radius * angular velocity^2
            float verticalForce = (Mathf.Approximately(radius, 0.0f)) ? 0.0f : (localVelocity.z * localVelocity.z) / radius;

            // Express in G (Always relative to Earth G)
            float verticalG = verticalForce / -9.81f;

            // Add the planet's gravity in. When the up is facing directly up, then the full
            // force of gravity will be felt in the vertical.
            verticalG += transform.up.y * (Physics.gravity.y / -9.81f);

            return verticalG;
        }
}
