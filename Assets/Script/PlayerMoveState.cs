using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(Player player) : base(player) { }
    public override void Enter()
    {
    }

    public override void Exit()
    {
        
    }

    public override void Run()
    {
        MoveManagement(player.InputReader.MoveComposite.x, player.InputReader.MoveComposite.y, player.MovementSpeed, ref player.PlayerLookDirection);
    }
}
