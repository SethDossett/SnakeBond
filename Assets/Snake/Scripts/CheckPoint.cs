using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    CheckPointManager manager;
    void Start()
    {
        manager = CheckPointManager.instance;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Snake"))
        {
            manager.respawnPos = this.gameObject.transform.position;
        }
    }
}
