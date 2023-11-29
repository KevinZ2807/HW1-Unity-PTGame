using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public List<GameObject> B_List = new List<GameObject>();

    private int m_MSSV = 20127218;
    bool IsRotating = false;

    public void RemoveObjectFromList(GameObject AnObject) {
        for (int i = 0; i < B_List.Count; i++) {
            if (B_List[i] == AnObject) {
                B_List.RemoveAt(i);
                break;
            }
        }
        Destroy(AnObject);
    }

    void Start()
    {
        A.SetActive(true);
        //GameObject GameObjectA = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //GameObjectA.name = "GameObject A";

        // Declare GameObjectA's position
        A.transform.position = new Vector3(0, Random.Range(10.0f, 20.0f), 0); // Random trong doan [10, 20]
    }

    void Update() {
        // PRESS SPACEBAR
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 NewPosition = new Vector3(0, Random.Range(10.0f, 10 + m_MSSV % 20.0f), 10.0f);
            GameObject clone = (GameObject)Instantiate(B, NewPosition, transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5), ForceMode.VelocityChange);
            clone.tag = "Clone_B";
            B_List.Add(clone);
        }

        // PRESS Q
        if (Input.GetKeyDown("q")) {
            Debug.Log("Q Pressed");
            StartCoroutine(DeleteAllClone());
        }

        // PRESS T
        if (Input.GetKeyDown("t")) {
            Debug.Log("T Pressed");
            IsRotating = !IsRotating;
            StartRotating(IsRotating, B_List);
        }

        // PRESS C
        if (Input.GetKeyDown("c")) {
            Debug.Log("C Pressed");
            ChangeColors(B_List);
        }

    }

    void ChangeColors(List<GameObject> aList) {
        for (int i = 0; i < B_List.Count; i++) {
                aList[i].GetComponent<RandomColorGenerator>().OnButtonPress();
            }
    }

    void StartRotating(bool IsRotating, List<GameObject> aList) {
        if (IsRotating) {
            for (int i = 0; i < aList.Count; i++) {
            // Launch object to  the air
                Vector3 offset = aList[i].GetComponent<Transform>().position;
                offset[1] = aList[i].GetComponent<Transform>().position[1] + 5;                        // LIST SOLUTION
                aList[i].GetComponent<Transform>().position = offset;

                // Start rotating
                aList[i].GetComponent<GameObjectB>().enabled = true;
            }
        } else {
            for (int i = 0; i < aList.Count; i++) {
                aList[i].GetComponent<GameObjectB>().enabled = false;
                aList[i].GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
    IEnumerator DeleteAllClone() {
        Debug.Log("Deleting");
        yield return new WaitForSeconds(2);
        for (int i = 0; i < B_List.Count; i++) {
            Destroy(B_List[i]);
            B_List.RemoveAt(i);      
            i--;
            //yield return new WaitForSeconds(.000001f);
        }
    }
}
