using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector pd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pd.state != PlayState.Playing)
        {
            SceneManager.LoadScene(1);
        }
    }
}
