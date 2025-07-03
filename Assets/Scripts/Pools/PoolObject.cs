using UnityEngine;
using UnityEngine.Pool;

public class PoolObject<T> : MonoBehaviour where T : MonoBehaviour
{
    private int _poolCapacity;
    private int _poolMaxSize;

    private T _prefab;
    private ObjectPool<T> _pool;

    public void Init(int poolCapacity, int poolMaxSize, T prefab)
    {
        _poolCapacity = poolCapacity;
        _poolMaxSize = poolMaxSize;
        _prefab = prefab;
        _pool = new ObjectPool<T>(CreateInstance, TakeFromPool, ReturnToPool,
                                  DestroyInstance, true, _poolCapacity, _poolMaxSize);
    }

    public T GetInstance()
    {
        return _pool.Get();
    }

    public void ReturnInstance(T poolObject)
    {
        _pool.Release(poolObject);
    }

    public int GetCountObjectsInPool()
    {
        return _pool.CountAll;
    }

    public void Reset()
    {
        _pool.Clear();
    }

    private T CreateInstance()
    {
        return Instantiate(_prefab);
    }

    private void TakeFromPool(T poolObject)
    {
        poolObject.gameObject.SetActive(true);
    }

    private void ReturnToPool(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }

    private void DestroyInstance(T poolObject)
    {
        Destroy(poolObject.gameObject);
    }
}
