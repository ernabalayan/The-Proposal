using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InnerVoiceTest1 : MonoBehaviour
{
    public GameObject player;
    int alcohol;

    public GameObject apartmentText;
    public GameObject apartmentMin;
    public GameObject apartmentMid;
    public GameObject apartmentMax;

    public GameObject parkText;
    public GameObject parkMin;
    public GameObject parkMid;
    public GameObject parkMax;

    public GameObject barText;
    public GameObject barMin;
    public GameObject barMid;
    public GameObject barMax;

    public GameObject textManager;
    bool inApartment = true;
    bool inPark = false;
    bool inBar = false;

    public string[] stringApartment;
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

    // public void ObjectiveChecker(int objective)
    // {
    //     if(objective == 1)
    //     {
    //         inApartment = true;
    //         inPark = false;
    //         inBar = false;
    //     }

    //     if(objective == 2)
    //     {
    //         inApartment = false;
    //         inPark = true;
    //         inBar = false;
    //     }

    //     if(objective == 3)
    //     {
    //         inApartment = false;
    //         inPark = false;
    //         inBar = true;
    //     }
    // }

    void Awake()
    {

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
        inApartment = textManager.GetComponent<IVTextManager>().apartment;
        inPark = textManager.GetComponent<IVTextManager>().park;
        inBar = textManager.GetComponent<IVTextManager>().bar;

        // if(textManager.GetComponent<IVTextManager>().apartment)
        // {
        //     Debug.Log("apartment is true");
        // }
        // if(textManager.GetComponent<IVTextManager>().park)
        // {
        //     Debug.Log("park is true");
        // }
        // if(textManager.GetComponent<IVTextManager>().bar)
        // {
        //     Debug.Log("bar is true");
        // }

        Debug.Log("inApartment is " + inApartment);
        Debug.Log("inPark is " + inPark);

        alcohol = player.GetComponent<PlayerMovement>().getAlcoholLevel();

        if(textManager.GetComponent<IVTextManager>().apartment)
        {
            apartmentText.SetActive(true);
            parkText.SetActive(false);
            barText.SetActive(false);

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
        if(!textManager.GetComponent<IVTextManager>().apartment)
            apartmentText.SetActive(false);

        if(textManager.GetComponent<IVTextManager>().park)
        {
            apartmentText.SetActive(false);
            parkText.SetActive(true);
            Debug.Log("this has fired");
            barText.SetActive(false);

            textmeshproText.text = stringPark[randomParkNum];

            if(alcohol <= 1)
            {
                parkMin.SetActive(false);
                parkMid.SetActive(false);
                parkMax.SetActive(true);
            }

            if(alcohol == 2)
            {
                parkMin.SetActive(false);
                parkMid.SetActive(true);
                parkMax.SetActive(false);
            }

            if(alcohol == 3)
            {
                parkMin.SetActive(true);
                parkMid.SetActive(false);
                parkMax.SetActive(false);
            }
        }
        
        if(inBar)
        {
            apartmentText.SetActive(false);
            parkText.SetActive(false);
            barText.SetActive(true);

            textmeshproText.text = stringBar[randomBarNum];

            if(alcohol <= 1)
            {
                barMin.SetActive(false);
                barMid.SetActive(false);
                barMax.SetActive(true);
            }

            if(alcohol == 2)
            {
                barMin.SetActive(false);
                barMid.SetActive(true);
                barMax.SetActive(false);
            }

            if(alcohol == 3)
            {
                barMin.SetActive(true);
                barMid.SetActive(false);
                barMax.SetActive(false);
            }
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
