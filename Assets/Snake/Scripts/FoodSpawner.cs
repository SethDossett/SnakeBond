using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private float randomX;
    private float randomY;
    Vector2 spawnLocation;
    private Event_Master eventMaster;

    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.firstEvent += DestroySpawner;
    }
    void OnDisable()
    {
        eventMaster.firstEvent -= DestroySpawner;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Snake"))
        {
            eventMaster.CallScorePoint();
            Spawn();
        }
        if (col.CompareTag("DoNotTouch"))
        {
            Spawn();
        }

    }
    void Start()
    {
        Spawn();
    }
    
    void Spawn()
    {
        GetRandomPosition();
        
        transform.position = spawnLocation;
    }
    void GetRandomPosition()
    {
        randomX = UnityEngine.Random.Range(-10.5f, 10.5f);
        randomY = UnityEngine.Random.Range(-10.5f, 10.5f);

        spawnLocation = new Vector2(Mathf.Round(randomX),Mathf.Round(randomY));
    }
    void DestroySpawner()
    {
        Destroy(gameObject);
    }
}
