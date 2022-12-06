using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerState : PlayerBaseState
{
    public TestPlayerState(PlayerStateMachine stateMachine) : base(stateMachine) {  }
    private float timeInState = 0.0f;
    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += Enter;
    }

    public override void Tick(float deltaTime)
    {
        timeInState += Time.deltaTime;
        
        Debug.Log(timeInState);
        OnJump();
    }

    private void OnJump()
    {
       
        stateMachine.SwitchState(new TestPlayerState(stateMachine)); 
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent += Exit;
    }
}
