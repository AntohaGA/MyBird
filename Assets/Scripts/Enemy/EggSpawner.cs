using UnityEngine;

[RequireComponent(typeof(OwlSpawner))]
public class EggSpawner : BulletSpawner
{
    protected override float BulletSpeed => 5f;
    private OwlSpawner _owlSpawner;
    private Vector3 _leftDirection = new(-1f, 0f, 0f);

    protected override void Awake()
    {
        base.Awake();
        _owlSpawner = GetComponent<OwlSpawner>();
    }

    private void OnEnable()
    {
        _owlSpawner.OwlCreated += SubscribeOnEggGenerate;
        _owlSpawner.OwlDestroyed += UnSubscribeOnEggGenerate;
    }

    private void OnDisable()
    {
        _owlSpawner.OwlCreated -= SubscribeOnEggGenerate;
        _owlSpawner.OwlDestroyed -= UnSubscribeOnEggGenerate;
    }

    private void SubscribeOnEggGenerate(Owl owl)
    {
        owl.MakedEgg += SpawnEgg;
    }

    private void UnSubscribeOnEggGenerate(Owl owl)
    {
        owl.MakedEgg -= SpawnEgg;
    }

    private void SpawnEgg(Vector3 position)
    {
        SpawnBullet(position, _leftDirection);
    }
}