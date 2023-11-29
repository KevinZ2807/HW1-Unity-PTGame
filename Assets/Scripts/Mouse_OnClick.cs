using UnityEngine;

public class Mouse_OnClick : MonoBehaviour
{
    //Click to remove an object
    void OnMouseDown() {
        Destroy(gameObject);
        FindAnyObjectByType<GameManager>().RemoveObjectFromList(gameObject);
        FindAnyObjectByType<Points>().points++;
    }
}
