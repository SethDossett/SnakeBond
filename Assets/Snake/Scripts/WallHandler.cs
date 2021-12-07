using UnityEngine;
using UnityEngine.Events;

public class WallHandler : MonoBehaviour
{
    [SerializeField] UnityEvent WallsUnlock;
    [SerializeField] UnityEvent GateUnlock;
   
    private Event_Master event_Master;
    void OnEnable()
    {
        event_Master = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        event_Master.firstEvent += ManageWalls;
        event_Master.gateUnlocked += OpenGate;
    }
    void OnDisable()
    {
        event_Master.firstEvent -= ManageWalls;
        event_Master.gateUnlocked -= OpenGate;
    }
    void ManageWalls()
    {
        WallsUnlock?.Invoke();
    }
    void OpenGate()
    {
        GateUnlock?.Invoke();
    }
}
