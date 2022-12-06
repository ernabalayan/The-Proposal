using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TMP_Text taskText;
    [SerializeField] TMP_Text timerText;
    bool keyfound = false;
    bool ringFound = false;

    [SerializeField] GameObject ring;
    [SerializeField] GameObject key;
    [SerializeField] GameObject flower;

    float timer = 0f;
    float endBreakPoint = 30.0f;

    enum playerTasks { findRing, findFlowers, findKey, endTask }

    playerTasks curtask = playerTasks.findKey;

    // Start is called before the first frame update
    void Start()
    {
        taskText.text = "Current task: ";
    }

    // Update is called once per frame
    void Update()
    {
        switch(curtask)
        {
            case playerTasks.findKey:
                taskText.text = "Current task: Find Key";
                ring.GetComponent<CapsuleCollider>().enabled = false;
                flower.GetComponent<BoxCollider>().enabled = false;
                break;
            case playerTasks.findRing:
                taskText.text = "Current task: Find Ring";
                ring.GetComponent<CapsuleCollider>().enabled = true;
                break;
            case playerTasks.findFlowers:
                taskText.text = "Current task: Find Flowers";
                flower.GetComponent<BoxCollider>().enabled = true;
                break;
            case playerTasks.endTask:
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
        Debug.Log("key found");
        keyfound = true;
        curtask = playerTasks.findRing;
    }

    public void RingWasFound()
    {
        Debug.Log("rind found");
        ringFound = true;
        curtask = playerTasks.findFlowers;
    }

    public void FlowerWasFound()
    {
        curtask = playerTasks.endTask;
    }
}
