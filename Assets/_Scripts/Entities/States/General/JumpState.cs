
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "NewJumpState", menuName = "Scriptable Objects/JumpState")]
internal class JumpState : CharacterState {

    public override void Enter() {
    }

    public override void Do() {
        if (Character.Body.linearVelocityY <= 0 || Character.IsGrounded) {
            Character.IsJumping = false;
            IsComplete = true;
        }
        else if (Character.Input.CancelJump) {
            Character.Body.linearVelocityY *= Character.MovementParams.JumpCutoffFactor;
            Character.IsJumping = false;
            IsComplete = true;
        }
    }

    public override void Exit() {
    }

    public override string ToString() {
        return "Jumping";
    }
}