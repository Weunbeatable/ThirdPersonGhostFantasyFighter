using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    //Purpose:
    /*
     * This script is to allow for shared methods between different player states
     * A reference to player so all player states can reference player
     */
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector3 motion, float deltaTime) // movement based on input and taking in delta time.
    {
        stateMachine.characterController.Move((motion + stateMachine.forceReceiver.Movement) * deltaTime); // whenever we move the player with forces we just call this method, to take the amount we want to move by added with our forces

    }

    protected void Move(float deltaTime)
    {
        stateMachine.characterController.Move((stateMachine.forceReceiver.Movement) * deltaTime);
        Move(Vector3.zero, deltaTime); // Will ensure non moving states like blocking will still allow for knockback and moving with gravity and not input
        FaceTarget();
    }

    protected void FaceTarget()
    {
        if(stateMachine.targeter.currentTarget == null) { return; } // make sure we have a target
        Vector3 facing = (stateMachine.targeter.currentTarget.transform.position - stateMachine.transform.position); // subtract target from our postion
        facing.y = 0;// dont care about height so we clear it

        stateMachine.transform.rotation = Quaternion.LookRotation(facing); // creating a vector 3 to a quaternion
    }
}
