using UnityEngine;

public class GameObjectB : MonoBehaviour
{
    public Rigidbody rb;

    void Update() {
        rb.useGravity = false;
        transform.Rotate(10 * Vector3.right);
    }

}
