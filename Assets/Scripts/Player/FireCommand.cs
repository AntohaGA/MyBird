using UnityEngine;

public class FireCommand : ICommand
{
    private Vector3 _direction;
    private Vector3 _position;
    private float _speed;

    public FireCommand(Raven raven)
    {
        _direction = raven.transform.right;
        _position = raven.transform.position;
        _speed = raven.SpeedBullet;
    }

    public void Execute(Raven raven)
    {
        Debug.Log("Fire!");
        raven._acornGenerator.SpawnBullet(_position, _speed, _direction);
    }
}