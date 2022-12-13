using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : MonoBehaviour
{
    //GameObject player;
    AudioSource sound;
    [SerializeField] AudioClip washingMachSound;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().setMachineCollide(true);
            other.gameObject.GetComponent<PlayerMovement>().machineObjColl(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().setMachineCollide(false);
            other.gameObject.GetComponent<PlayerMovement>().machineObjColl(null);
        }
    }

    public void playWashingMachineSound()
    {
        sound.PlayOneShot(washingMachSound);
    }
}
