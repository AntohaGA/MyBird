using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyGenerator))]
public class EggGenerator : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;

    private Vector3 _direction = new Vector3(-1f, 0f, 0f);
    private EnemyGenerator _enemyGenerator;
    private PoolBullets _pool;

    private void Awake()
    {
        _enemyGenerator = GetComponent<EnemyGenerator>();
    }

    private void Start()
    {
        _pool = GetComponent<PoolBullets>();
        _pool.Init(10, 100, _prefab);
    }

    private void OnEnable()
    {
        _enemyGenerator.OwlCreated += WhenOwlCreated;
        _enemyGenerator.OwlDestroyed += WhenOwlDestroyed;
    }

    private void OnDisable()
    {
        _enemyGenerator.OwlCreated -= WhenOwlCreated;
        _enemyGenerator.OwlDestroyed -= WhenOwlDestroyed;
    }

    private void WhenOwlCreated(Owl owl)
    {
        owl.BulletGenerated += SpawnBullet;
    }

    private void WhenOwlDestroyed(Owl owl)
    {
        owl.BulletGenerated -= SpawnBullet;
    }

    private void SpawnBullet(Vector3 position, Sprite sprite, float speed)
    {
        Bullet bullet = _pool.GetInstance();
        bullet.Init(position, sprite, speed, _direction);
        bullet.Destroyed += DestroyBullet;
    }

    private void DestroyBullet(Bullet bullet)
    {
        bullet.Destroyed -= DestroyBullet;
        _pool.ReturnInstance(bullet);
    }
}