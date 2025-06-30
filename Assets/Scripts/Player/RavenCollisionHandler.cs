using System;
using UnityEngine;

public class RavenCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            Debug.Log("interactable - " + interactable);
            CollisionDetected?.Invoke(interactable);
        }
    }
}