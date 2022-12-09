using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;
    public void SwitchState(State newState)
    {
        currentState?.Exit(); // checking if null just to be safe
        currentState = newState;
        currentState.Enter();
        
    }
    void Update()
    {   
            currentState?.Tick(Time.deltaTime); // one liner If statement null conditional operater (such wow much great)           
    }


}
