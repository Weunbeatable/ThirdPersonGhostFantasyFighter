using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; } 

    public event Action JumpEvent, DodgeEvent, TargetEvent, CancelEvent;

    private Controls controls;

    public bool isAttacking;
    void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this); // hooking up class to set callbacks so controls work properly

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        JumpEvent?.Invoke(); // checking for subscribers to jump event then invoking it.
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
       if(!context.performed) { return; }
        DodgeEvent?.Invoke();
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        TargetEvent?.Invoke(); // checking for subscribers to jump event then invoking it.
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        CancelEvent?.Invoke(); // checking for subscribers to jump event then invoking it.
    }

    public void OnBasicAttack(InputAction.CallbackContext context)
    {
        // TODO: Refactor this for a combo system in the future, instead of press and hold change it for press and release
        if (context.performed)
        {
            isAttacking = true;
        }
        else if (context.canceled)
        {
            isAttacking = false;
        }
    }
}
