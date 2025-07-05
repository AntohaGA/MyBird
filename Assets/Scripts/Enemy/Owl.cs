using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(OwlCollisionHandler))]
[RequireComponent(typeof(OwlEggGenerator))]
public class Owl : MonoBehaviour, IInteractable
{
    private Mover _mover;
    private OwlCollisionHandler _collisionHandler;
    private OwlEggGenerator _generator;
    private EggSpawner _eggSpawner;

    public event Action<Owl> OwlShoted;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _generator = GetComponent<OwlEggGenerator>();
        _collisionHandler = GetComponent<OwlCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.OwlShoted += OwlDestroy;
    }

    private void OnDisable()
    {
        _collisionHandler.OwlShoted -= OwlDestroy;
    }

    public void Init(Vector3 spawn, float speed, Vector3 direction, EggSpawner eggSpawner)
    {
        transform.position = spawn;
        _mover.Move(direction, speed);
        _eggSpawner = eggSpawner;
        _generator.GenerateEgg(_eggSpawner);
    }

    private void OwlDestroy()
    {
        OwlShoted?.Invoke(this);
    }
}