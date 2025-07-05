using UnityEngine;

public class TapCommand : ICommand
{
    private float _tapForce = 4;
    private float _maxRotationZ = 50;
    private Quaternion _maxRotation;

    public TapCommand()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    public void Execute(Raven raven)
    {
        raven.Rigidbody2D.linearVelocity = new Vector2(0, _tapForce);
        raven.Rigidbody2D.transform.rotation = _maxRotation;
    }
}