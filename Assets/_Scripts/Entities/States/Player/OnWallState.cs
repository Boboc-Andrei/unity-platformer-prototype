using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


[CreateAssetMenu(fileName = "NewOnWallState", menuName = "Scriptable Objects/OnWallState")]
internal class OnWallState : CharacterState {
    public AnimationClip clip;
    public float GrabTime = 1f;

    public override void Enter() {
        Character.Animator.Play(clip.name);
        Character.ApplyNormalGravityRules = false;
        Character.Body.gravityScale = 0;
        Character.Body.linearVelocityY = 0;
        Character.OverrideFacingDirecion = true;
        Character.LookTowards(Character.IsTouchingWall);
    }

    public override void Do() {
        if (Character.IsGrabbingWall == 0) {
            IsComplete = true;
        }

        if (ElapsedTime >= GrabTime) {
            Character.Body.gravityScale = Character.MovementParams.WallSlideGravity;
        }
    }


    public override void Exit() {
        Character.ApplyNormalGravityRules = true;
        Character.OverrideFacingDirecion = false;
    }
}