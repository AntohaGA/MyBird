using UnityEngine;

public class Tap : ICommand
{
    public void Execute(Raven raven)
    {
        raven.Rigidbody2D.linearVelocity = new Vector2(0, raven.TapForce);
        raven.Rigidbody2D.transform.rotation = raven.MaxRotation;
    }
}