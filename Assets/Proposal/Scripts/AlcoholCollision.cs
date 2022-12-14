using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholCollision : MonoBehaviour
{
    [SerializeField] int alcoholAmount = 1;
    Renderer rend;

    AudioSource sounds;
    [SerializeField] AudioClip nearby;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        sounds = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Player is colliding");
            sounds.PlayOneShot(nearby);
            rend.materials[0].color = Color.red;
            other.gameObject.GetComponent<PlayerMovement>().setAlcoholCollide(true);
            other.gameObject.GetComponent<PlayerMovement>().alcoholObjectColl(this.gameObject, alcoholAmount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rend.materials[0].color = Color.white;
            other.gameObject.GetComponent<PlayerMovement>().setAlcoholCollide(false);
            other.gameObject.GetComponent<PlayerMovement>().alcoholObjectColl(null, 0);
        }
    }
}
