using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TMP_Text taskText;

    enum playerTasks { findRing, findFlowers, findKey, putOnClothes }

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
                break;
            case playerTasks.findRing:
                taskText.text = "Current task: Find Ring";
                break;
            case playerTasks.findFlowers:
                taskText.text = "Current task: Find Flowers";
                break;
            case playerTasks.putOnClothes:
                taskText.text = "Current task: Put on Nice Clothes";
                break;
        }
    }
}
