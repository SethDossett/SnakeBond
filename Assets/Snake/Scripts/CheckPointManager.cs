using System.Collections;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Vector3 respawnPos;
    Event_Master eventMaster;
    public static CheckPointManager instance;
    bool gameOver = false;

    void Awake()
    {
        instance = this;
    }
    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.respawn += Death;
    }
    void OnDisable()
    {
        eventMaster.respawn -= Death;
    }
    void Death()
    {
        
        StartCoroutine(Respawn());
       
    }
    IEnumerator Respawn()
    {
         yield return new WaitForSeconds(1.5f);
         Instantiate(player, respawnPos, Quaternion.identity);
    }
}
