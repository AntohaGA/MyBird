using UnityEngine;

public class Fire : ICommand
{
    private float _speedBullet  = 5;

    public void Execute(Raven raven)
    {
        Debug.Log("Fire!");
        raven.AcornGenerator.SpawnAcorn(raven.transform.position, _speedBullet, raven.transform.right);
    }
}