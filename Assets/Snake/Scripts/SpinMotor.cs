using UnityEngine;

public class SpinMotor : MonoBehaviour
{
    Vector3 rotation;
    [SerializeField] float speed;
   void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }
}
