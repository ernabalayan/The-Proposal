using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AlcoholCollisionTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textyText;
    [SerializeField] TextAsset introFile;
    [SerializeField] TextAsset quest1File;
    Story inkStory;
    [SerializeField] int alcoholCount = 0;
    PlayerInput pi;
    
    // Start is called before the first frame update
    void Start()
    {
        inkStory = new Story(introFile.text);
        pi = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(alcoholCount);
    }
   public void OnSpace()
    {
      
       textyText.text = inkStory.Continue();
        
       if(inkStory.canContinue == false)
        {
            SceneManager.LoadScene(1);
        }
    }
}
