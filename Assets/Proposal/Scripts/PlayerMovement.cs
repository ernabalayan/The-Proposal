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

    Vector3 drift = Vector3.zero;
    Vector3 driftVect = new Vector3(0.0f, 0.0f, 0.6f);
    float driftTimer;
    float changeDirection = 2.0f;
    bool setDriftVector = false;

    // Start is called before the first frame update
    void Start()
    {
        //cc = GetComponent<CharacterController>();
        pi = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if(alcoholContent > 1)
        {
            //Debug.Log("drifting");
            if(!setDriftVector)
            {
                changeDrift();
            }

            driftTimer -= Time.deltaTime;

            while(driftTimer < 0.0f)
            {
                driftTimer += changeDirection;

                //Debug.Log("Changing direction");
                drift *= -1;
            }
        }
    }

    private void FixedUpdate()
    {
        //this might help with some movement stuff: https://www.youtube.com/watch?v=f473C43s8nE
        moveDir = transform.forward * moveVector.z + transform.right * moveVector.x;   
        rb.velocity = (moveDir * velocity) + drift;
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

    void changeDrift()
    {
        drift = driftVect;
        setDriftVector = true;
    }
}
