using System.Collections.Generic;
using UnityEngine;

public class TitleSnakeMove : MonoBehaviour
{
    [SerializeField] Transform segPrefab;
    [SerializeField] Transform spawnPoint;
    private List<Transform> segments = new List<Transform>();
    [SerializeField] int startSize = 5;
    private Vector3 startPosition = new Vector3(-50,0,0);
    

    void Start()
    {
        segments.Add(this.transform);
        for (int i = 1; i < startSize; i++)
        {
            segments.Add(Instantiate(segPrefab, spawnPoint));
        }
    }
    void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        
    }
    
}
