using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DummyMirror : MonoBehaviour {
    public Transform target;
    public Transform warpGateLeft;
    public Transform warpGateRight;

    public enum Mode { Contiguous, Mirrored };

    public Mode mode;
    private float warpDistance;
    private float midpoint;

    void Start() {
        midpoint = (warpGateLeft.position.x + warpGateRight.position.x) / 2;
        warpDistance = Mathf.Abs(warpGateRight.position.x - warpGateLeft.position.x);
        MirrorTargetPosition();
    }

    // Update is called once per frame
    void LateUpdate() {
        MirrorTargetPosition();
    }

    private bool IsLeftGateCloser() {
        return Vector2.Distance(target.position, warpGateLeft.position) < Vector2.Distance(target.position, warpGateRight.position);
    }

    private void MirrorTargetPosition() {
        if (mode == Mode.Mirrored) {
            float offset = target.position.x - midpoint;
            transform.position = new Vector3(midpoint - offset, target.position.y, target.position.z);
        }
        if (mode == Mode.Contiguous) {
            int direction = IsLeftGateCloser() ? 1 : -1;
            transform.position = new Vector2(target.position.x + warpDistance * direction, target.position.y);
        }
    }
}
