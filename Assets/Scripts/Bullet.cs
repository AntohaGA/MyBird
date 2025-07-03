using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Mover))]
public class Bullet : MonoBehaviour, IInteractable
{
    private const float LifeTime = 3f;
    private SpriteRenderer _spriteRenderer;
    private Coroutine _delayToDestroyCoroutine;
    private WaitForSeconds _lifeTimeWait;
    private Mover _mover;

    public LayerMask LayerMask { get ; private set; }

    public event Action<Bullet> Destroyed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mover = GetComponent<Mover>();
    }

    public void Init(LayerMask type, Vector3 spawnPosition, Sprite sprite, float speed, Vector3 direction)
    {
        LayerMask = type;
        _spriteRenderer.sprite = sprite;
        transform.position = spawnPosition;
        _mover.Move(direction, speed);

        _lifeTimeWait = new WaitForSeconds(LifeTime);

        if (_delayToDestroyCoroutine != null)
            StopCoroutine(_delayToDestroyCoroutine);

        _delayToDestroyCoroutine = StartCoroutine(LifeBullet());
    }

    private IEnumerator LifeBullet()
    {
        yield return _lifeTimeWait;

        Destroyed?.Invoke(this);
    }

    private void Reset()
    {
        if (_delayToDestroyCoroutine != null)
            StopCoroutine(_delayToDestroyCoroutine);
    }
}