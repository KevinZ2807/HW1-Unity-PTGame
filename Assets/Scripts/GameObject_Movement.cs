using UnityEngine;

public class GameObject_Movement : MonoBehaviour
{
    public float Speed;
    public float TurnSpeed;
    private float m_MSSV_Speed = 2 + 20127218 % 10;

    bool IfTurning = false;
    bool IsMoving = false;
    Vector3 AutoMoving;

    void Update()
    {
        // WASD Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x*Speed, 0, z*Speed);
        transform.Translate(movement * Time.deltaTime);

        // PRESS R
        if (Input.GetKeyDown("r")) {
            IfTurning = !IfTurning;
        }

        if (IfTurning) {
            transform.Rotate(TurnSpeed * Vector3.up);
        }
        
        // PRESS M
        if (Input.GetKeyDown("m")) {
            Debug.Log("M Pressed");
            IsMoving = !IsMoving;
            if (!IsMoving) {
                AutoMoving = new Vector3(0, 0, 0);
            }
            if (IsMoving) {
                int GenerateNumber = Random.Range(1, 4);
                Debug.Log(GenerateNumber);
                switch(GenerateNumber) {
                    case 1:
                        AutoMoving = new Vector3(1*m_MSSV_Speed, 0, 0);
                        break;
                    case 2:
                        AutoMoving = new Vector3(0, 1*m_MSSV_Speed, 0);
                        break;
                    case 3:
                        AutoMoving = new Vector3(0, 0, 1*m_MSSV_Speed);
                        break;
                }
            }

        }

        transform.Translate(0.2f *AutoMoving * Time.deltaTime);
    }
}
