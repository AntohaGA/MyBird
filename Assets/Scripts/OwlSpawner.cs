using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(OwlGenerator))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(EggSpawner))]
public class OwlSpawner : MonoBehaviour
{
    private const int PoolCapacity = 10;
    private const int PoolMaxSize = 100;
    private const int EnemySpeed = 2;

    [SerializeField] private float _lowerOffset;
    [SerializeField] private float _upperOffset;
    [SerializeField] private Owl _prefab;

    private OwlGenerator _owlGenerator;
    private PoolOwls _pool;
    private ScoreCounter _scoreCounter;
    private EggSpawner _eggSpawner;

    private Vector3 _leftDirection = new(-1f, 0f, 0f);

    public event Action<Owl> OwlCreated;
    public event Action<Owl> OwlDestroyed;

    private void Awake()
    {
        _owlGenerator = GetComponent<OwlGenerator>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _eggSpawner = GetComponent<EggSpawner>();
        _pool = transform.AddComponent<PoolOwls>();
        _pool.Init(PoolCapacity, PoolMaxSize, _prefab);
    }

    private void OnEnable()
    {
        _owlGenerator.GenerateOwls();
        _owlGenerator.OwlGenerated += Spawn;
    }

    private void OnDisable()
    {
        _owlGenerator.OwlGenerated -= Spawn;
    }

    private void Spawn()
    {
        float spawnPositionY = UnityEngine.Random.Range(_lowerOffset, _upperOffset) + transform.position.y;
        Vector3 spawnPoint = new(transform.position.x, spawnPositionY, transform.position.z);

        Owl owl = _pool.GetInstance();
        owl.Init(spawnPoint, EnemySpeed, _leftDirection, _eggSpawner);
        owl.OwlShoted += ReturnOwl;
        OwlCreated?.Invoke(owl);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Owl owl))
        {
            ReturnOwl(owl);
        }
    }

    private void ReturnOwl(Owl owl)
    {
        owl.OwlShoted -= ReturnOwl;
        OwlDestroyed?.Invoke(owl);
        _pool.ReturnInstance(owl);
        _scoreCounter.Add();
    }

    public void Reset()
    {
        _pool.ClearPool();
        _scoreCounter.Reset();
        _eggSpawner.Reset();
    }
}