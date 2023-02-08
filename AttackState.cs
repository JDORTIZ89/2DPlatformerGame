using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
   
    public LayerMask hittableLayerMask;

    protected Vector2 direction;

    public UnityEvent<AudioClip> OnWeaponSound;

    [SerializeField]
    private bool showGizmos = false;


    protected override void EnterState()
    {
        agent.animationManager.ResetEvents();
        agent.animationManager.PlayAnimation(AnimationType.attack);
        agent.animationManager.OnAnimationEnd.AddListener(TransitionToIdleState);
        agent.animationManager.OnAnimationAction.AddListener(PerformAttack);

        agent.agentWeapon.ToggleWeaponVisibility(true);
        direction = agent.transform.right * (agent.transform.localScale.x > 0 ? 1 : -1);
        if (agent.groundDetector.isGrounded)
            agent.rb2d.velocity = Vector2.zero;
    }

    private void TransitionToIdleState()
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(TransitionToIdleState);
        if (agent.groundDetector.isGrounded)
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        else
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
    }

    private void PerformAttack()
    {
        OnWeaponSound?.Invoke(agent.agentWeapon.GetCurrentWeapon().weaponSwingSound);
        agent.animationManager.OnAnimationAction.RemoveListener(PerformAttack);
        agent.agentWeapon.GetCurrentWeapon().PerformAttack(agent, hittableLayerMask, direction);
    }

    protected override void ExitState()
    {
        agent.animationManager.ResetEvents();
        agent.agentWeapon.ToggleWeaponVisibility(false);
    }


    private void OnDrawGizmos()
    {
        if (Application.isPlaying == false)
            return;
        if (showGizmos == false)
            return;
        Gizmos.color = Color.red;
        var pos = agent.agentWeapon.transform.position;
        agent.agentWeapon.GetCurrentWeapon().DrawWeaponGizmo(pos, direction);
    }

    protected override void HandleAttack()
    {
        //prevent attacking
    }

    protected override void HandleJumpPressed()
    {
        //don't allow jumping
    }

    protected override void HandleJumpRelease()
    {
        
    }

    protected override void HandleMovement(Vector2 obj)
    {
        //stop flipping/rotation
    }

    public override void StateUpdate()
    {
        //prevent Update
    }

    public override void StateFixedUpdate()
    {
        //prevent FixedUpdate
    }

}
