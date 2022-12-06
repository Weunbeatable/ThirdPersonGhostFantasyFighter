using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    //field before serailzed will turn it into a field then serilize it for us
 [field:SerializeField] public InputReader InputReader { get; private set;} // Rules are public getting reader and privately setting it
 [field: SerializeField] public CharacterController characterController { get; private set; }
    [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
    private  void Start()
    {
        SwitchState(new TestPlayerState(this));
    }

  
}
