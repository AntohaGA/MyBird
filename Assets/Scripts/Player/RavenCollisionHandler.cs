using System;

public class RavenCollisionHandler : CollisionHandler
{
    public event Action RavenDamaged;

    protected override void ProcessCollision(IInteractable interactable)
    {
        switch (interactable)
        {
            case Owl:
            case Ground:
                RavenDamaged?.Invoke();
                break;

            case Bullet bullet when bullet.LayerMask == EnemyMask:
                RavenDamaged?.Invoke();
                break;
        }
    }
}