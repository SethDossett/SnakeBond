using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Motor : MonoBehaviour
{
    private float randomX;
    private float randomY;
    Vector2 spawnLocation;
    Event_Master eventMaster;

    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
    }
    void OnDisable()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Snake"))
        {
            eventMaster.CallScorePoint();
            Destroy(gameObject);
        }
    }
}


