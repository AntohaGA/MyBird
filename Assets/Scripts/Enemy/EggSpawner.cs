using UnityEngine;

public class EggSpawner : BulletSpawner
{
    protected override float BulletSpeed => 5f;

    private Vector3 _leftDirection = new(-1f, 0f, 0f);

    protected override void Awake()
    {
        base.Awake();
    }

    public void SpawnEgg(Vector3 position)
    {
        SpawnBullet(position, _leftDirection);
    }
}