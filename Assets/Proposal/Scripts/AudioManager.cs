using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject trafficSounds;
    [SerializeField] GameObject otherTraffic;
    [SerializeField] GameObject talkingSounds;

    enum ambientSound { none, traffic, talking};
    ambientSound ambient = ambientSound.none;

    private void Start()
    {
        otherTraffic.GetComponent<AudioSource>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(ambient)
        {
            case ambientSound.none:
                trafficSounds.GetComponent<AudioSource>().enabled = false;
                talkingSounds.GetComponent<AudioSource>().enabled = false;
                break;
            case ambientSound.traffic:
                trafficSounds.GetComponent<AudioSource>().enabled = true;
                talkingSounds.GetComponent<AudioSource>().enabled = false;
                break;
            case ambientSound.talking:
                trafficSounds.GetComponent<AudioSource>().enabled = false;
                talkingSounds.GetComponent<AudioSource>().enabled = true;
                break;
        }
    }

    public void switchToTraffic()
    {
        ambient = ambientSound.traffic;
    }

    public void SwitchToTalking()
    {
        ambient = ambientSound.talking;
    }

    public void switchToNone()
    {
        ambient = ambientSound.none;
    }
}
