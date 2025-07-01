using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Mover))]
public class Bullet : MonoBehaviour, IInteractable
{
    private SpriteRenderer _spriteRenderer;
    private Coroutine DelayToDestroyCoroutine;
    private WaitForSeconds _delayToDestroy;
    private Mover _mover;

    public event Action<Bullet> Destroyed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mover = GetComponent<Mover>();
    }

    public void Init(Vector3 spawnPosition, Sprite sprite, float speed, Vector3 direction)
    {
        _spriteRenderer.sprite = sprite;
        transform.position = spawnPosition;
        _mover.Move(direction, speed);

        _delayToDestroy = new WaitForSeconds(3);

        if (DelayToDestroyCoroutine != null)
            StopCoroutine(DelayToDestroyCoroutine);

        DelayToDestroyCoroutine = StartCoroutine(LifeBullet());
    }

    private IEnumerator LifeBullet()
    {
        yield return _delayToDestroy;

        Destroyed?.Invoke(this);
    }
}