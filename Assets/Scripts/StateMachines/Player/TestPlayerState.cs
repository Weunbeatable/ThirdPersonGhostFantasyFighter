using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerState : PlayerBaseState
{
    public TestPlayerState(PlayerStateMachine stateMachine) : base(stateMachine) {  }
    private float timeInState = 0.0f;
    public override void Enter()
    {
       
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;

        stateMachine.characterController.Move(movement * stateMachine.FreeLookMovementSpeed * Time.deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero) { return; } // no calculations if not moving

        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
    }


    public override void Exit()
    {
      
    }
}
