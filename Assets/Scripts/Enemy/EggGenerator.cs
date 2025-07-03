using UnityEngine;

[RequireComponent(typeof(OwlGenerator))]
[RequireComponent(typeof(PoolBullets))]
public class EggGenerator : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Sprite _spriteEgg;
    [SerializeField] private LayerMask _eggMask;

    private float _speedBullet = 5f;

    private Vector3 _letfDirection = new Vector3(-1f, 0f, 0f);
    private OwlGenerator _owlGenerator;
    private PoolBullets _poolEggs;

    private void Awake()
    {
        _owlGenerator = GetComponent<OwlGenerator>();
    }

    private void Start()
    {
        _poolEggs = GetComponent<PoolBullets>();
        _poolEggs.Init(10, 100, _prefab);
    }

    private void OnEnable()
    {
        _owlGenerator.OwlCreated += SubscribeOnEggGenerate;
        _owlGenerator.OwlDestroyed += UnSubscribeOnEggGenerate;
    }

    private void OnDisable()
    {
        _owlGenerator.OwlCreated -= SubscribeOnEggGenerate;
        _owlGenerator.OwlDestroyed -= UnSubscribeOnEggGenerate;
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
        Bullet egg = _poolEggs.GetInstance();
        egg.Init(_eggMask, position, _spriteEgg, _speedBullet, _letfDirection);
        egg.Destroyed += DestroyEgg;
    }

    private void DestroyEgg(Bullet bullet)
    {
        bullet.Destroyed -= DestroyEgg;
        _poolEggs.ReturnInstance(bullet);
    }
}