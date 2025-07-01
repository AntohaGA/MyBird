using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Coroutine _coroutineMove;

    private void OnEnable()
    {
        if (_coroutineMove != null)
        {
            StopCoroutine(_coroutineMove);
        }
    }

    public void Move(Vector3 direction, float speed)
    {
        _coroutineMove = StartCoroutine(MoveCoroutine(direction, speed));
    }


    private IEnumerator MoveCoroutine(Vector3 direction, float speed)
    {
        while (enabled)
        {
            transform.position += Vector3.Normalize(direction) * speed * Time.deltaTime;

            yield return null;
        }
    }
}