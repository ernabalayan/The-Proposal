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

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rend.material.color = Color.green;

            switch (isCorrFlower)
            {
                case flowerType.correctFlower:
                    flowerTxt.text = "This is perfect!";
                    other.GetComponent<PlayerMovement>().setAlcoholCollide(true);
                    other.GetComponent<PlayerMovement>().alcoholObjectColl(this.gameObject);
                    break;
                case flowerType.wrongFlower:
                    flowerTxt.text = "hmm...not quite";
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
}
