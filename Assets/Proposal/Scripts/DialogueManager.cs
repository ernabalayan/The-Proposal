using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkText;
    Story inkStory;
    public TextMeshProUGUI textyText;
    public int alcoholCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        inkStory = new Story(inkText.text);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Alcohol Count"+alcoholCount);
        /*
        if(alcoholCount < 4)
        {
            inkStory.ChoosePathString("notdrunk");
            textyText.text = inkStory.Continue();
        }
        if (alcoholCount >= 4 && alcoholCount < 8)
        {
            inkStory.ChoosePathString("kindadrunk");
            textyText.text = inkStory.Continue();
        }
        if (alcoholCount >= 8)
        {
            inkStory.ChoosePathString("reallydrunk");
            textyText.text = inkStory.Continue();
            Debug.Log(inkStory.currentText);
        }
        */



    }
}
