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

    bool sprinting = false;
    const float sprintVelo = 7.0f;
    const float walkVelo = 3.0f;

    Vector3 moveDir;
    //Vector3 driftDir;

    bool isJumping;
    float jumpVelo = 50.0f;
    float gravScale = 10;
    bool isGrounded;

    int alcoholContent = 0;
    float bloodAlcoholLevel = 1f;
    bool BACincreased = false;

    bool collidedWithBottle = false;
    GameObject collObject;
    int objectContent;

    Vector3 drift = Vector3.zero;
    Vector3 driftVect = new Vector3(0.0f, 0.0f, 0.5f);
    float driftTimer;
    float changeDirection = 2.0f;
    bool dirChanged = false;
    bool setDriftVector = false;

    //GameObject PPvol;
    [SerializeField] Volume rendPP;
    ChromaticAberration ca;
    PaniniProjection pp;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        //cc = GetComponent<CharacterController>();
        pi = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //rendPP = GetComponent<Volume>();
        rendPP.profile.TryGet(out ca);
        rendPP.profile.TryGet(out pp);
        ca.intensity.value = 0.0f;
        rendPP.enabled = false;
    }

    private void Update()
    {
        if (alcoholContent > 1)
        {
            rendPP.enabled = true;
            /*
            if(alcoholContent % 2 == 0 && !BACincreased)
            {
                increaseBAC();
            }
            */
            ca.intensity.value = Mathf.Log10(alcoholContent);
            pp.distance.value = Mathf.Log10(alcoholContent);
            /*
            ca.intensity.value = Mathf.Log10(bloodAlcoholLevel);
            pp.distance.value = Mathf.Log10(bloodAlcoholLevel);
            //Debug.Log(Mathf.Log10(bloodAlcoholLevel));
            */

            if (alcoholContent > 2)
            {
                //Debug.Log("drifting");
                if (!setDriftVector)
                {
                    //Debug.Log("drifting");
                    changeDrift();
                }

                driftTimer -= Time.deltaTime;

                while (driftTimer < 0.0f)
                {
                    if(!dirChanged)
                    {
                        randomizeDriftTime();
                    }
                    driftTimer += changeDirection;

                    //Debug.Log(changeDirection);
                    //Debug.Log("Changing direction");
                    drift *= -1;
                    dirChanged = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (sprinting)
        {
            velocity = sprintVelo;
        }
        else
        {
            velocity = walkVelo;
        }

        rb.AddForce(Physics.gravity * (gravScale - 1) * rb.mass);

        //this might help with some movement stuff: https://www.youtube.com/watch?v=f473C43s8nE
        moveDir = transform.forward * moveVector.z + transform.right * moveVector.x;  
       // rb.velocity = (moveDir * velocity) + drift;

        if(alcoholContent >= 7)
        {
            rb.velocity = (moveDir + drift) * velocity * -1;
        }
        else
        {
            //Debug.Log(drift);
            rb.velocity = (moveDir + drift) * velocity;
        }

        if(isJumping && isGrounded)
        {
            
            rb.AddForce(Vector3.up * jumpVelo, ForceMode.Impulse);
            isJumping = false;
            isGrounded = false;
        }
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVect = input.Get<Vector2>();
        moveVector = new Vector3(inputVect.x, 0, inputVect.y);
    }

    public void OnJump()
    {
        isJumping = true;
    }

    public void OnPickUp()
    {
        if(collidedWithBottle)
        {
            increaseAlcoholContent(objectContent);
            deactivateObject(collObject);
            collObject = null;
            objectContent = 0;
        }
    }

    //this only causes the player to sprint when the button is pressed, not held
    //value is also not set back to false, perpetual sprint
    public void OnSprint()
    {
        sprinting = !sprinting;
    }

    //returns the amount of alcohol the player has ingested
    public int getAlcoholLevel()
    {
        return alcoholContent;
    }

    public void setAlcoholCollide(bool collision)
    {
        //Debug.Log("in the setter");
        collidedWithBottle = collision;
    }

    public void increaseAlcoholContent(int mod)
    {
        alcoholContent += mod;
        BACincreased = false;
    }

    void randomizeDriftTime()
    {
        changeDirection = Random.Range(0.7f, 3.5f);
        dirChanged = true;
    }

    void changeDrift()
    {
        drift = driftVect;
        setDriftVector = true;
    }

    void increaseBAC()
    {
        bloodAlcoholLevel += 1.0f;
        BACincreased = true;
    }

    public void alcoholObjectColl(GameObject alcoholObj, int amount = 0)
    {
        collObject = alcoholObj;
        objectContent = amount;
        //Debug.Log(amount);
    }

    void deactivateObject(GameObject objToDeactivate)
    {
        if (collObject.GetComponent<TaskCollider>())
        {
            collObject.GetComponent<TaskCollider>().FinishedTask();
        }
        else if(collObject.GetComponent<FlowerCollisions>())
        {
            collObject.GetComponent<FlowerCollisions>().FinishedTask();
        }

        objToDeactivate.SetActive(false);
        collidedWithBottle = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
