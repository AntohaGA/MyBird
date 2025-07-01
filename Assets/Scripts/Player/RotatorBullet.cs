using UnityEngine;

public class RotatorBullet : MonoBehaviour
{
    public float speed = 90f; 

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}