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

    // public GameObject parkMin;
    // public GameObject parkMid;
    // public GameObject parkMax;

    // public GameObject barMin;
    // public GameObject barMid;
    // public GameObject barMax;

    bool inApartment = true;
    bool inPark = false;
    bool inBar = false;

    string[] stringApartment = new string[] {"one", "two", "three"};
    public string[] stringPark;
    public string[] stringBar;

    TextMeshProUGUI textmeshproText;

    int randomApartmentNum;
    int randomParkNum;
    int randomBarNum;

    public float minMaximumTime;
    public float maxMaximumTime;
    float maxTime;
    float time;

    public void ObjectiveChecker(int objective)
    {
        if(objective == 1)
        {
            inApartment = true;
            inPark = false;
            inBar = false;
        }

        if(objective == 2)
        {
            inApartment = false;
            inPark = true;
            inBar = false;
        }

        if(objective == 3)
        {
            inApartment = false;
            inPark = false;
            inBar = true;
        }
    }

    void Awake()
    {
        inApartment = true;

        alcohol = player.GetComponent<PlayerMovement>().getAlcoholLevel();

        maxTime = Random.Range(minMaximumTime, maxMaximumTime);
        time = maxTime;

        
    }

    void Start()
    {
        
        
        textmeshproText = this.gameObject.GetComponent<TextMeshProUGUI>();

        randomApartmentNum = Random.Range(0, stringApartment.Length);
        randomParkNum = Random.Range(0, stringPark.Length);
        randomBarNum = Random.Range(0, stringBar.Length);
    }

    void Update()
    {

        //alcohol = player.GetComponent<PlayerMovement>().getAlcoholLevel();

        if(inApartment)
        {
            textmeshproText.text = stringApartment[randomApartmentNum];

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

        if(inPark)
        {
            textmeshproText.text = stringPark[randomParkNum];
        }
        
        if(inBar)
        {
            textmeshproText.text = stringBar[randomBarNum];
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

            randomApartmentNum = Random.Range(0, stringApartment.Length);
            randomParkNum = Random.Range(0, stringPark.Length);
            randomBarNum = Random.Range(0, stringBar.Length);
        }
    }
}
