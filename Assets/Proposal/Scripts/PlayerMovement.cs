using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveVector;
    float velocity = 3.0f;
    //CharacterController cc;
    PlayerInput pi;
    Rigidbody rb;

    Vector3 moveDir;
    //Vector3 driftDir;

    int alcoholContent = 0;

    Vector3 drift = Vector3.zero;
    Vector3 driftVect = new Vector3(0.0f, 0.0f, 0.7f);
    float driftTimer;
    float changeDirection = 2.0f;
    bool setDriftVector = false;

    //GameObject PPvol;
    [SerializeField] Volume rendPP;
    ChromaticAberration ca;
    PaniniProjection pp;

    // Start is called before the first frame update
    void Start()
    {
        //cc = GetComponent<CharacterController>();
        pi = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //rendPP = GetComponent<Volume>();
        //use this to figure out changing stuff through code: https://forum.unity.com/threads/how-to-modify-post-processing-profiles-in-script.758375/
        rendPP.profile.TryGet(out ca);
        rendPP.profile.TryGet(out pp);
        ca.intensity.value = 0.0f;
        rendPP.enabled = false;
    }

    private void Update()
    {
        if(alcoholContent > 1 && alcoholContent <= 2)
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
        else if(alcoholContent > 2)
        {
            rendPP.enabled = true;
            ca.intensity.value = 0.5f;
            pp.distance.value = 0.3f;
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
