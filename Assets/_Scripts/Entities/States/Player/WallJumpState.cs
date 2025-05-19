using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName ="NewWallJumpState", menuName ="Scriptable Objects/WallJump")]
internal class WallJumpState : JumpState {

    public override void Enter() {
        base.Enter();
        Character.Body.linearVelocityX = Character.MovementParams.HorizontalTopSpeed * Character.WallJumpDirection;
        Character.DisableHorizontalMovement = true;
    }

    public override void Do() {
        base.Do();

        if(ElapsedTime > .2f) {
            Character.DisableHorizontalMovement = false;
        }
    }

    public override void Exit() {
        base.Exit();
        Character.DisableHorizontalMovement = false;
        Character.IsWallJumping = false;
    }

    public override string ToString() {
        return "Wall Jump";
    }
}