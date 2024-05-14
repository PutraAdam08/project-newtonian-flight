using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour
{
    [SerializeField] Transform Cam;
    [SerializeField] float speed;

    private Vector3 target;

    private void Update() 
    {
        target = Cam.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.forward = Cam.forward;
    }
}
