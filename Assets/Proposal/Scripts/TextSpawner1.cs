using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawner1 : MonoBehaviour
{
    public GameObject txMngr;
    public GameObject tsMngr;
    
    private void OnTriggerEnter(Collider collision)
    {
        if(tsMngr.GetComponent<TaskManager>().taskNum == 3)
        {
            if(collision.gameObject.tag == "Player")
            {
                txMngr.GetComponent<IVTextManager>().bar = true;
            }
        }
    }
}
