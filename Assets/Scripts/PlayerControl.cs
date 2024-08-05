using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float mouseSensitivity = 100.0f;
    public Camera firstPersonCamera;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // movimiento
        float moveForwardBackward = Input.GetAxis("Vertical") * movementSpeed;
        float moveSideways = Input.GetAxis("Horizontal") * movementSpeed;
        moveForwardBackward *= Time.deltaTime;
        moveSideways *= Time.deltaTime;
        transform.Translate(moveSideways, 0, moveForwardBackward);

        // rotacion de camara
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        firstPersonCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
