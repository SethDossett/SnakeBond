using UnityEngine;

public class PoolHandler : MonoBehaviour
{
    Event_Master eventMaster;
    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.death += ClearChildren;
    }
    void OnDisable()
    {
        eventMaster.death -= ClearChildren;
    }
    void Awake()
    {
        
    }
    void ClearChildren()
    {
        Destroy(gameObject);
    }
}
