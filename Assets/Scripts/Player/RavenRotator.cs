using UnityEngine;

public class RavenRotator : MonoBehaviour
{
    [SerializeField] private Raven _raven;

    private float _rotationSpeed = 3;
    private float _minRotationZ = -50;
    private Quaternion _minRotation; 

    private void Start()
    {
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        _raven.transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}