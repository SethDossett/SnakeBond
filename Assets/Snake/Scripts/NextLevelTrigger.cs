using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
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
        if(col.gameObject.CompareTag("Snake"))
        {
            eventMaster.CallLevelComplete();
            // go to next level;
        }
    }
    
}
