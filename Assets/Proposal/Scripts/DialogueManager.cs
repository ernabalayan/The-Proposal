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
    public PlayerInput pi;
    // Start is called before the first frame update
    void Start()
    {
        inkStory = new Story(inkText.text);
    }

    // Update is called once per frame
    void Update()
    {




    }
    public void OnDialogue()
    {
        textyText.text = inkStory.Continue();
    }
}
