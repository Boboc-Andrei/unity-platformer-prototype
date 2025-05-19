using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool IsTouching = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision == null) return;



        IsTouching = true;
        playerMovement.GrabbableLedgePosition = transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        IsTouching = false;
    }
}
