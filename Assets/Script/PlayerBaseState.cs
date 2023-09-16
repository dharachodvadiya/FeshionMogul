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
    protected void CalculateMoveDirection()
    {
        Vector3 cameraForward = new(Vector3.forward.x, 0, Vector3.forward.z);
        Vector3 cameraRight = new(Vector3.right.x, 0, Vector3.right.z);

        Vector3 moveDirection = cameraForward.normalized * player.InputReader.MoveComposite.y + cameraRight.normalized * player.InputReader.MoveComposite.x;

        player.PlayerLookDirection.x = moveDirection.x * player.MovementSpeed;
        player.PlayerLookDirection.z = moveDirection.z * player.MovementSpeed;
    }

    // rotate player on calculated direction
    protected void FaceMoveDirection()
    {
        Vector3 faceDirection = player.PlayerLookDirection;
        faceDirection.y = 0;

        if (faceDirection == Vector3.zero)
            return;

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(faceDirection), player.LookRotationDampFactor * Time.deltaTime);
    }

    //move player to the target direction
    protected void Move()
    {
        player.transform.position += player.PlayerLookDirection * Time.deltaTime * player.MovementSpeed;

    }

}
