using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholCollision : MonoBehaviour
{
    //GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Vector2.Distance(transform.position, Player.transform.position) < 0.95f || Vector2.Distance(transform.position, Player.transform.position) < -0.95f)
        {
            Debug.Log("I am near the alchohol");
        }
        */
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("beverage obtained");
            collision.gameObject.GetComponent<PlayerMovement>().increaseAlcoholContent(1);
            this.gameObject.SetActive(false);
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().setAlcoholCollide(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().setAlcoholCollide(false);
        }
    }
}
