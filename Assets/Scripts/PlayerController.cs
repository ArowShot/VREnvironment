using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 movement;
    public SteamVR_Input_Sources handType;

    private CharacterController _controller;
    private Camera _camera;
    public Transform HeadPosition;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
    }

    private double yVel;

    // Update is called once per frame
    void Update()
    {
        var pos = HeadPosition.position - transform.position;

        pos.y = 0.5f;

        _controller.center = pos;

        yVel -= 9.8 * Time.deltaTime * 0.1;
        
        if (_controller.isGrounded)
        {
            yVel = 0;
        }

        var rotationSpeed = movement.GetAxis(handType).x;
        if (Mathf.Abs(rotationSpeed) < 0.1)
        {
            rotationSpeed = 0;
        }

        var speed = movement.GetAxis(handType).y;
        if (Mathf.Abs(speed) < 0.1)
        {
            speed = 0;
        }
        var direction = HeadPosition.forward * speed * 4 * Time.deltaTime;
        direction.y = (float)yVel;
        _controller.Move(direction);
        //transform.Rotate(new Vector3(0, rotationSpeed * speed * 100 * Time.deltaTime, 0));
    }
}
