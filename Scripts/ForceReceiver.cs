using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float drag = 0.3f;

    private float verticalVelocity;

    private Vector3 impact;

    private Vector3 dampingVelocity; // pass by reference

    public Vector3 Movement => impact + Vector3.up * verticalVelocity; // the => is so we return a value
    private void Update()
    {
        if(verticalVelocity < 0f && controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime; // Here we are setting our velocity to that value so its a better solution than setting velocity to 0f to avoid issues with animations when falling from any height.
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; // Here we are falling so we will keep falling
        }
        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);
    }

    public void AddForce(Vector3 force)
    {
        impact += force;
    }
}
