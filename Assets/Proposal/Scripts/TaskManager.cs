using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TMP_Text taskText;
   // [SerializeField] TMP_Text timerText;
    bool keyfound = false;
    bool ringFound = false;

    [SerializeField] GameObject ring;
    [SerializeField] GameObject key;
    [SerializeField] GameObject flower;
    [SerializeField] GameObject girlfriend;

    //float timer = 0f;
    //float endBreakPoint = 30.0f;

    enum playerTasks { findRing, findFlowers, findKey, findGF, endTask }

    playerTasks curtask = playerTasks.findKey;

    public int taskNum = 1;

    AudioSource sound;
    [SerializeField] AudioClip collectedSound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        taskText.text = "Current task: ";
    }

    // Update is called once per frame
    void Update()
    {
        switch(curtask)
        {
            case playerTasks.findKey:
                taskText.text = "Current task: Find Key";
                taskNum = 1;
                ring.GetComponent<CapsuleCollider>().enabled = false;
                flower.GetComponent<BoxCollider>().enabled = false;
                girlfriend.GetComponent<CapsuleCollider>().enabled = false;
                break;
            case playerTasks.findRing:
                taskText.text = "Current task: Find Ring";
                taskNum = 1;
                ring.GetComponent<CapsuleCollider>().enabled = true;
                break;
            case playerTasks.findFlowers:
                taskText.text = "Current task: Find Flowers";
                taskNum = 2;
                flower.GetComponent<BoxCollider>().enabled = true;
                break;
            case playerTasks.findGF:
                taskText.text = "Current task: Find your Girlfriend";
                taskNum = 3;
                girlfriend.GetComponent<CapsuleCollider>().enabled = true;
                break;
            case playerTasks.endTask:
                taskNum = 0;
                taskText.text = "All tasks complete!";
                break;
        }

        /*
        timer += Time.deltaTime;
        timerText.text = "Time Elapsed : " + timer;

        if(timer > endBreakPoint && !ringFound && !keyfound)
        {
            taskText.text = "You failed to complete the tasks.";
        }
        */
    }

    public void KeyWasFound()
    {
        //Debug.Log("key found");
        sound.PlayOneShot(collectedSound);
        keyfound = true;
        curtask = playerTasks.findRing;
    }

    public void RingWasFound()
    {
        sound.PlayOneShot(collectedSound);
        //Debug.Log("ring found");
        ringFound = true;
        curtask = playerTasks.findFlowers;
    }

    public void FlowerWasFound()
    {
        sound.PlayOneShot(collectedSound);
        curtask = playerTasks.findGF;
    }

    public void GFWasFound()
    {
        sound.PlayOneShot(collectedSound);
        curtask = playerTasks.endTask;
    }
}
