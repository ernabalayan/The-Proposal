using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorCollision : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI doorText;
    public bool locked = true;

    // Start is called before the first frame update
    void Start()
    {
        doorText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!locked)
        {
            doorText.text = "";
            doorText.enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (locked)
            {
                Debug.Log("hi");
                doorText.enabled = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (locked)
            {
                Debug.Log("hi");
                doorText.enabled = false;
            }
        }
    }

    public void setLock(bool isLocked)
    {
        locked = isLocked;
    }
}
