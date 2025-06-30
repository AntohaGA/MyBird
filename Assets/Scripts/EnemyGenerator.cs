using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerOffset;
    [SerializeField] private float _upperOffset;
    [SerializeField] private Owl _prefab;
    [SerializeField] PoolEnemies _pool;

    private void Start()
    {
        _pool = GetComponent<PoolEnemies>();
        _pool.Init(10, 100, _prefab);
        StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
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
        float spawnPositionY = Random.Range(_lowerOffset, _upperOffset) + transform.position.y;

        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Owl owl = _pool.GetInstance();

        owl.transform.position = spawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Owl owl))
        {
            _pool.ReturnInstance(owl);
        }
    }
}
