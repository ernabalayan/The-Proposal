using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform playerTransf;

    float sens = 40f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseLook = GetLook();
        float mouseX = mouseLook.x * sens * Time.deltaTime;
        float mouseY = mouseLook.y * sens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        playerTransf.Rotate(Vector3.up * mouseX);
    }

    public Vector2 GetLook()
    {
        return Mouse.current.delta.ReadValue();
    }
}
