using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject trafficSounds;
    [SerializeField] GameObject talkingSounds;

    enum ambientSound { none, traffic, talking};
    ambientSound ambient = ambientSound.none;

    // Update is called once per frame
    void Update()
    {
        switch(ambient)
        {
            case ambientSound.none:
                trafficSounds.SetActive(false);
                talkingSounds.SetActive(false);
                break;
            case ambientSound.traffic:
                trafficSounds.SetActive(true);
                talkingSounds.SetActive(false);
                break;
            case ambientSound.talking:
                trafficSounds.SetActive(false);
                talkingSounds.SetActive(true);
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
