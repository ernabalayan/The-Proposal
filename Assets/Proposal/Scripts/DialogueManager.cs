using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkText;
    Story inkStory;
    public TextMeshProUGUI textyText;
    // Start is called before the first frame update
    void Start()
    {
        inkStory = new Story(inkText.text);
    }

    // Update is called once per frame
    void Update()
    {
        while (inkStory.canContinue)
        {
            textyText.text = inkStory.Continue();

        }
       
    }
}
