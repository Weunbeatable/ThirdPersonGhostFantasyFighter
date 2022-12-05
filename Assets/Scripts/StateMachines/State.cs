using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract void Enter();

    public abstract void Tick(float deltaTime); // avoid weird movement issues regardless of framerate, going to pass in deltaTime.

    public abstract void Exit();
    public void SwitchState(State newState)
    {
        switch (newState) {
           
            case(State)
        Exit();
        Tick(Time.deltaTime);
        Enter();

        }
    }
}
