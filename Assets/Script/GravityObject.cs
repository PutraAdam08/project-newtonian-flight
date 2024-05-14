using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    public Transform gravityTarget;
    public float targetMass = 10000000;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateGravity();
    }

    void CalculateGravity()
    {
        float sqrDst = (transform.position - gravityTarget.position).sqrMagnitude;
        Vector3 diff = transform.position - gravityTarget.position;
        float gravity = (0.0000000000667f*targetMass)/sqrDst;
        Vector3 GravForce = (-diff.normalized * gravity * rb.mass);
        rb.AddForce(GravForce);
    }
}
