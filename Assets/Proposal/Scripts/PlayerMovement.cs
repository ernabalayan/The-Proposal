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
    float bloodAlcoholLevel = 0.1f;
    bool BACincreased = false;

    bool collidedWithBottle = false;
    GameObject collObject;
    int objectContent;

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
        rendPP.profile.TryGet(out ca);
        rendPP.profile.TryGet(out pp);
        ca.intensity.value = 0.0f;
        rendPP.enabled = false;
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

            if (alcoholContent > 2)
            {
                rendPP.enabled = true;
                if(alcoholContent % 2 == 0 && !BACincreased)
                {
                    increaseBAC();
                }

                ca.intensity.value = bloodAlcoholLevel;
                pp.distance.value = bloodAlcoholLevel;
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

    void changeDrift()
    {
        drift = driftVect;
        setDriftVector = true;
    }

    void increaseBAC()
    {
        bloodAlcoholLevel += 0.1f;
        BACincreased = true;
    }

    public void alcoholObjectColl(GameObject alcoholObj, int amount = 0)
    {
        collObject = alcoholObj;
        objectContent = amount;
    }

    void deactivateObject(GameObject objToDeactivate)
    {
        if (collObject.GetComponent<TaskCollider>())
        {
            collObject.GetComponent<TaskCollider>().FinishedTask();
        }

        objToDeactivate.SetActive(false);
        collidedWithBottle = false;
    }
}
