using UnityEngine;

public class Pool_Location : MonoBehaviour
{
    [SerializeField] Transform cam;
    Event_Master eventMaster;
    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.death += UpdatePosition;
    }
    void OnDisable()
    {
        eventMaster.death -= UpdatePosition;
    }
    void UpdatePosition()
    {
        transform.position = cam.position;
    }
}
