using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsion : MonoBehaviour
{
    [Range(0, 1)]
	public float throttle = 1.0f;

	[Tooltip("How much power the engine puts out.")]
	public float thrust;

	private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(rb != null)
            rb.AddRelativeForce(Vector3.forward * thrust * throttle, ForceMode.Force);
    }
}
