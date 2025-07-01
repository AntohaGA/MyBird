using UnityEngine;

[RequireComponent(typeof(PoolBullets))]
public class AcornGenerator : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Sprite _sprite;
    private PoolBullets _pool;

    private void Start()
    {
        _pool = GetComponent<PoolBullets>();
        _pool.Init(10, 100, _bullet);
    }

    public void SpawnBullet(Vector3 position,float speed, Vector3 direction)
    {
        Bullet bullet = _pool.GetInstance();
        bullet.Init(position, _sprite, speed, Vector3.Normalize(direction));
        bullet.Destroyed += ReturnBullet;
    }

    private void ReturnBullet(Bullet bullet)
    {
        bullet.Destroyed -= ReturnBullet;
        _pool.ReturnInstance(bullet);
    }
}