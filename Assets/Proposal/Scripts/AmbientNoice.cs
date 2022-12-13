using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientNoice : MonoBehaviour
{
    AudioSource sound;
    [SerializeField] AudioClip ambient;
    [SerializeField] AudioManager am;

    [SerializeField] bool isTraffic;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isTraffic && other.gameObject.tag == "Player")
        {
            am.switchToTraffic();
            sound.Play();

        }
        else if(!isTraffic && other.gameObject.tag == "Player")
        {
            am.SwitchToTalking();
            sound.Play();
        }
    }
}
