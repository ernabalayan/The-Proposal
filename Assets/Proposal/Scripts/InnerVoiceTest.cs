using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InnerVoiceTest : MonoBehaviour
{
    public GameObject player;
    int alcohol;

    public GameObject apartmentMin;
    public GameObject apartmentMid;
    public GameObject apartmentMax;

    public GameObject taskManager;
    int task;
    bool inApartment = true;
    bool inPark = false;
    bool inBar = false;

    public string[] stringApartment;

    TextMeshProUGUI textmeshproText;

    int randomApartmentNum;
    int randomParkNum;
    int randomBarNum;

    public float minMaximumTime;
    public float maxMaximumTime;
    float maxTime;
    float time;

    void Awake()
    {
        task = taskManager.GetComponent<TaskManager>().taskNum;

        alcohol = player.GetComponent<PlayerMovement>().getAlcoholLevel();

        maxTime = Random.Range(minMaximumTime, maxMaximumTime);
        time = maxTime;

        
    }

    void Start()
    {
        textmeshproText = this.gameObject.GetComponent<TextMeshProUGUI>();

        randomApartmentNum = Random.Range(0, stringApartment.Length);
    }

    void Update()
    {
        task = taskManager.GetComponent<TaskManager>().taskNum;

        alcohol = player.GetComponent<PlayerMovement>().getAlcoholLevel();

        textmeshproText.text = stringApartment[randomApartmentNum];

        if(alcohol <= 1)
        {
            apartmentMin.SetActive(false);
            apartmentMid.SetActive(false);
            apartmentMax.SetActive(true);
        }

        if(alcohol == 2)
        {
            apartmentMin.SetActive(false);
            apartmentMid.SetActive(true);
            apartmentMax.SetActive(false);
        }

        if(alcohol == 3)
        {
            apartmentMin.SetActive(true);
            apartmentMid.SetActive(false);
            apartmentMax.SetActive(false);
        }
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
            maxTime = Random.Range(minMaximumTime, maxMaximumTime);
            time = maxTime;

            if(task == 1)
                randomApartmentNum = Random.Range(0, 36);

            if(task == 2)
                randomApartmentNum = Random.Range(37, 71);

            if(task == 3)
                randomApartmentNum = Random.Range(72, stringApartment.Length);
        }
    }
}
