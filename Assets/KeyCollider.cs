using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollider : MonoBehaviour
{
    [SerializeField] GameObject bathroomDoor;


    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Touching Key");
            bathroomDoor.transform.rotation = Quaternion.Euler(0, 180, 0);
            bathroomDoor.GetComponent<DoorCollision>().setLock(false);
        }
    }
}
