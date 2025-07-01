using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Owl : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite _spriteBullet;
    private Mover _mover;

    private float _minDelay = 0.5f;
    private float _maxDelay = 2.5f;
    private float _bulletSpeed = 3f;

    private WaitForSeconds _delayBetweenBullets;
    public event Action<Vector3, Sprite, float> BulletGenerated;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void Init(Vector3 spawn, float speed, Vector3 direction)
    {
        transform.position = spawn;
        _mover.Move(direction, speed);
    }

    private void OnEnable()
    {
        _delayBetweenBullets = new WaitForSeconds(UnityEngine.Random.Range(_minDelay, _maxDelay));
        StartCoroutine(GenerateBullet());
    }

    private IEnumerator GenerateBullet()
    {
        while (enabled)
        {
            BulletGenerated?.Invoke(transform.position, _spriteBullet, _bulletSpeed);

            yield return _delayBetweenBullets;
        }
    }
}