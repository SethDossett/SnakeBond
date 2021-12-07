using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    private Vector3 offset = new Vector3(0, 0, -1);
    private Vector3 velocity = Vector3.zero;
    private float currentTime = 0f;
    private float duration = 1f;
    private bool isTriggered;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Snake"))
        {
            isTriggered = true;
            currentTime = 0f;
        }
    }
    void Update()
    {
        if (!isTriggered)
            return;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offset, currentTime / duration);
            break;
        }
        if (currentTime > duration)
            isTriggered = false;
    }
}
