using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    public GameObject txtMngr;
    public GameObject tskMngr;

    public GameObject prkxt;
    
    private void OnTriggerEnter(Collider collision)
    {
        if(tskMngr.GetComponent<TaskManager>().taskNum == 2)
        {
            txtMngr.GetComponent<IVTextManager>().park = true;
        }
    }
}
