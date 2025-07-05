using System;
using System.Collections;
using UnityEngine;

public class OwlGenerator : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public event Action OwlGenerated;

    public void GenerateOwls()
    {
        StartCoroutine(GeneratorOwls());
    }

    private IEnumerator GeneratorOwls()
    {
        while (enabled)
        {
            OwlGenerated?.Invoke();

            yield return new WaitForSeconds(UnityEngine.Random.Range(_minDelay, _maxDelay));
        }
    }
}