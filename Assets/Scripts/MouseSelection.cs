using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSelection : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    // Cach 1
    /*Color currentColor;

    void Start() {
        currentColor = GetComponent<MeshRenderer>().material.color;
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Enter");
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData) {
        Debug.Log("Exit");
        GetComponent<MeshRenderer>().material.color = currentColor;
    } */

    // Cach 2
    Color currentColor;
    MeshRenderer mr;
    void Start() {
        mr = this.GetComponent<MeshRenderer>();
        currentColor = mr.material.color;
    }


    void OnMouseEnter() {

        mr.material.color = Color.red;
    }

    void OnMouseOver() {
        mr.material.color = Color.red;
    }

    void OnMouseExit() {
        mr.material.color = currentColor;
    }
}
