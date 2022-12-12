using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerCollisions : MonoBehaviour
{
    enum flowerType { correctFlower, wrongFlower}
    [SerializeField] flowerType isCorrFlower;
    float destroyTimer = 2.0f;

    [SerializeField] GameObject TaskManager;
    [SerializeField] TMP_Text flowerTxt;

    [SerializeField] List<string> WrongFlowerTxt;
    int selectedText;

    AudioSource sound;
    [SerializeField] AudioClip foundTask;
    //[SerializeField] AudioClip collectedTask;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        flowerTxt.text = "";
        selectedText = Random.Range(0, WrongFlowerTxt.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rend.material.color = Color.green;
            flowerTxt.transform.rotation = Quaternion.LookRotation(-((new Vector3(other.gameObject.transform.position.x, 
                other.gameObject.transform.position.y + 1.5f, other.gameObject.transform.position.z)) - flowerTxt.transform.position));

            switch (isCorrFlower)
            {
                case flowerType.correctFlower:
                    sound.PlayOneShot(foundTask);
                    flowerTxt.text = "This is perfect!";
                    other.GetComponent<PlayerMovement>().setAlcoholCollide(true);
                    other.GetComponent<PlayerMovement>().alcoholObjectColl(this.gameObject);
                    break;
                case flowerType.wrongFlower:
                    flowerTxt.text = WrongFlowerTxt[selectedText];
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rend.material.color = Color.grey;
            flowerTxt.text = "";

            switch(isCorrFlower)
            {
                case flowerType.correctFlower:
                    other.GetComponent<PlayerMovement>().setAlcoholCollide(false);
                    other.GetComponent<PlayerMovement>().alcoholObjectColl(null);
                    break;
                case flowerType.wrongFlower:
                    StartCoroutine(DestroySelf());
                    break;
            }
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(destroyTimer);
        this.gameObject.SetActive(false);
    }

    public void FinishedTask()
    {
        if (isCorrFlower == flowerType.correctFlower)
        {
            //sound.PlayOneShot(collectedTask);
            TaskManager.GetComponent<TaskManager>().FlowerWasFound();
        }
    }
}
