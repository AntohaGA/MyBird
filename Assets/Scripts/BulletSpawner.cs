using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour
{
    private const int PoolCapacity = 10;
    private const int PoolMaxSize = 100;

    [SerializeField] protected Bullet Prefab;
    [SerializeField] protected Sprite BulletSprite;
    [SerializeField] protected LayerMask BulletMask;

    protected PoolBullets Pool;
    protected abstract float BulletSpeed { get; }

    protected virtual void Awake()
    {
        Pool = gameObject.AddComponent<PoolBullets>();
        Pool.Init(PoolCapacity, PoolMaxSize, Prefab);
    }

    protected void SpawnBullet(Vector3 position, Vector3 direction)
    {
        Bullet bullet = Pool.GetInstance();
        bullet.Init(BulletMask, position, BulletSprite, BulletSpeed, direction.normalized);
        bullet.Destroyed += ReturnBullet;
    }

    protected virtual void ReturnBullet(Bullet bullet)
    {
        bullet.Destroyed -= ReturnBullet;
        Pool.ReturnInstance(bullet);
    }

    public virtual void Reset()
    {
        Pool.ClearPool();
    }
}