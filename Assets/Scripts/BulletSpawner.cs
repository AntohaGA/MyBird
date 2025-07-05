using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour
{
    [SerializeField] protected Bullet prefab;
    [SerializeField] protected Sprite bulletSprite;
    [SerializeField] protected LayerMask bulletMask;
    protected PoolBullets pool;
    protected abstract float BulletSpeed { get; }

    protected virtual void Awake()
    {
        pool = gameObject.AddComponent<PoolBullets>();
        pool.Init(10, 100, prefab);
    }

    protected void SpawnBullet(Vector3 position, Vector3 direction)
    {
        Bullet bullet = pool.GetInstance();
        bullet.Init(bulletMask, position, bulletSprite, BulletSpeed, direction.normalized);
        bullet.Destroyed += ReturnBullet;
    }

    protected virtual void ReturnBullet(Bullet bullet)
    {
        bullet.Destroyed -= ReturnBullet;
        pool.ReturnInstance(bullet);
    }

    public virtual void Reset()
    {
        pool.ClearPool();
    }
}