using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollider : MonoBehaviour
{
    [SerializeField] GameObject bathroomDoor;

    AudioSource sound;
    [SerializeField] AudioClip unlock;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Touching Key");
            bathroomDoor.transform.rotation = Quaternion.Euler(0, 180, 0);
            bathroomDoor.GetComponent<DoorCollision>().setLock(false);
            sound.PlayOneShot(unlock);
        }
    }
}
