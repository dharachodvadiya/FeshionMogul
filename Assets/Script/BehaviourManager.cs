using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourManager : MonoBehaviour
{
    public float speed;
    public float speedDampTime = 0.1f;

    public Animator anim;
    protected int speedFloat;
    protected int isCarryBool;

    private void Start()
    {
        speedFloat = Animator.StringToHash("Speed");
        isCarryBool = Animator.StringToHash("IsCarry");
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
        anim.SetFloat(speedFloat, speed, speedDampTime, Time.deltaTime);
    }

    public float getSpeed()
    {
        return this.speed;
    }

    public void setIsCarry(bool IsCarry)
    {
        anim.SetBool(isCarryBool, IsCarry);
    }
}
