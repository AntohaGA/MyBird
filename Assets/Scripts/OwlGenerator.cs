using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PoolOwls))]
public class OwlGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerOffset;
    [SerializeField] private float _upperOffset;
    [SerializeField] private Owl _prefab;
    [SerializeField] private PoolOwls _pool;

    private float _enemySpeed = 2;
    private Vector3 _direction = new Vector3(-1f, 0f, 0f);

    public event Action<Owl> OwlCreated;
    public event Action<Owl> OwlDestroyed;

    private void Awake()
    {
        _pool = GetComponent<PoolOwls>();
        _pool.Init(10, 100, _prefab);
    }

    private void Start()
    {
        StartCoroutine(GenerateOwls());
    }

    private IEnumerator GenerateOwls()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = UnityEngine.Random.Range(_lowerOffset, _upperOffset) + transform.position.y;
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Owl owl = _pool.GetInstance();
        owl.Init(spawnPoint, _enemySpeed, _direction);
        owl.OwlShoted += ReturnOwl;
        OwlCreated?.Invoke(owl);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Owl owl))
        {
            ReturnOwl(owl);
        }
    }

    private void ReturnOwl(Owl owl)
    {
        owl.OwlShoted -= ReturnOwl;
        OwlDestroyed?.Invoke(owl);
        _pool.ReturnInstance(owl);
    }

    public void Reset()
    {
        _pool.Reset();
    }
}