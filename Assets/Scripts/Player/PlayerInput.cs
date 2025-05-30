﻿using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 MoveInput;
    public bool Dash, Jump;
    public bool E;
    public float mouseSensitivity = 100f;
    public Vector2 MouseInput;
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
        MoveInput = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            MoveInput.z += 1;
        if (Input.GetKey(KeyCode.S))
            MoveInput.z -= 1;
        if (Input.GetKey(KeyCode.A))
            MoveInput.x -= 1;
        if (Input.GetKey(KeyCode.D))
            MoveInput.x += 1;

        E = Input.GetKey(KeyCode.E);
        Jump = Input.GetButton("Jump");
        Dash = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        MouseInput = new Vector2(mouseX, mouseY);
    }
}
