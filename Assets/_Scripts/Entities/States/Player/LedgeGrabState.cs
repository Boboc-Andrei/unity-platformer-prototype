using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[CreateAssetMenu(fileName = "NewLedgeGrabState", menuName = "Scriptable Objects/LedgeGrabState")]
class LedgeGrabState : CharacterState {
    public AnimationClip Clip;

    public override void Enter() {
        Character.Animator.Play(Clip.name);
        Character.ApplyNormalGravityRules = false;
        Character.Body.gravityScale = 0;
        Character.Body.linearVelocity = Vector2.zero;
    }

    public override void Do() {
        if (Character.IsGrabbingLedge == 0) IsComplete = true;
        Character.GrabLedge();
    }

    public override void Exit() {
        Character.ApplyNormalGravityRules = true;
    }

    public override string ToString() {
        return "Ledge Hang";
    }
}
