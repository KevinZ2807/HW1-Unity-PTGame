using UnityEngine;

public class Points : MonoBehaviour
{
    public int points = 0;
    void OnGUI() {
        //int points = 0;
        GUIStyle style = new GUIStyle();
        style.fontSize = 44;
        style.normal.textColor = Color.black;

        GUI.Label(new Rect(10, 10, 100, 20), "Points: " + points, style);
    }
}
