using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollider : MonoBehaviour
{
    [SerializeField] GameObject Tasks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.gameObject.activeSelf)
        {
            //tell task manager that the collect key task has been completed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().setAlcoholCollide(true);
            other.GetComponent<PlayerMovement>().alcoholObjectColl(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().setAlcoholCollide(false);
            other.GetComponent<PlayerMovement>().alcoholObjectColl(null);
        }
    }
}
