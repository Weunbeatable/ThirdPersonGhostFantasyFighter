using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private float previousFrameTime; // in case we get data from final frame of previous animation

    private bool alreadyAppliedForce;

    private Attack attack; // setting a private field of type attack
    public PlayerAttackingState(PlayerStateMachine stateMachine, int AttackIndex) : base(stateMachine) // adding attack ID into constructor so we know which attack to use
    {
     attack = stateMachine.Attacks[AttackIndex]; // assigning the attack value to the attack id when we pass this information into other states in statemachine
    }


    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration); // crossfade in fixed time is better than play so we get smootheranimations
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime();
        // redundant normalizedTime >= previousFrameTime &&
        if ( normalizedTime < 1f) // if greater than previous do something. if greater than 1 animation has finished, may remove the && for animation cancel
        {
            if (stateMachine.InputReader.isAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        }
        else
        {
            if(stateMachine.targeter.currentTarget != null)
            {
                stateMachine.SwitchState (new PlayerTargetingState(stateMachine)); //switch to targeting state
            }
            else
            {
                stateMachine.SwitchState (new PlayerTargetingState(stateMachine)); // free look state
            }
        }

        if(normalizedTime > attack.ForceTime)
        {
            TryApplyForce();
        }
        previousFrameTime = normalizedTime;
    }


    public override void Exit()
    {
        
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) { return; }

        stateMachine.forceReceiver.AddForce(stateMachine.transform.forward * attack.Force);

        alreadyAppliedForce = true;
    }

    private void TryComboAttack(float normalizedTime)
    {
        if(attack.ComboStateIndex == -1) { return; } // making sure we have a combo attack

        if(normalizedTime < attack.ComboAttackTime) { return; } // ensure we are far enough through the combo to do it

        stateMachine.SwitchState // If we are far enough through switch the state to attack.
            (
                new PlayerAttackingState
                (
                    stateMachine,
                    attack.ComboStateIndex
                )
            );
        
    }

    private float GetNormalizedTime() // purpose here is to check how far through the animation and if we pass a threshold so if they player is still attacking or holding attack , go to the next animation.
    {
        // want to know the data for current and next state to figure out which one we are in whenever blending
        AnimatorStateInfo currentInfo = stateMachine.Animator.GetCurrentAnimatorStateInfo(0); // gettinig animation layer info and storing in variables
        AnimatorStateInfo nextInfo = stateMachine.Animator.GetNextAnimatorStateInfo(0);

        if (stateMachine.Animator.IsInTransition(0) && nextInfo.IsTag("Attack")) // already know we are in layer 0, so if we are in layer 0 and transitioning to an attack we want to get the data for the next state.

        {
            return nextInfo.normalizedTime;
        }
        else if (!stateMachine.Animator.IsInTransition(0) && currentInfo.IsTag("Attack")) // if not in an attack animation case
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f; // just in case none of this is true;s
        }
    }
}

   

