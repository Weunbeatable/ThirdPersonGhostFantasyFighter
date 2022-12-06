using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public event Action JumpEvent, DodgeEvent;
    private Controls controls;
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
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) { return; }
        JumpEvent?.Invoke(); // checking for subscribers to jump event then invoking it.
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
       if(context.performed) { return; }
        DodgeEvent?.Invoke();
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }


}
