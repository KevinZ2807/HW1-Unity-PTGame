using UnityEngine;

public class RandomColorGenerator : MonoBehaviour
{
    MeshRenderer mr;
    
    void Start() {
        mr = this.GetComponent<MeshRenderer>();
    }

    public void OnButtonPress() {
        Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
        mr.material.color = newColor;
    }
}
