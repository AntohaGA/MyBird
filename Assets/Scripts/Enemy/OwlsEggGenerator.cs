using System;
using System.Collections;
using UnityEngine;

public class OwlsEggGenerator : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

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
