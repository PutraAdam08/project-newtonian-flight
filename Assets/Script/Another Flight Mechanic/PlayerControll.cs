using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    /*Vector3 controlInput;
    [SerializeField]
    Aircraft plane;
    //PlaneCamera planeCamera;

    private PlayerControls playerControls;

    void awake()
    {
        playerControls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        //planeCamera = GetComponent<PlaneCamera>();
        SetPlane(plane);
    }

    void SetPlane(Aircraft plane)
    {
        this.plane = plane;

        //planeCamera.SetPlane(plane);
    }

    public void SetThrottleInput(InputAction.CallbackContext context)
    {
        if (plane == null)
            return;
        
        plane.SetThrottleInput(context.ReadValue<float>());
    }

    public void OnRollPitchInput(InputAction.CallbackContext context) {
        if (plane == null) return;

        var input = context.ReadValue<Vector2>();
        controlInput = new Vector3(input.y, controlInput.y, -input.x);
    }

    public void OnYawInput(InputAction.CallbackContext context) {
        if (plane == null) return;

        var input = context.ReadValue<float>();
        controlInput = new Vector3(controlInput.x, input, controlInput.z);
    }

    /*public void OnCameraInput(InputAction.CallbackContext context) {
        if (plane == null) return;

        var input = context.ReadValue<Vector2>();
        planeCamera.SetInput(input);
    }


    // Update is called once per frame
    void Update()
    {
        if (plane == null) return;
        plane.SetControlInput(controlInput);
    }*/
}
