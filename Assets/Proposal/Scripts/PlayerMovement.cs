using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveVector;
    float velocity = 3.0f;
    //CharacterController cc;
    PlayerInput pi;
    Rigidbody rb;

    Vector3 moveDir;

    int alcoholContent = 0;

    // Start is called before the first frame update
    void Start()
    {
        //cc = GetComponent<CharacterController>();
        pi = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        moveDir = transform.forward * moveVector.z + transform.right * moveVector.x;   
        rb.velocity = moveDir * velocity;
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVect = input.Get<Vector2>();
        moveVector = new Vector3(inputVect.x, 0, inputVect.y);
    }

    public void increaseAlcoholContent(int mod)
    {
        alcoholContent += mod;
    }
}
