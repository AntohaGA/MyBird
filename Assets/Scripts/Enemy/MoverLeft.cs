using System.Collections;
using UnityEngine;

public class MoverLeft : MonoBehaviour
{
    private float _speed = 1.5f;
    private Coroutine _coroutineLeft;

    private void OnEnable()
    {
        if (_coroutineLeft != null)
        {
            StopCoroutine(_coroutineLeft);
        }

        _coroutineLeft = StartCoroutine(MoveLeft());
    }

    IEnumerator MoveLeft()
    {
        while (enabled)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;

            yield return null;
        }
    }
}