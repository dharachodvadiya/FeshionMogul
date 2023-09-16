using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected readonly Player player;     //player's reference
  //  private Vector3 colExtents;                             //player's colider reference

    protected PlayerBaseState(Player player)
    {
        this.player = player;
      //  colExtents = player.collider.bounds.extents;
    }

    //check player is on the ground or not
    //protected bool IsGrounded()
    //{
    //    Ray ray = new Ray(player.objPlayer.transform.position + Vector3.up * 2 * colExtents.x, Vector3.down);
    //    return Physics.SphereCast(ray, colExtents.x, colExtents.x + 0.2f);
    //}
    // calculate the player move direction
    private void CalculateMoveDirection(float h, float v, float moveSpeed, ref Vector3 lookDir)
    {
        Vector3 cameraForward = new(Vector3.forward.x, 0, Vector3.forward.z);
        Vector3 cameraRight = new(Vector3.right.x, 0, Vector3.right.z);

        Vector3 moveDirection = cameraForward.normalized * v + cameraRight.normalized * h;

       lookDir.x = moveDirection.x * moveSpeed;
        lookDir.z = moveDirection.z * moveSpeed;

        FaceMoveDirection(lookDir );
    }

    // rotate player on calculated direction
    private void FaceMoveDirection(Vector3 faceDirection)
    {
        faceDirection.y = 0;

        if (faceDirection == Vector3.zero)
            return;

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(faceDirection), player.LookRotationDampFactor * Time.deltaTime);
    }

    //move player to the target direction
    private void Move(float movespeed, ref Vector3 lookDir)
    {
        player.transform.position += lookDir * Time.deltaTime * movespeed;

    }

    protected void MoveManagement(float horizontal, float vertical, float moveSpeed, ref Vector3 lookDir)
    {
        Vector2 dir = new Vector2(horizontal, vertical);
        float speed = Vector2.ClampMagnitude(dir, 1f).magnitude;

        Move(speed, ref lookDir);
        CalculateMoveDirection(horizontal, vertical, speed*5, ref lookDir);

        player.behaviourManager.setSpeed(speed);
       
     
    }

}
