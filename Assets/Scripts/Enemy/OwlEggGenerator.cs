using System;
using System.Collections;
using UnityEngine;

public class OwlEggGenerator : MonoBehaviour
{
    private float _minDelay = 0.5f;
    private float _maxDelay = 2f;

    public event Action<Vector3> EggGenerated;

    private void OnEnable()
    {
        StartCoroutine(GenerateEggs());
    }

    private IEnumerator GenerateEggs()
    {
        while (enabled)
        {
            EggGenerated?.Invoke(transform.position);

            yield return new WaitForSeconds(UnityEngine.Random.Range(_minDelay, _maxDelay));
        }
    }
}
