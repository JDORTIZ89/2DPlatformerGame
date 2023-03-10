using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory : MonoBehaviour
{
    [SerializeField]
    private State Idle, Move, Fall, Climbing, GetHit, Jump, Attack, Die;

    public State GetState(StateType stateType)
        => stateType switch
        {
            StateType.Idle => Idle,
            StateType.Move => Move,
            StateType.Fall => Fall,
            StateType.Climbing => Climbing,
            StateType.GetHit => GetHit,
            StateType.Jump => Jump,
            StateType.Attack => Attack,
            StateType.Die => Die,
            _ => throw new System.Exception("State not defined" + stateType.ToString())
        };

    public void InitializeStates(Agent agent)
    {
        State[] states = GetComponentsInChildren<State>();
        foreach (var state in states)
        {
            state.InitializeState(agent);
        }
    }
}

public enum StateType
{
    Idle, Move, Fall, Climbing, Jump, Attack, Die, GetHit
}
