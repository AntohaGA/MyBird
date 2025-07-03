using UnityEngine;

[RequireComponent(typeof(PoolBullets))]
public class AcornShooter : MonoBehaviour
{
    [SerializeField] private Bullet _acorn;
    [SerializeField] private Sprite _spriteAcorns;
    [SerializeField] private LayerMask _acornMask;

    private PoolBullets _poolAcorns;

    private void Start()
    {
        _poolAcorns = GetComponent<PoolBullets>();
        _poolAcorns.Init(10, 100, _acorn);
    }

    public void SpawnAcorn(Vector3 position,float speed, Vector3 direction)
    {
        Bullet acorn = _poolAcorns.GetInstance();
        acorn.Init(_acornMask, position, _spriteAcorns, speed, Vector3.Normalize(direction));
        acorn.Destroyed += ReturnAcorn;
    }

    private void ReturnAcorn(Bullet acorn)
    {
        acorn.Destroyed -= ReturnAcorn;
        _poolAcorns.ReturnInstance(acorn);
    }
}