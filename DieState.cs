using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    public float timeToWaitBeforeDieAction = 2;
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.die);
        agent.animationManager.OnAnimationEnd.AddListener(WaitBeforeDieAction);
        agent.rb2d.velocity = new Vector2(0, agent.rb2d.velocity.y);
    }

    protected override void HandleJumpPressed()
    {
        //prevent
    }

    public override void GetHit()
    {
       //prevent
    }

    public override void StateUpdate()
    {

        agent.rb2d.velocity = new Vector2(0, agent.rb2d.velocity.y);
        //prevent
    }

    private void WaitBeforeDieAction()
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(WaitBeforeDieAction);
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(timeToWaitBeforeDieAction);
        agent.OnAgentDie?.Invoke();
    }

    protected override void ExitState()
    {
        StopAllCoroutines();
        agent.animationManager.ResetEvents();
    }

}
