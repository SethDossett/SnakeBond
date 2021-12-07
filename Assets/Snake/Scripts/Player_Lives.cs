using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Lives : MonoBehaviour
{
    Text livesText;
    int lives = 3;
    Event_Master eventMaster;
    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.death += DetractLife;
    }
    void OnDisable()
    {
        eventMaster.death -= DetractLife;
    }
    void Awake()
    {
        livesText = GetComponent<Text>();
    }
    void Start()
    {
        livesText.text = $"{lives}";
    }
    void DetractLife()
    {
        lives = lives - 1;

        if (lives >= 0)
        {
            livesText.text = $"{lives}";
            eventMaster.CallRespawn();
        }
        else
        {
            eventMaster.CallGameOver();
        }
    }
    
}
