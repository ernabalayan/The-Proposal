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
    PlayerInput pi;
    Rigidbody rb;

    bool sprinting = false;
    const float sprintVelo = 10.0f;
    const float walkVelo = 4.0f;

    Vector3 moveDir;

    bool isJumping;
    float jumpVelo = 50.0f;
    float gravScale = 10;
    bool isGrounded;

    int alcoholContent = 0;

    bool collidedWithWashing = false;
    GameObject machine;
    bool collidedWithBottle = false;
    GameObject collObject;
    int objectContent;

    Vector3 drift = Vector3.zero;
    Vector3 driftVect = new Vector3(0.0f, 0.0f, 0.5f);
    Vector3 notDrifing = Vector3.zero;
    float driftTimer;
    float changeDirection = 2.0f;
    bool dirChanged = false;
    bool setDriftVector = false;

    float decreaseDrunk = 10.0f;
    float decDrunkTimer;

    [SerializeField] Volume rendPP;
    ChromaticAberration ca;
    PaniniProjection pp;

    [SerializeField] GameObject cam;
    float sensAdjustment = 3.5f;

    AudioSource sounds;
    [SerializeField] AudioClip drink;

    // Start is called before the first frame update
    void Start()
    {
        pi = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rendPP.profile.TryGet(out ca);
        rendPP.profile.TryGet(out pp);
        ca.intensity.value = 0.0f;
        rendPP.enabled = false;
        sounds = GetComponent<AudioSource>();
    }

    private void Update()
    { 
        if (alcoholContent >= 1)
        {
            rendPP.enabled = true;

            ca.intensity.value = Mathf.Log10(alcoholContent);
            pp.distance.value = Mathf.Log10(alcoholContent);

            //Debug.Log(decDrunkTimer);
            decDrunkTimer -= Time.deltaTime;

            while(decDrunkTimer < 0.0f)
            {
                //Debug.Log("alcohol level decreased");
                decDrunkTimer += decreaseDrunk;
                alcoholContent -= 1;
                cam.GetComponent<MouseLook>().DecreaseSens(sensAdjustment);
            }

            if (alcoholContent > 2)
            {
                //Debug.Log("drifting");
                if (!setDriftVector)
                {
                    //Debug.Log("drifting");
                    changeDrift(driftVect);
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
            else
            {
                drift = notDrifing;
            }
        }
        else
        {
            rendPP.enabled = false;
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
        else if(collidedWithWashing)
        {
            MachineSound();
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

    public void setMachineCollide(bool coll)
    {
        collidedWithWashing = coll;
    }

    public void increaseAlcoholContent(int mod)
    {
        if(mod != 0)
        {
            sounds.PlayOneShot(drink);
            decDrunkTimer = decreaseDrunk;
            setDriftVector = false;
            cam.GetComponent<MouseLook>().IncreaseSens(sensAdjustment);
            //Debug.Log("alcohol level increased: " + decDrunkTimer);
        }

        alcoholContent += mod;
    }

    void MachineSound()
    {
        machine.GetComponent<WashingMachine>().playWashingMachineSound();
    }

    void randomizeDriftTime()
    {
        changeDirection = Random.Range(0.7f, 3.5f);
        dirChanged = true;
    }

    void changeDrift(Vector3 driftVal)
    {
        drift = driftVal;
        setDriftVector = true;
    }

    public void alcoholObjectColl(GameObject alcoholObj, int amount = 0)
    {
        collObject = alcoholObj;
        objectContent = amount;
        //Debug.Log(amount);
    }

    public void machineObjColl(GameObject machineObj)
    {
        machine = machineObj;
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
