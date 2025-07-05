using UnityEngine;

public class AcornSpawner : BulletSpawner
{
    protected override float BulletSpeed => 5f;

    public void SpawnAcorn(Vector3 position, Vector3 direction)
    {
        SpawnBullet(position, direction);
    }
}