using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(RotatorZ))]
[RequireComponent(typeof(RavenCollisionHandler))]
public class Raven : MonoBehaviour, IInteractable
{
    private Vector3 _startPosition;
    private RotatorZ _rotatorZ;
    private RavenCollisionHandler _collisionHandler;
    public Rigidbody2D Rigidbody2D { get; private set; }
    public float TapForce { get; private set; } = 4;
    public float Speed { get; private set; } = 0;
    public float RotationSpeed { get; private set; } = 4;
    public float MinRotationZ { get; private set; } = -40;
    public float MaxRotationZ { get; private set; } = 40;
    public Quaternion MinRotation { get; private set; }
    public Quaternion MaxRotation { get; private set; }

    private void Start()
    {
        _startPosition = transform.position;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _rotatorZ = GetComponent<RotatorZ>();
        _collisionHandler = GetComponent<RavenCollisionHandler>();
        MinRotation = Quaternion.Euler(0, 0, MinRotationZ);
        MaxRotation = Quaternion.Euler(0, 0, MaxRotationZ);
        Reset();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void Update()
    {
        _rotatorZ.RotateBack(this);
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Owl)
        {
            Debug.Log("You touch an Owl!!!");
        }
        else if (interactable is Ground)
        {
            Debug.Log("You touch an Ground!!!");
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        Rigidbody2D.linearVelocity = Vector2.zero;
    }
}
