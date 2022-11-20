using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("beverage obtained");
            collision.gameObject.GetComponent<PlayerMovement>().increaseAlcoholContent(1);
            this.gameObject.SetActive(false);
        }
    }
}
