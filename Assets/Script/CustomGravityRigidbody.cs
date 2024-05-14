using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravityRigidbody : MonoBehaviour
{
    [SerializeField]
    bool floatToSleep = false;

    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float floatDelay;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(floatToSleep)
        {
            if(rb.IsSleeping())
            {
                floatDelay = 0f;
                return;
            }

            if(rb.velocity.sqrMagnitude < 0.0001f)
            {
                floatDelay += Time.deltaTime;
                if(floatDelay >= 1f)
                {
                    return;
                }
                else
                {
                    floatDelay = 0f;
                }
            }
        }

        rb.AddForce(CustomGravity.GetGravity(rb.position), ForceMode.Acceleration);
    }
}
