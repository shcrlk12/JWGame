using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 MoveInput;
    public bool Dash, Jump;
    public bool E;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        MoveInput = new Vector3(x, 0, z);

        Jump = Input.GetButton("Jump");
        Dash = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }
}
