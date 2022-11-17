using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveVector;
    float velocity = 5.0f;
    CharacterController cc;
    PlayerInput pi;

    float moveX;
    float moveY;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        pi = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = transform.right * moveX + transform.forward * moveY;
        cc.Move(moveVector * velocity * Time.deltaTime);
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVect = input.Get<Vector2>();
        moveX = inputVect.x;
        moveY = inputVect.y;
    }
}
