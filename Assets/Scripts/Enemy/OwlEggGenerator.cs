using System.Collections;
using UnityEngine;

public class OwlEggGenerator : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public void GenerateEgg(EggSpawner eggSpawner)
    {
        StartCoroutine(GenerateEggs(eggSpawner));
    }

    private IEnumerator GenerateEggs(EggSpawner eggSpawner)
    {
        while (enabled)
        {
            eggSpawner.SpawnEgg(transform.position);

            yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        }
    }
}
