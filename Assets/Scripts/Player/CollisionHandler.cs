using System;
using UnityEngine;

public abstract class CollisionHandler : MonoBehaviour
{
    [SerializeField] protected LayerMask EnemyMask;

    public event Action<IInteractable> CollisionDetected;

    private void OnEnable()
    {
        CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        CollisionDetected -= ProcessCollision;
    }

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }

    protected abstract void ProcessCollision(IInteractable interactable);
}