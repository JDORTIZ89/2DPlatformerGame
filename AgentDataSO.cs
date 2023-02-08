using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AgentData", menuName ="Agent/Data")]

public class AgentDataSO : ScriptableObject
{
    [Header("Movement data")]
    [Space]
    public int health = 2;


    [Header("Movement data")]
    [Space]
    public float acceleration;
    public float deceleration;
    public float maxSpeed;

    [Header("Jump data")]
    [Space]
    public float jumpForce = 12;
    public float lowJumpMultiplier = 2;
    public float gravityModifier = 0.5f;

    [Header("Climb data")]
    [Space]
    public float climbHorizontalSpeed = 2;
    public float climbVerticalSpeed = 5;

}
