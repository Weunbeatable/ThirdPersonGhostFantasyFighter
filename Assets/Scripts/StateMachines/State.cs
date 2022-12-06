using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract void Enter();

    public abstract void Tick(float deltaTime); // avoid weird movement issues regardless of framerate, going to pass in deltaTime.

    public abstract void Exit();
   
}
