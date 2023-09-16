using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{

    public GameObject objPlayer;         
    public float MovementSpeed { get; private set; } = 3f;
    public float JumpForce { get; private set; } = 5f;
    public float LookRotationDampFactor { get; private set; } = 7f;
    public InputReader InputReader { get; set; }    //input system refeence

    [HideInInspector]
    public Vector3 PlayerLookDirection = Vector3.forward;   //current direction of player

    public BehaviourManager behaviourManager;

    public bool IsCarry = false;

    private void Start()
    {
        InputReader = GetComponent<InputReader>();
        SwitchState(new PlayerMoveState(this));
        setIsCarry(false);

    }

    public void setIsCarry(bool isCarry)
    {
        IsCarry = isCarry;
        behaviourManager.setIsCarry(IsCarry);
    }
}
