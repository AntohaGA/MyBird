using UnityEngine;

public class RotatorBullet : MonoBehaviour
{
    private float _speed = 90f; 

    void Update()
    {
        transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
}