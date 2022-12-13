using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IVTextManager : MonoBehaviour
{
    public GameObject taskManager;
    int task;

    public bool apartment;
    public bool park;
    public bool bar;

    void Awake()
    {
        apartment = true;
    }

    void Update()
    {
        Debug.Log("apartment is " + apartment);
        Debug.Log("park is " + park);
        Debug.Log("bar is " + bar);

        task = taskManager.GetComponent<TaskManager>().taskNum;
        Debug.Log("task is " + task);

        //turns racing text off
        if(task == 1)
        {
            Debug.Log("1 is firing");
            park = false;
            bar = false;
        }

        if(task == 2)
        {
            Debug.Log("2 is firing");
            apartment = false;
            bar = false;
        }

        if(task == 3)
        {
            apartment = false;
            park = false;
        }

        if(task == 0)
        {
            apartment = false;
            park = false;
            bar = false;
        }
        
    }

    // private void OnTriggerEnter(Collider collision)
    // {
    //     if(task == 1)
    //     {
    //         if(collision.gameObject.tag == "player")
    //         {
    //             park = false;
    //             bar = false;
    //         }
    //     }

    //     if(task == 2)
    //     {
    //         if(collision.gameObject.tag == "player")
    //         {
    //             apartment = false;
    //             bar = false;
    //         }
    //     }

    //     if(task == 3)
    //     {
    //         if(collision.gameObject.tag == "player")
    //         {
    //             apartment = false;
    //             park = false;
    //         }
    //     }

        
    // }

    
}
