using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform playerTransf;

    float sens = 30f;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        yRotation = playerTransf.eulerAngles.y;
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseLook = GetLook();
        float mouseX = mouseLook.x * sens * Time.deltaTime;
        float mouseY = mouseLook.y * sens * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -30f, 50f);
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        playerTransf.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public Vector2 GetLook()
    {
        return Mouse.current.delta.ReadValue();
    }

    public void IncreaseSens(float incVal)
    {
        sens += incVal;
    }

    public void DecreaseSens(float decVal)
    {
        sens -= decVal;
    }
}
