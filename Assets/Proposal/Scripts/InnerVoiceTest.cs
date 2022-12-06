using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InnerVoiceTest : MonoBehaviour
{
    //public TextMeshProUGUI[] racingText;
    //public TextMeshPro[] racingText;
    // public Text[] txt;
    // txt.text = 'blah';

    //public GameObject racingText;
    public string[] stringText;
    TextMeshProUGUI textmeshproText;

    int randonNum;

    public float minMaximumTime;
    public float maxMaximumTime;
    float maxTime;
    float time;

    void Awake()
    {
        maxTime = Random.Range(minMaximumTime, maxMaximumTime);
        time = maxTime;
    }

    void Start()
    {
        textmeshproText = this.gameObject.GetComponent<TextMeshProUGUI>();

        randonNum = Random.Range(0, 37);
    }

    void Update()
    {
        textmeshproText.text = stringText[randonNum];
    }

    void FixedUpdate()
    {
        if(time > 0) {
            time -= Time.deltaTime;
            if(time < 0) time = 0;
            return;
        }

        if(time == 0)
        {
            maxTime = Random.Range(minMaximumTime, maxMaximumTime);
            time = maxTime;

            randonNum = Random.Range(0, 37);
        }
    }
}
