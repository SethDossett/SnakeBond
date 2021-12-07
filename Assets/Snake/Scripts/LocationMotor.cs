using UnityEngine;

public class LocationMotor : MonoBehaviour
{
    [SerializeField] Vector2[] newtargets;
    private Vector2 newNextTarget;
    private Vector2 target;
    private int currentIndex = 0;
    [SerializeField] bool smooth;
    [SerializeField] float speed;

    void Start()
    {
        target = newtargets[0];
    }
    void Update()
    {
        if (!smooth)
            return;
        
        MoveToLocationUpdate();

    }
    void FixedUpdate()
    {
        if (smooth)
            return;
        
        MoveToLocationFixedUpdate();
        
    }
    private void MoveToLocationUpdate()
    {
        if (Vector2.Distance(transform.position, target) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            currentIndex++;
            if (currentIndex == newtargets.Length)
                currentIndex = 0;
            target = newtargets[currentIndex];
        }
    }

    void MoveToLocationFixedUpdate()
    {
        if (Vector2.Distance(transform.position, target) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 1);
        }
        else
        {
            currentIndex++;
            if (currentIndex == newtargets.Length)
                currentIndex = 0;
            target = newtargets[currentIndex];
        }
    }
}
