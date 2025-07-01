using UnityEngine;

[RequireComponent(typeof(AcornGenerator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(RavenRotator))]
[RequireComponent(typeof(RavenCollisionHandler))]
public class Raven : MonoBehaviour, IInteractable
{
    private Vector3 _startPosition;
    private RavenRotator _rotatorZ;
    private RavenCollisionHandler _collisionHandler;
    public AcornGenerator _acornGenerator { get; private set; }

    public Rigidbody2D Rigidbody2D { get; private set; }
    public float TapForce { get; private set; } = 4;
    public float Speed { get; private set; } = 0;
    public float RotationSpeed { get; private set; } = 3;
    public float MinRotationZ { get; private set; } = -50;
    public float MaxRotationZ { get; private set; } = 50;
    public Quaternion MinRotation { get; private set; }
    public Quaternion MaxRotation { get; private set; }
    public float SpeedBullet { get; private set; } = 5;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _rotatorZ = GetComponent<RavenRotator>();
        _collisionHandler = GetComponent<RavenCollisionHandler>();
        _acornGenerator = GetComponent<AcornGenerator>();
    }
    private void Start()
    {
        _startPosition = transform.position;
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
            Debug.Log("You touch Ground!!!");
        }
        else if (interactable is Bullet)
        {
            Debug.Log("You touch Bullet!!!");
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        Rigidbody2D.linearVelocity = Vector2.zero;
    }
}
