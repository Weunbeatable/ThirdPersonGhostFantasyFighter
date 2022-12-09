using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{

    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed"); // storing hash for free look spee dparameter
    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");

    private const float AnimatorDampTime = 0.1f;
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) {  }
    private float timeInState = 0.0f;
    public override void Enter()
    {
        stateMachine.InputReader.TargetEvent += Ontarget;
        stateMachine.Animator.Play(FreeLookBlendTreeHash);
    }


    public override void Tick(float deltaTime)
    {
        if (stateMachine.InputReader.isAttacking) // go into attacking state if true
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine, 0));
            return;
        }
        Vector3 movement = CalculateMovement();

        Move(movement * stateMachine.FreeLookMovementSpeed, deltaTime);
        
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        } // no calculations if not moving

        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime); // setting free look hash
        FaceMovementDirection(movement, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputReader.TargetEvent -= Ontarget; // Entering free look blend tree
    }

    private void Ontarget()
    {
        if(!stateMachine.targeter.SelectTarget()) { return; }
        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
    }
    private Vector3 CalculateMovement()
    {
        Vector3 cameraForward = stateMachine.MainCameraTransform.forward;
        Vector3 cameraRight = stateMachine.MainCameraTransform.right;
        cameraForward.y = 0;// don't need to tilt camera
        cameraRight.y = 0;
        Vector3.Normalize(cameraForward); // want to ensure uniform speed in all directions
        cameraRight.Normalize();

        return cameraForward * stateMachine.InputReader.MovementValue.y + cameraRight * stateMachine.InputReader.MovementValue.x;
       
    }

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp( 
           stateMachine.transform.rotation,
           Quaternion.LookRotation(movement),
           deltaTime * stateMachine.RotationDamping);
    }
}
