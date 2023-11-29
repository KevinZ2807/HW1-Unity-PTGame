using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    public Transform FirstLook;
    public Vector3 offsetPosition;
    // Start is called before the first frame update
    void Start()
    {  
        Invoke("MoveToObject", 0.1f);
    }

    void MoveToObject() {
        transform.position = FirstLook.position + offsetPosition;
        transform.rotation = Quaternion.Euler(15, 0, 0);
    }
}
