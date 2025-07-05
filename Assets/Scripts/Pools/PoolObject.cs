using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolObject<T> : MonoBehaviour where T : MonoBehaviour
{
    private int _poolCapacity;
    private int _poolMaxSize;

    private T _prefab;
    private ObjectPool<T> _pool;
    private List<T> _activeObjects;

    public ObjectPool<T> Pool => _pool;

    public void Init(int poolCapacity, int poolMaxSize, T prefab)
    {
        _poolCapacity = poolCapacity;
        _poolMaxSize = poolMaxSize;
        _prefab = prefab;
        _pool = new ObjectPool<T>(CreateInstance, TakeFromPool, ReturnToPool,
                                  DestroyInstance, true, _poolCapacity, _poolMaxSize);
        _activeObjects = new List<T>();
    }

    public T GetInstance()
    {
        return _pool.Get();
    }

    public void ReturnInstance(T poolObject)
    {
        _pool.Release(poolObject);
    }

    private T CreateInstance()
    {
        return Instantiate(_prefab);
    }

    private void TakeFromPool(T poolObject)
    {
        if (!_activeObjects.Contains(poolObject))
            _activeObjects.Add(poolObject);

        poolObject.gameObject.SetActive(true);
    }

    private void ReturnToPool(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
        _activeObjects.Remove(poolObject);
    }

    private void DestroyInstance(T poolObject)
    {
        Destroy(poolObject.gameObject);
    }

    public void ClearPool()
    {
        foreach (var activeObject in new List<T>(_activeObjects))
        {
            _pool.Release(activeObject);
        }

        _pool.Clear();
    }
}