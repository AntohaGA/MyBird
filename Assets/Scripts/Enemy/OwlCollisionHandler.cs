using System;

public class OwlCollisionHandler : CollisionHandler
{
    public event Action OwlShoted;

    protected override void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Bullet bullet && bullet.LayerMask == EnemyMask)
        {
            OwlShoted?.Invoke();
        }
    }
}