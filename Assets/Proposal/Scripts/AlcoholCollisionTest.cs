using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlcoholCollisionTest : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "beer")
        {
            FindObjectOfType<DialogueManager>().alcoholCount += 1;
 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
