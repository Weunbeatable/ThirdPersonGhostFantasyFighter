using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    //field before serailzed will turn it into a field then serilize it for us
 [field:SerializeField] public InputReader InputReader { get; private set;} // Rules are public getting reader and privately setting it
 [field: SerializeField] public CharacterController characterController { get; private set; }
 [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
 [field: SerializeField] public float TargetingMovementSpeed { get; private set; }
 [field: SerializeField] public float RotationDamping { get; private set; } // Damping is essentially smoothing
 [field: SerializeField] public Animator Animator { get; private set; }
 [field: SerializeField] public Targeter targeter { get; private set; }
 [field: SerializeField] public ForceReceiver forceReceiver { get; private set; }
 [field: SerializeField] public Attack[] Attacks { get; private set; }
    public Transform MainCameraTransform { get; private set; }
    private  void Start()
    {
        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerFreeLookState(this));
    }

  
}
