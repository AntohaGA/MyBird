using UnityEngine;

[RequireComponent(typeof(AcornShooter))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(RavenRotator))]
[RequireComponent(typeof(RavenCollisionHandler))]
public class Raven : MonoBehaviour, IInteractable
{
    private Vector3 _startPosition;
    public AcornShooter AcornGenerator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        AcornGenerator = GetComponent<AcornShooter>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        Reset();
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        Rigidbody2D.linearVelocity = Vector2.zero;
    }
}