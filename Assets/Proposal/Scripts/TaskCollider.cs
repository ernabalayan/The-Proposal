using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCollider : MonoBehaviour
{
    [SerializeField] GameObject Tasks;

    enum ObjTask {key, flower, ring }
    [SerializeField] ObjTask relatedTask;

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
            other.GetComponent<PlayerMovement>().setAlcoholCollide(true);
            other.GetComponent<PlayerMovement>().alcoholObjectColl(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rend.material.color = Color.gray;
            other.GetComponent<PlayerMovement>().setAlcoholCollide(false);
            other.GetComponent<PlayerMovement>().alcoholObjectColl(null);
        }
    }

    public void FinishedTask()
    {
        Debug.Log("Hello I am no longer active");
        //tell task manager that the collect key task has been completed
        switch (relatedTask)
        {
            case ObjTask.key:
                Tasks.GetComponent<TaskManager>().KeyWasFound();
                break;

            case ObjTask.ring:
                Tasks.GetComponent<TaskManager>().RingWasFound();
                break;

            case ObjTask.flower:
                break;
        }
    }
}
