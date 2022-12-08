using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public bool building = false;
    public GameObject buildings;
    private void Update()
    {
        if (building == true)
        {
            buildings.SetActive(true);
        }
            else if (building == false)
            {
                buildings.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log("FAISUDU");
            if (building == false)
            {
                if (collision.gameObject.tag == "Player")
                {
                    building = true;
                }
            }
            else if (building == true)
            {
                if (collision.gameObject.tag == "Player")
                {
                    building = false;
                }
            }
        }
    }
