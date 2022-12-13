using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskTimer : MonoBehaviour
{
    public float maxTime;
    float time;

    TextMeshProUGUI textmeshproText;
    string objectiveTimer;
    int timeDisplay;

    void Awake()
    {
        time = maxTime;
    }

    void Start()
    {
        textmeshproText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timeDisplay = Mathf.RoundToInt(time);
        objectiveTimer = timeDisplay.ToString();
        textmeshproText.text = "Time Left: " + objectiveTimer;
    }

    void FixedUpdate()
    {
        if(time > 0) 
        {
            time -= Time.deltaTime;
            if(time < 0) time = 0;
            return;
        }

        if(time == 0)
        {
            Debug.Log("Change to failed scene");
        }
    }
}
