using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(OwlCollisionHandler))]
[RequireComponent(typeof(OwlEggGenerator))]
public class Owl : MonoBehaviour, IInteractable
{
    private Mover _mover;
    private OwlEggGenerator _owlEggGenerator;
    private OwlCollisionHandler _collisionHandler;

    public event Action<Vector3> MakedEgg;
    public event Action<Owl> OwlShoted;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _owlEggGenerator = GetComponent<OwlEggGenerator>();
        _collisionHandler = GetComponent<OwlCollisionHandler>();
    }

    private void OnEnable()
    {
        _owlEggGenerator.EggGenerated += MakeEgg;
        _collisionHandler.OwlShoted += OwlDestroy;
    }

    private void OnDisable()
    {
        _owlEggGenerator.EggGenerated -= MakeEgg;
        _collisionHandler.OwlShoted -= OwlDestroy;
    }

    public void Init(Vector3 spawn, float speed, Vector3 direction)
    {
        transform.position = spawn;
        _mover.Move(direction, speed);
    }

    private void MakeEgg(Vector3 position)
    {
        MakedEgg?.Invoke(position);  
    }

    private void OwlDestroy()
    {
        OwlShoted?.Invoke(this);
    }
}